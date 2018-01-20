using System;
using System.Collections.Generic;
using System.Text;

namespace WaveFrontParser.Model
{
    public class SimpleWaveFront
    {
        public List<Face> Faces { get; set; }
        public List<Vertex> Vertexs { get; set; }
        public List<Normal> Normal { get; set; }
        public List<TextureVertex> TexVertexs { get; set; }
    }
}
