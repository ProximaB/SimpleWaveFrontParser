using System;
using System.Collections.Generic;
using System.Text;
using WaveFrontParser.Model;
using WaveFrontParser.Hendler;
using WaveFrontParser.Interface;

namespace WaveFrontParser.Service
{
    public class SimpleWaveFrontService : ISimpleWaveFrontService
    {
        public LoadObjFileHendler LoadFile { get; set; }

        public SimpleWaveFront WaveFront { get;  set; }

        public bool LookForVertexs(ILoadObjFileHendler file, List<Vertex> vertexs)
        {
            string content = file.FileContent;
            vertexs.Add(new Vertex() { XAxis = 1, YAxis = -1, ZAxis = -1 });
            vertexs.Add (new Vertex() { XAxis = 1, YAxis = -1, ZAxis = 1 });
            return true;

        }
        public bool LookForNormals(ILoadObjFileHendler file, List<Vertex> normals)
        {
            string content = file.FileContent;

            
            return true;
        }

        public bool LookForTextureVertex(ILoadObjFileHendler file, List<Vertex> texVertex)
        {
            throw new NotImplementedException();
        }

    }
}
