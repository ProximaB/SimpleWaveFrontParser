using System;
using System.Collections.Generic;
using System.Text;
using WaveFrontParser.Model;
using WaveFrontParser.Handler;
using WaveFrontParser.Interface;
using System.Globalization;

namespace WaveFrontParser.Service
{
    public class SimpleWaveFrontService : ISimpleWaveFrontService
    {
        public ILoadObjFileHandler LoadFile { get; set; }

        public SimpleWaveFront WaveFront { get;  set; }

        public bool LookForVertexs(ILoadObjFileHandler file, List<Vertex> vertexs)
        {
            string content = file.FileContent;
            List<string> vertexsTab = new List<string>();
            content = content.Remove(0, content.IndexOf("v "));

            //vertexs.Add(new Vertex() { XAxis = 1, YAxis = -1, ZAxis = -1 });
            //vertexs.Add (new Vertex() { XAxis = 1, YAxis = -1, ZAxis = 1 });

            var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var line in lines)
            {
                if(line.StartsWith("v "))
                {
                    vertexsTab.Add(line.Substring(2));
                }
            }

            foreach( var vrtx in vertexsTab)
            {
                Vertex vertex = new Vertex();

                var vertTab  = vrtx.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (vertTab.Length == 3)
                {
                    vertex.XAxis = Convert.ToDouble(vertTab[0], CultureInfo.InvariantCulture);
                    vertex.YAxis = Convert.ToDouble(vertTab[1], CultureInfo.InvariantCulture);
                    vertex.ZAxis = Convert.ToDouble(vertTab[2], CultureInfo.InvariantCulture);
                }
                else throw new NullReferenceException(message: $"Doesn't found x, y, z of Vertex. \n vertexTab[this] = {vrtx}\n");

                vertexs.Add(vertex);
            }
            
            return true;

        }
        public bool LookForNormals(ILoadObjFileHandler file, List<Normal> normals)
        {
            string content = file.FileContent;
            List<string> normalsTab = new List<string>();
            content = content.Remove(0, content.IndexOf("vn "));

            var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach ( var line in lines)
            {
                if(line.StartsWith("vn "))
                {
                    normalsTab.Add(line.Substring(3));
                }
            }

            foreach(var nrml in normalsTab)
            {
                Normal normal = new Normal();
                var normTab = nrml.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (normTab.Length == 3)
                {
                    normal.XAxis = Convert.ToDouble(normTab[0], CultureInfo.InvariantCulture);
                    normal.YAxis = Convert.ToDouble(normTab[1], CultureInfo.InvariantCulture);
                    normal.ZAxis = Convert.ToDouble(normTab[2], CultureInfo.InvariantCulture);
                }
                else throw new NullReferenceException(message: $"Doesn't found x, y, z of Normals. \n normalTab[this] = {nrml}\n");

                normals.Add(normal);

                //normals.Add(new Normal() { XAxis = 0, YAxis = -1, ZAxis = 0 });
                //normals.Add(new Normal() { XAxis = 0, YAxis = 1, ZAxis = 0 });
            }
            
            return true;
        }

        public bool LookForTextureVertex(ILoadObjFileHandler file, List<TextureVertex> texVertex)
        {
            throw new NotImplementedException();
        }

    }
}
