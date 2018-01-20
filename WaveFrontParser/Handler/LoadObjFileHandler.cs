using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WaveFrontParser.Interface;

namespace WaveFrontParser.Handler
{
    public class LoadObjFileHandler : ILoadObjFileHandler, IDisposable
    {
        private string filePath;
        public string FileContent { get; set; }

        public string FilePath
        {
            get { return filePath; }

            set
            {
              if (value [1] != ':') filePath = Environment.CurrentDirectory.ToString() + @"\"+ value;
              else filePath = value;
            }
        }

        public LoadObjFileHandler(string _objFilePath)
        {
            FilePath = _objFilePath;       
        }

        public bool LoadObj()
        {
            try
            {
                using (FileStream subFileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                using (StreamReader reader = new StreamReader(subFileStream))
                {
                    FileContent = reader.ReadToEnd();
                }

                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public void Dispose()
        {
            FileContent = null;
        }

    }
}
