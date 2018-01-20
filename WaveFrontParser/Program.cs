using System;
using System.Collections.Generic;
using WaveFrontParser.Handler;
using WaveFrontParser.Model;
using WaveFrontParser.Service;
using WaveFrontParser.PresentationSnippets;

namespace WaveFrontParser
{
    class Program
    {
        static void Main(string[] args)
        {
            //Presentation.FindVertexs();
            //Presentation.ParseToObject();

            //Presentation.Interpolation();



            LoadObjFileHandler Obj = new LoadObjFileHandler("cube.obj");
            Console.WriteLine("File Loaded: " + Obj.LoadObj().ToString());

            SimpleWaveFrontService _WaveService = new SimpleWaveFrontService(Obj);

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
                Console.Write($"{norm.XAxis}, {norm.YAxis}, {norm.ZAxis}, ");
            }

            Console.WriteLine("\nVertex:\n");
            foreach (var vert in vertexs)
            {
                Console.Write($"{vert.XAxis}, {vert.YAxis}, {vert.ZAxis}, ");
            }

            Console.WriteLine("\nIndicies:\n");
            foreach (var face in faces)
            {
                face.VertIndicies.ForEach(a => Console.Write($"{a}, "));
            }

        }
    }
}
