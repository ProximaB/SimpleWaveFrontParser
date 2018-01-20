using System;
using System.Collections.Generic;
using System.Text;
using WaveFrontParser.Interface;

namespace WaveFrontParser.Tests.Handler
{
    class LoadObjFileHandlerMock : ILoadObjFileHandler
    {
        public string FileContent { get; set; }
        public string FilePath { get; set; } = "path";

        public LoadObjFileHandlerMock(string content)
        {
            FileContent = content;
        }
        public void Dispose()
        {
            FileContent = null;
        }

        public bool LoadObj()
        {
            return true;
        }
    }
}
