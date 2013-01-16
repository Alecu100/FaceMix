using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using FaceMix.Core;

namespace FaceMix.Base
{
    public class TRIMorphData : List<VertexDisplacement>
    {
        private int nameSize;
        private string name;
        private byte scaleMinX;
        private byte scaleMinY;
        private byte scaleMinZ;
        private byte scaleMult;

        public int NameSize { get { return this.nameSize; } set { this.nameSize = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public byte ScaleMinX { get { return this.scaleMinX; } set { this.scaleMinX = value; } }
        public byte ScaleMinY { get { return this.scaleMinY; } set { this.scaleMinY = value; } }
        public byte ScaleMinZ { get { return this.scaleMinZ; } set { this.scaleMinZ = value; } }
        public byte ScaleMult { get { return this.scaleMult; } set { this.scaleMult = value; } }

        public TRIMorphData()
            : base()
        {
            this.nameSize = 0;
            this.name = "";
            this.scaleMinX = 0;
            this.scaleMinY = 0;
            this.scaleMinZ = 0;
            this.scaleMult = 0;
        }

        public TRIMorphData(TRIMorphData morph) 
            : base()
        {
            this.nameSize = morph.nameSize;
            this.name = morph.name.Clone() as string;
            this.scaleMinX = morph.scaleMinX;
            this.scaleMinY = morph.scaleMinY;
            this.scaleMinZ = morph.scaleMinZ;
            this.scaleMult = morph.scaleMult;
            foreach (VertexDisplacement data in morph)
            {
                this.Add(data);
            }
        }

        public TRIMorphData(BinaryReader reader, int size) 
             : base()
        {
            this.nameSize = reader.ReadInt32();
            byte[] bytes = reader.ReadBytes(this.nameSize);
            this.name = TRIFile.BytesToString(bytes);
            this.scaleMinX = reader.ReadByte();
            this.scaleMinY = reader.ReadByte();
            this.scaleMinZ = reader.ReadByte();
            this.scaleMult = reader.ReadByte();
            for (int i = 0; i < size; i++)
            {
                VertexDisplacement vert = new VertexDisplacement(reader);
                this.Add(vert);
            }
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(this.nameSize);
            writer.Write(TRIFile.StringToBytes(this.name));
            writer.Write(this.scaleMinX);
            writer.Write(this.scaleMinY);
            writer.Write(this.scaleMinZ);
            writer.Write(this.scaleMult);
            foreach(VertexDisplacement vert in this)
            {
                vert.Write(writer);
            }
        }
    }
}
