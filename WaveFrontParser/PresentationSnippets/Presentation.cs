using System;
using System.Collections.Generic;
using System.Text;
using WaveFrontParser.Handler;
using WaveFrontParser.Model;
using WaveFrontParser.Service;

namespace WaveFrontParser.PresentationSnippets
{
    public static class Presentation
    {
        public static void FindVertexs()
        {
            LoadObjFileHandler Obj = new LoadObjFileHandler("cube.obj");
            Console.WriteLine("Result: " + Obj.LoadObj().ToString());

            SimpleWaveFrontService _WaveService = new SimpleWaveFrontService(Obj);

            List<Vertex> vertexs = new List<Vertex>();

            vertexs = _WaveService.LookForVertexs();

            var i = 1;
            Console.WriteLine("Founded Vertexes: \n");
            foreach (var vertex in vertexs)
            {
                Console.WriteLine($"{i}. x={vertex.XAxis}, y={vertex.YAxis}, z={vertex.ZAxis}");
                i++;
            }

        }
        public static void FindNormals()
        {
            LoadObjFileHandler Obj = new LoadObjFileHandler("cube.obj");
            Console.WriteLine("Result: " + Obj.LoadObj().ToString());

            SimpleWaveFrontService _WaveService = new SimpleWaveFrontService(Obj);

            List<Normal> normals = new List<Normal>();

            normals = _WaveService.LookForNormals();

            var i = 1;
            Console.WriteLine("Founded Vertexes: \n");
            foreach (var normlas in normals)
            {
                Console.WriteLine($"{i}. x={normlas.XAxis}, y={normlas.YAxis}, z={normlas.ZAxis}");
                i++;
            }

        }   
        public static void FindTextureVertexs()
        {
            LoadObjFileHandler Obj = new LoadObjFileHandler("cube.obj");
            Console.WriteLine("Result: " + Obj.LoadObj().ToString());

            SimpleWaveFrontService _WaveService = new SimpleWaveFrontService(Obj);

            List<TextureVertex> texVerts = new List<TextureVertex>();

            texVerts = _WaveService.LookForTextureVertex();

            var i = 1;
            Console.WriteLine("Founded Vertexes: \n");
            foreach (var texVert in texVerts)
            {
                Console.WriteLine($"{i}. x={texVert.XAxis}, y={texVert.YAxis}");
                i++;
            }

        }

        public static void ParseToObject()
        {
            LoadObjFileHandler Obj = new LoadObjFileHandler("cube.obj");
            Console.WriteLine("Result: " + Obj.LoadObj().ToString());

            SimpleWaveFrontService _WaveService = new SimpleWaveFrontService(Obj);

            _WaveService.LookForVertexs();
            _WaveService.LookForNormals();
            _WaveService.LookForTextureVertex();
            _WaveService.LookForFaces(1);

            SimpleWaveFront waveFront = _WaveService.WaveFront;
            var vertexs = waveFront.Vertexs;
            var normals = waveFront.Normal;
            var textVertexs = waveFront.TexVertexs;
            var faces = waveFront.Faces;

            var i = 1;
            foreach (var face in faces)
            {
                Console.WriteLine($"\n\nFace {i}");
                Console.WriteLine("Vertexs:");
                face.VertIndicies.ForEach(a => Console.Write(a + ", "));
                Console.WriteLine("\nNormals:");
                face.NormIndicies.ForEach(a => Console.Write(a + ", "));
                Console.WriteLine("\nTextureVertexs:");
                face.TexIndicies.ForEach(a => Console.Write(a + ", "));

                i++;
            }

        }



        public static void Interpolation()
        {
            LoadObjFileHandler Obj = new LoadObjFileHandler("cube.obj");
            Console.WriteLine("Result: " + Obj.LoadObj().ToString());

            SimpleWaveFrontService _WaveService = new SimpleWaveFrontService(Obj);

            _WaveService.LookForVertexs();
            _WaveService.LookForNormals();
            _WaveService.LookForTextureVertex();
            _WaveService.LookForFaces(1);

            SimpleWaveFront waveFront = _WaveService.WaveFront;
            var vertexs = waveFront.Vertexs;
            var normals = waveFront.Normal;
            var textVertexs = waveFront.TexVertexs;
            var faces = waveFront.Faces;

            var i = 1;
            foreach (var face in faces)
            {
                Console.WriteLine($"\n\nFace {i}");

                Console.WriteLine("Vertexs:");
                face.VertIndicies.ForEach(a => 
                {
                    Console.WriteLine($"{a}. x={vertexs[a].XAxis}, y={vertexs[a].YAxis}, z={vertexs[a].ZAxis}");
                });

                Console.WriteLine("\nNormals:");
                face.NormIndicies.ForEach(a =>
                {
                    Console.WriteLine($"{a}. x={normals[a].XAxis}, y={normals[a].YAxis}, z={normals[a].ZAxis}");
                });

                Console.WriteLine("\nTextureVertexs:");
                face.VertIndicies.ForEach(a =>
                {
                    Console.WriteLine($"{a}. x={textVertexs[a].XAxis}, y={textVertexs[a].YAxis}");
                });

                i++;
            }

        }
    }
}
