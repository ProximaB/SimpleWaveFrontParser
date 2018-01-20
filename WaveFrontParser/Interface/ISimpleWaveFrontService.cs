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
        int LookForVertexs(LoadObjFileHendler file, List<Vertex> vertexs);
        int LookForNormals(LoadObjFileHendler file, List<Vertex> normals);
        int LookForTextureVertex(LoadObjFileHendler file, List<Vertex> texVertex);
    }
}
