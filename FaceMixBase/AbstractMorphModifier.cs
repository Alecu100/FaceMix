using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FaceMix.Core;

namespace FaceMix.Base
{
    public abstract class AbstractMorphModifier : AbstractModifier
    {
        public virtual List<VertexDisplacement> CalculateDisplacements(List<VertexPosition> target, List<VertexPosition> reference, List<int> ignorelist, double accuracy)
        {
            if (target.Count != reference.Count)
                return null;
            List<VertexDisplacement> morphList = new List<VertexDisplacement>();
            double max = 0;
            for (int i = 0; i < target.Count; i++)
            {
                max = Math.Max(max, Math.Abs(target[i].X - reference[i].X));
                max = Math.Max(max, Math.Abs(target[i].Y - reference[i].Y));
                max = Math.Max(max, Math.Abs(target[i].Z - reference[i].Z));
            }
            double scale = 32765f / max;
            for (int i = 0; i < target.Count; i++)
            {

                double x = target[i].X - reference[i].X;
                double y = target[i].Y - reference[i].Y;
                double z = target[i].Z - reference[i].Z;
                if (!(ignorelist.Contains(i)) && (Math.Abs(x) >= accuracy || Math.Abs(y) >= accuracy || Math.Abs(z) >= accuracy))
                    morphList.Add(new VertexDisplacement((short)-Math.Ceiling(x * scale), (short)-Math.Ceiling(y * scale), (short)-Math.Ceiling(z * scale)));
                else
                {
                    morphList.Add(new VertexDisplacement(0, 0, 0));
                }
            }
            return morphList;
        }

        public virtual List<VertexDisplacement> CalculateDisplacements(List<Triple<double, double, double>> offsets, List<int> ignorelist, double accuracy)
        {
            List<VertexDisplacement> morphList = new List<VertexDisplacement>();
            double max = 0;
            for (int i = 0; i < offsets.Count; i++)
            {
                max = Math.Max(max, Math.Abs(offsets[i].X));
                max = Math.Max(max, Math.Abs(offsets[i].Y));
                max = Math.Max(max, Math.Abs(offsets[i].Z));
            }
            double scale = 32765f / max;
            for (int i = 0; i < offsets.Count; i++)
            {

                double x = offsets[i].X;
                double y = offsets[i].Y;
                double z = offsets[i].Z;
                if (!(ignorelist.Contains(i)) && (Math.Abs(x) >= accuracy || Math.Abs(y) >= accuracy || Math.Abs(z) >= accuracy))
                    morphList.Add(new VertexDisplacement((short)-Math.Ceiling(x * scale), (short)-Math.Ceiling(y * scale), (short)-Math.Ceiling(z * scale)));
                else
                {
                    morphList.Add(new VertexDisplacement(0, 0, 0));
                }
            }
            return morphList;
        }

        public virtual List<Triple<double, double, double>> CalculateOffsets(List<VertexPosition> target, List<VertexPosition> reference)
        {
            List<Triple<double, double, double>> ret = new List<Triple<double, double, double>>();
            for (int i = 0; i < target.Count; i++)
            {
                ret.Add(new Triple<double, double, double>(target[i].X - reference[i].X, target[i].Y - reference[i].Y, target[i].Z - reference[i].Z));
            }
            return ret;
        }
    }
}
