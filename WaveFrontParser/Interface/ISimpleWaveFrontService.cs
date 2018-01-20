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
        bool LookForVertexs(ILoadObjFileHandler file, List<Vertex> vertexs);
        bool LookForNormals(ILoadObjFileHandler file, List<Normal> normals);
        bool LookForTextureVertex(ILoadObjFileHandler file, List<TextureVertex> texVertex);
    }
}
