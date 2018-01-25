using System;
using System.Collections.Generic;
using WaveFrontParser.Handler;
using WaveFrontParser.Model;
using WaveFrontParser.Service;
using WaveFrontParser.PresentationSnippets;
using System.Linq;
using WaveFrontParser.Handler;
using System.Text;

namespace WaveFrontParser
{
    class Program
    {
        static void Main(string[] args)
        {
            //Presentation.FindVertexs();
            //Presentation.ParseToObject();

            //Presentation.Interpolation();

            string name_ = "ZROBOT";
            for(var i = 0; i <= 5; i++)
            {
                work(name_ + i);
            }
            work("ZROBOT");

            void work(string name)
            { 
            LoadObjFileHandler Obj = new LoadObjFileHandler(name + ".obj");
            Console.WriteLine("File Loaded: " + Obj.LoadObj().ToString());

            SimpleWaveFrontService _WaveService = new SimpleWaveFrontService(Obj);

            FileStreamHandler FileNormal = new FileStreamHandler(name + "Normals.txt");
            FileStreamHandler FileVertex = new FileStreamHandler(name + "Vertex.txt");
            FileStreamHandler FileFaces = new FileStreamHandler(name + "Faces.txt");
            FileStreamHandler FileTextures = new FileStreamHandler("Textures.txt");
            FileStreamHandler Stats = new FileStreamHandler(name + "Stats.txt");

            _WaveService.LookForVertexs();
            _WaveService.LookForNormals();
            //_WaveService.LookForTextureVertex();
            _WaveService.LookForFaces(2);

            SimpleWaveFront waveFront = _WaveService.WaveFront;

            var vertexs = waveFront.Vertexs;
            var normals = waveFront.Normal;
            var textVertexs = waveFront.TexVertexs;
            var faces = waveFront.Faces;

                #region normals
                Console.WriteLine("\nNomals:\n");
                StringBuilder nr = new StringBuilder();
                foreach (var norm in normals)
                {
                    //Console.Write($"{norm.XAxis}, {norm.YAxis}, {norm.ZAxis}, | ");
                     nr.Append($"{norm.XAxis}, {norm.YAxis}, {norm.ZAxis}, ");
                }
                FileNormal.AppendTextToFIle(nr.ToString());
                Console.WriteLine("\n" + String.Concat(Enumerable.Repeat("_", 120)));
                #endregion


            Console.WriteLine("\nVertex:\n");
            StringBuilder sb = new StringBuilder();
            foreach (var vert in vertexs)
            {
                //Console.Write($"{vert.XAxis}, {vert.YAxis}, {vert.ZAxis}, | ");
                //sb.Append($"{{ {vert.XAxis}, {vert.YAxis}, {vert.ZAxis} }}, ");
                sb.Append($"{vert.XAxis} {vert.YAxis} {vert.ZAxis} ");

            }
            FileVertex.AppendTextToFIle(sb.ToString());
            Console.WriteLine("\n" + String.Concat(Enumerable.Repeat("_", 120)));

            #region texture
            //Console.WriteLine("\nVerTexture:\n");
            //foreach (var tVert in textVertexs)
            //{
            //    Console.Write($"{tVert.XAxis}, {tVert.YAxis} | ");
            //    FileTextures.AppendTextToFIle($"{tVert.XAxis} {tVert.YAxis} ");
            //}
            //Console.WriteLine("\n" + String.Concat(Enumerable.Repeat("_", 120)));
            #endregion


            Console.WriteLine("\nIndicies:\n");
            StringBuilder sa = new StringBuilder();
            foreach (var face in faces)
            {
                face.VertIndicies.ForEach(a =>
                {
                    //Console.Write($"{a}, ");
                    //sa.Append(a.ToString() + ", ");
                    sa.Append(a.ToString() + " ");

                });
                // Console.Write(" | ");
            }
            FileFaces.AppendTextToFIle(sa.ToString());
            Console.WriteLine("\n" + String.Concat(Enumerable.Repeat("_", 120)) + "\n");

            Stats.AppendTextToFIle($"Vertex: {(vertexs.Count * 3).ToString()} \n");
            Stats.AppendTextToFIle($"Indicies: {(faces.Count * 3).ToString()}");
            Stats.AppendTextToFIle($"Normals: {(normals.Count * 3).ToString()}");
            }
        }
    }
}