using System;
using System.Collections.Generic;
using System.Text;

namespace WaveFrontParser.Model
{
    public class Face
    {
        public List<int> VertIndicies { get; set; } // 3 vertex [3d]
        public List<int> NormIndicies { get; set; } // 3 normal [3d]
        public List<int> TexIndicies { get; set; } // 3 texture vertex[2d]

    }
}
