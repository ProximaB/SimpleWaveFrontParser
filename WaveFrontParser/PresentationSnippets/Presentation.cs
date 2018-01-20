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

            var texVerts = _WaveService.WaveFront.TexVertexs;

            var i = 1;
            Console.WriteLine("Founded Vertexes: \n");
            foreach (var texVert in texVerts)
            {
                Console.WriteLine($"{i}. x={texVert.XAxis}, y={texVert.YAxis}");
                i++;
            }

        }
    }
}
