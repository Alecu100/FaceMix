using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using FaceMix.Core;

namespace FaceMix.Base
{
    public class EGMMorphset : List<VertexDisplacement>
    {
        private byte[] unknown;

        public byte[] Unknown { get { return this.unknown; } set { this.unknown = value; } }

        public EGMMorphset()
            : base()
        {
        }

        public EGMMorphset(EGMMorphset morph)
            : base()
        {
            this.unknown = new byte[4];
            for (int i = 0; i < 4; i++)
                this.unknown[i] = morph.unknown[i];
            foreach (VertexDisplacement data in morph)
            {
                this.Add(data);
            }
        }

        public void Write(BinaryWriter writer)
        {
            foreach (byte b in this.unknown)
            {
                writer.Write(b);
            }
            foreach (VertexDisplacement data in this)
            {
                writer.Write(data.X);
                writer.Write(data.Y);
                writer.Write(data.Z);
            }
        }
    }
}
