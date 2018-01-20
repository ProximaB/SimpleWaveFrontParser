using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WaveFrontParser.Interface
{
    public interface ILoadObjFileHendler : IDisposable
    {
        string FileContent { get; set; }

        string FilePath { get; set; }

        bool LoadObj();
    }
}
