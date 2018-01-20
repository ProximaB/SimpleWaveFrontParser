using System;
using System.Collections.Generic;
using System.Text;

namespace WaveFrontParser.Model
{
   public class Face
    {
        public int[] VertIndicies { get; set; } // 3 vertex
        public int NormIndicies { get; set; } // 1 normal
        public int[] TexIndicies { get; set; } // 2 texture vertex

    }
}
