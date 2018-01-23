using System;
using System.Collections.Generic;
using WaveFrontParser.Handler;
using WaveFrontParser.Model;
using WaveFrontParser.Service;
using WaveFrontParser.PresentationSnippets;
using System.Linq;
using WaveFrontParser.Handler;

namespace WaveFrontParser
{
    class Program
    {
        static void Main(string[] args)
        {
            //Presentation.FindVertexs();
            //Presentation.ParseToObject();

            //Presentation.Interpolation();



            LoadObjFileHandler Obj = new LoadObjFileHandler("obj2.obj");
            Console.WriteLine("File Loaded: " + Obj.LoadObj().ToString());

            SimpleWaveFrontService _WaveService = new SimpleWaveFrontService(Obj);

            FileStreamHandler FileNormal = new FileStreamHandler("Normals.txt");
            FileStreamHandler FileVertex = new FileStreamHandler("Vertex.txt");
            FileStreamHandler FileFaces = new FileStreamHandler("Faces.txt");

            _WaveService.LookForVertexs();
            _WaveService.LookForNormals();
            _WaveService.LookForTextureVertex();
            _WaveService.LookForFaces();

            SimpleWaveFront waveFront = _WaveService.WaveFront;

            var vertexs = waveFront.Vertexs;
            var normals = waveFront.Normal;
            var textVertexs = waveFront.TexVertexs;
            var faces = waveFront.Faces;

            Console.WriteLine("\nNomals:\n");
            foreach (var norm in normals)
            {
                Console.Write($"{norm.XAxis}, {norm.YAxis}, {norm.ZAxis}, | ");
                FileNormal.AppendTextToFIle($"{norm.XAxis} {norm.YAxis} {norm.ZAxis} ");
            }
            Console.WriteLine("\n" + String.Concat(Enumerable.Repeat("_", 120)));

            Console.WriteLine("\nVertex:\n");
            foreach (var vert in vertexs)
            {
                Console.Write($"{vert.XAxis}, {vert.YAxis}, {vert.ZAxis}, | ");
                FileVertex.AppendTextToFIle($"{vert.XAxis} {vert.YAxis} {vert.ZAxis} ");
            }
            Console.WriteLine("\n" + String.Concat(Enumerable.Repeat("_", 120)));

            Console.WriteLine("\nVerTexture:\n");
            foreach (var tVert in textVertexs)
            {
                Console.Write($"{tVert.XAxis}, {tVert.YAxis} | ");
                FileVertex.AppendTextToFIle($"{tVert.XAxis} {tVert.YAxis} ");
            }
            Console.WriteLine("\n" + String.Concat(Enumerable.Repeat("_", 120)));

            Console.WriteLine("\nIndicies:\n");
            foreach (var face in faces)
            {
                face.VertIndicies.ForEach(a =>
                {
                    Console.Write($"{a}, ");
                    FileFaces.AppendTextToFIle(a.ToString() + " ");
                });
                Console.Write(" | ");
            }

            Console.WriteLine("\n" + String.Concat(Enumerable.Repeat("_", 120)) + "\n");
        }
    }
}