using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WaveFrontParser.Handler
{
    public class FileStreamHandler
    {
        static string  path = @"C:\Users\barte\source\repos\SimpleWaveFrontParser\Wyniki";
        private string fileName;

        public FileStreamHandler(string _fileName)
        {
            fileName = _fileName;
            try
            {
                Directory.CreateDirectory(path);
                using (FileStream stream = new FileStream(path + @"\" + fileName, FileMode.OpenOrCreate))
                {
                    stream.SetLength(0);
                }
            }
            catch
            {
                throw new InvalidOperationException(message : "Error while creating/opening the file ${fileName}.");
            }
        }

        public bool AppendTextToFIle(string content)
        {
            try
            {
                using (FileStream stream = new FileStream(path + @"\" + fileName, FileMode.OpenOrCreate))
                {
                   
                    UTF8Encoding converter = new UTF8Encoding();
                    byte[] bytes = converter.GetBytes(content);
                    stream.Seek(stream.Length, SeekOrigin.Current);
                    foreach (var eachByte in bytes)
                    {
                        stream.WriteByte(eachByte);
                    }

                }

                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
