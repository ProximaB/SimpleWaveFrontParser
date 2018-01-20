using System;
using System.Collections.Generic;
using System.Text;

namespace WaveFrontParser.Model
{
    public class SimpleWaveFront
    {
        public List<Face> Faces { get; set; }
        public Vertex[] Vertexs { get; set; }
        public Normal[] Normal { get; set; }
        public TextureVertex[] TexVertexs { get; set; }
    }
}
