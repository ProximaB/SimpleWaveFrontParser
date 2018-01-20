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
        public static void FindVertexDemo()
        {
            LoadObjFileHandler Obj = new LoadObjFileHandler("cube.obj");
            Console.WriteLine("Result: " + Obj.LoadObj().ToString());

            SimpleWaveFrontService _WaveService = new SimpleWaveFrontService();
            List<Vertex> vertexs = new List<Vertex>();

            _WaveService.LookForVertexs(Obj, vertexs);

            var i = 1;
            Console.WriteLine("Founded Vertexes: \n");
            foreach (var vertex in vertexs)
            {
                Console.WriteLine($"{i}. x={vertex.XAxis}, y={vertex.YAxis}, z={vertex.ZAxis}");
                i++;
            }

        }
    }
}
