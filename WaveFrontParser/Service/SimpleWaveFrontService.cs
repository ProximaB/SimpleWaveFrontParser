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
        private SimpleWaveFront waveFront = new SimpleWaveFront();

        public ILoadObjFileHandler LoadFile { get; set; }

        public SimpleWaveFront WaveFront { get { return waveFront; } set { waveFront = value; } }

        public SimpleWaveFrontService(ILoadObjFileHandler _loadFile)
        {
            LoadFile = _loadFile;
        }

        public List<Vertex> LookForVertexs()
        {
            List<Vertex> vertexs = new List<Vertex>();

            string content = LoadFile.FileContent;
            List<string> vertexsTab = new List<string>();
            content = content.Remove(0, content.IndexOf("v "));

            //vertexs.Add(new Vertex() { XAxis = 1, YAxis = -1, ZAxis = -1 });
            //vertexs.Add (new Vertex() { XAxis = 1, YAxis = -1, ZAxis = 1 });

            var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                if (line.StartsWith("v "))
                {
                    vertexsTab.Add(line.Substring(2));
                }
            }

            foreach (var vrtx in vertexsTab)
            {
                Vertex vertex = new Vertex();

                var vertTab = vrtx.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (vertTab.Length == 3)
                {
                    vertex.XAxis = Convert.ToDouble(vertTab[0], CultureInfo.InvariantCulture);
                    vertex.YAxis = Convert.ToDouble(vertTab[1], CultureInfo.InvariantCulture);
                    vertex.ZAxis = Convert.ToDouble(vertTab[2], CultureInfo.InvariantCulture);
                }
                else throw new NullReferenceException(message: $"Doesn't found x, y, z of Vertex. \n vertexTab[this] = {vrtx}\n");

                vertexs.Add(vertex);
            }

            WaveFront.Vertexs = vertexs;
            return vertexs;

        }
        public List<Normal> LookForNormals()
        {
            List<Normal> normals = new List<Normal>();

            string content = LoadFile.FileContent;
            List<string> normalsTab = new List<string>();
            content = content.Remove(0, content.IndexOf("vn "));

            var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                if (line.StartsWith("vn "))
                {
                    normalsTab.Add(line.Substring(3));
                }
            }

            foreach (var nrml in normalsTab)
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
            WaveFront.Normal = normals;
            return normals;
        }

        public List<TextureVertex> LookForTextureVertex()
        {
            List<TextureVertex> texVerts = new List<TextureVertex>();

            string content = LoadFile.FileContent;
            List<string> textVertexsTab = new List<string>();
            content = content.Remove(0, content.IndexOf("vt "));

            var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                if (line.StartsWith("vt "))
                {
                    textVertexsTab.Add(line.Substring(3));
                }
            }

            foreach (var vert in textVertexsTab)
            {
                TextureVertex texVert = new TextureVertex();
                var vertTab = vert.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (vertTab.Length == 2)
                {
                    texVert.XAxis = Convert.ToDouble(vertTab[0], CultureInfo.InvariantCulture);
                    texVert.YAxis = Convert.ToDouble(vertTab[1], CultureInfo.InvariantCulture);
                }
                else throw new NullReferenceException(message: $"Doesn't found x, y TExtureVertex. \n textVertexsTab[this] = {vert}\n");

                texVerts.Add(texVert);

                //normals.Add(new Normal() { XAxis = 0, YAxis = -1, ZAxis = 0 });
                //normals.Add(new Normal() { XAxis = 0, YAxis = 1, ZAxis = 0 });
            }

            waveFront.TexVertexs = texVerts;
            return texVerts;
        }

        public List<Face> LookForFaces()
        {
            List<Face> faces = new List<Face>();
            faces.Add(new Face()
            {
                VertIndicies = new List<int>() { 1, 2, 3 },
                NormIndicies = new List<int>() { 1, 2, 3 },
                TexIndicies = new List<int>() { 1, 1, 1 },
            });

            faces.Add(new Face()
            {
                VertIndicies = new List<int>() { 1, 3, 4 },
                NormIndicies = new List<int>() { 1, 3, 4 },
                TexIndicies = new List<int>() { 1, 1, 1 },
            });

            WaveFront.Faces = faces;
            return faces;
        }
    }
}
