using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WaveFrontParser.Hendler
{
    public class LoadObjFileHendler : IDisposable
    {
        public string content { get; set; }

        public string objFilePath {get; private set; }

        public LoadObjFileHendler(string _objFilePath)
        {
            objFilePath = _objFilePath;

            if (objFilePath[1] != ':') objFilePath = Environment.CurrentDirectory.ToString() + objFilePath;

            FileStream subFileStream = new FileStream(objFilePath, FileMode.Open, FileAccess.Read);
            using (StreamReader reader = new StreamReader(subFileStream))
            {
                string content = reader.ReadToEnd();
            }
        }

        public void Dispose()
        {
            content = null;
        }
    }
}
