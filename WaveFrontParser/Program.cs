using System;
using WaveFrontParser.Hendler;
using WaveFrontParser.Service;

namespace WaveFrontParser
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadObjFileHendler Obj = new LoadObjFileHendler("cube.obj");
            Console.WriteLine("Result: " + Obj.LoadObj().ToString());
    

        }
    }
}
