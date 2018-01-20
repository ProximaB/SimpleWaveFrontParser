using System;
using System.Collections.Generic;
using System.Text;
using WaveFrontParser.Interface;

namespace WaveFrontParserTests.Hendler
{
    class LoadObjFileHendlerMock : ILoadObjFileHendler
    {
        public string FileContent { get; set; }
        public string FilePath { get; set; } = "path";

        public LoadObjFileHendlerMock(string content)
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
