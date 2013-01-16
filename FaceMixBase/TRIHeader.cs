using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FaceMix.Base
{
    public class TRIHeader
    {
        private string version;
        private int vertexCount;
        private int polytriCount;
        private int polyquadCount;
        private int unknown2;
        private int unknown3;
        private int uvVertexCount;
        private int flags;
        private int morphCount;
        private int modifierCount;
        private int modVertexCount;
        private int unknown7;
        private int unknown8;
        private int unknown9;
        private int unknown10;

        public string Identifier { get { return "FR"; } }
        public string FileType { get { return "TRI"; } }

        public string Version { get { return this.version; } set { this.version = value; } }
        public int VertexCount { get { return this.vertexCount; } set { this.vertexCount = value; } }
        public int PolytriCount { get { return this.polytriCount; } set { this.polytriCount = value; } }
        public int PolyQuadCount { get { return this.polyquadCount; } set { this.polyquadCount = value; } }
        public int Unknown2 { get { return this.unknown2; } set { this.unknown2 = value; } }
        public int Unknown3 { get { return this.unknown3; } set { this.unknown3 = value; } }
        public int UvVerticeCount { get { return this.uvVertexCount; } set { this.uvVertexCount = value; } }
        public int Flags { get { return this.flags; } set { this.flags = value; } }
        public int MorphCount { get { return this.morphCount; } set { this.morphCount = value; } }
        public int ModifierCount { get { return this.modifierCount; } set { this.modifierCount = value; } }
        public int ModVertexCount { get { return this.modVertexCount; } set { this.modVertexCount = value; } }
        public int Unknown7 { get { return this.unknown7; } set { this.unknown7 = value; } }
        public int Unknown8 { get { return this.unknown8; } set { this.unknown8 = value; } }
        public int Unknown9 { get { return this.unknown9; } set { this.unknown9 = value; } }
        public int Unknown10 { get { return this.unknown10; } set { this.unknown10 = value; } }

        public TRIHeader()
        {
            this.version = "000";
            this.vertexCount = 0;
            this.polytriCount = 0;
            this.polyquadCount = 0;
            this.unknown2 = 0;
            this.unknown3 = 0;
            this.uvVertexCount = 0;
            this.flags = 0;
            this.morphCount = 0;
            this.modifierCount = 0;
            this.modVertexCount = 0;
            this.unknown7 = 0;
            this.unknown8 = 0;
            this.unknown9 = 0;
            this.unknown10 = 0;
        }

        public TRIHeader(TRIHeader header)
        {
            this.version = header.version.Clone() as string;
            this.vertexCount = header.vertexCount;
            this.polytriCount = header.polytriCount;
            this.polyquadCount = header.polyquadCount;
            this.unknown3 = header.unknown3;
            this.unknown2 = header.unknown2;
            this.uvVertexCount = header.uvVertexCount;
            this.flags = header.flags;
            this.morphCount = header.morphCount;
            this.modifierCount = header.modifierCount;
            this.modVertexCount = header.modVertexCount;
            this.unknown7 = header.unknown7;
            this.unknown8 = header.unknown8;
            this.unknown9 = header.unknown9;
            this.unknown10 = header.unknown10;
        }

        public TRIHeader(BinaryReader reader)
        {
            reader.ReadBytes(5);
            byte[] version = reader.ReadBytes(3);
            this.version = TRIFile.BytesToString(version);
            this.vertexCount = reader.ReadInt32();
            this.polytriCount = reader.ReadInt32();
            this.polyquadCount = reader.ReadInt32();
            this.unknown2 = reader.ReadInt32();
            this.unknown3 = reader.ReadInt32();
            this.uvVertexCount = reader.ReadInt32();
            this.flags = reader.ReadInt32();
            this.morphCount = reader.ReadInt32();
            this.modifierCount = reader.ReadInt32();
            this.modVertexCount = reader.ReadInt32();
            this.unknown7 = reader.ReadInt32();
            this.unknown8 = reader.ReadInt32();
            this.unknown9 = reader.ReadInt32();
            this.unknown10 = reader.ReadInt32();
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(TRIFile.StringToBytes("FR"));
            writer.Write(TRIFile.StringToBytes("TRI"));
            writer.Write(TRIFile.StringToBytes(this.version));
            writer.Write(this.vertexCount);
            writer.Write(this.polytriCount);
            writer.Write(this.polyquadCount);
            writer.Write(this.unknown2);
            writer.Write(this.unknown3);
            writer.Write(this.uvVertexCount);
            writer.Write(this.flags);
            writer.Write(this.morphCount);
            writer.Write(this.modifierCount);
            writer.Write(this.modVertexCount);
            writer.Write(this.unknown7);
            writer.Write(this.unknown8);
            writer.Write(this.unknown9);
            writer.Write(this.unknown10);
        }
    }
}
