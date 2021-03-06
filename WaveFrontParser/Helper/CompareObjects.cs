﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveFrontParser.Model;

namespace WaveFrontParser.Helper
{
    public class CompareObjects : IComparer<Vertex>
    {
        public int Compare( Vertex x, Vertex y)
        {
            if (x.XAxis == y.XAxis && x.YAxis == y.YAxis && x.ZAxis == y.ZAxis)
                return 1;

            else return 0;

        }
        public int Compare( Normal x, Normal y)
        {
            if (x.XAxis == y.XAxis && x.YAxis == y.YAxis && x.ZAxis == y.ZAxis)
                return 1;

            else return 0;

        }
        public int Compare(TextureVertex x, TextureVertex y)
        {
            if (x.XAxis == y.XAxis && x.YAxis == y.YAxis)
                return 1;

            else return 0;
        }

        public int Compare(Face x, Face y)
        {
            if (!x.VertIndicies.Except(y.VertIndicies).Any() && !x.NormIndicies.Except(y.NormIndicies).Any() && !x.TexIndicies.Except(y.TexIndicies).Any())
                return 1;

            else return 0;
        }

    }
}
