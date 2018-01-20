using System;
using System.Collections.Generic;
using System.Text;
using WaveFrontParser.Hendler;
using WaveFrontParser.Model;

namespace WaveFrontParser.Interface
{
    interface ISimpleWaveFrontService
    {
        LoadObjFileHendler LoadFile { get; set; }
        bool LookForVertexs(ILoadObjFileHendler file, List<Vertex> vertexs);
        bool LookForNormals(ILoadObjFileHendler file, List<Vertex> normals);
        bool LookForTextureVertex(ILoadObjFileHendler file, List<Vertex> texVertex);
    }
}
