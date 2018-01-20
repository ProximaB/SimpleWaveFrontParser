using System;
using System.Collections.Generic;
using System.Text;
using WaveFrontParser.Model;
using WaveFrontParser.Hendler;
using WaveFrontParser.Interface;

namespace WaveFrontParser.Service
{
    class SimpleWaveFrontService : ISimpleWaveFrontService
    {
        public LoadObjFileHendler LoadFile { get; set; }
        public SimpleWaveFront WaveFront { get; private set; }

        public int LookForNormals(LoadObjFileHendler file, List<Vertex> normals)
        {
            throw new NotImplementedException();
        }

        public int LookForTextureVertex(LoadObjFileHendler file, List<Vertex> texVertex)
        {
            throw new NotImplementedException();
        }

        public int LookForVertexs(LoadObjFileHendler file, List<Vertex> vertexs)
        {
            throw new NotImplementedException();
        }
    }
}
