using System;
using System.Collections.Generic;
using System.Text;
using WaveFrontParser.Handler;
using WaveFrontParser.Model;

namespace WaveFrontParser.Interface
{
    public interface ISimpleWaveFrontService
    {
        ILoadObjFileHandler LoadFile { get; set; }
        List<Vertex> LookForVertexs ();
        List<Normal> LookForNormals ();
        List<TextureVertex> LookForTextureVertex ();
    }
}
