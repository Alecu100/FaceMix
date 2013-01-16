using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.IO;

namespace FaceMix.Core
{
    public struct VertexPosition
    {
        private float x;
        private float y;
        private float z;

        public float X { get { return this.x; } set { this.x = value; } }
        public float Y { get { return this.y; } set { this.y = value; } }
        public float Z { get { return this.z; } set { this.z = value; } }

        public VertexPosition(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public VertexPosition(BinaryReader reader)
        {
            this.x = reader.ReadSingle();
            this.y = reader.ReadSingle();
            this.z = reader.ReadSingle();
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(this.x);
            writer.Write(this.y);
            writer.Write(this.z);
        }
    }

    public struct TriangleFace
    {
        private int a;
        private int b;
        private int c;

        public int A { get { return this.a; } set { this.a = value; } }
        public int B { get { return this.b; } set { this.b = value; } }
        public int C { get { return this.c; } set { this.c = value; } }

        public TriangleFace(BinaryReader reader)
        {
            this.a = reader.ReadInt32();
            this.b = reader.ReadInt32();
            this.c = reader.ReadInt32();
        }

        public TriangleFace(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(this.a);
            writer.Write(this.b);
            writer.Write(this.c);
        }

    }

    public struct QuadFace
    {
        private int a;
        private int b;
        private int c;
        private int d;

        public int A { get { return this.a; } set { this.a = value; } }
        public int B { get { return this.b; } set { this.b = value; } }
        public int C { get { return this.c; } set { this.c = value; } }
        public int D { get { return this.d; } set { this.d = value; } }

        public QuadFace(BinaryReader reader)
        {
            this.a = reader.ReadInt32();
            this.b = reader.ReadInt32();
            this.c = reader.ReadInt32();
            this.d = reader.ReadInt32();
        }

        public QuadFace(int a,int b,int c,int d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(this.a);
            writer.Write(this.b);
            writer.Write(this.c);
            writer.Write(this.d);
        }
    }

    public struct UvVertexPosition
    {
        private float u;
        private float v;

        public float U { get { return this.u; } set { this.u = value; } }
        public float V { get { return this.v; } set { this.v = value; } }

        public UvVertexPosition(BinaryReader reader)
        {
            this.u = reader.ReadSingle();
            this.v = reader.ReadSingle();
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(this.u);
            writer.Write(this.v);
        }
    }

    public struct UvTriangleFace
    {
        private int a;
        private int b;
        private int c;

        public UvTriangleFace(BinaryReader reader)
        {
            this.a = reader.ReadInt32();
            this.b = reader.ReadInt32();
            this.c = reader.ReadInt32();
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(this.a);
            writer.Write(this.b);
            writer.Write(this.c);
        }
    }

    public struct VertexDisplacement
    {
        private short x;
        private short y;
        private short z;

        public short X { get { return this.x; } set { this.x = value; } }
        public short Y { get { return this.y; } set { this.y = value; } }
        public short Z { get { return this.z; } set { this.z = value; } }

        public VertexDisplacement(BinaryReader reader)
        {
            this.x = reader.ReadInt16();
            this.y = reader.ReadInt16();
            this.z = reader.ReadInt16();
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(this.x);
            writer.Write(this.y);
            writer.Write(this.z);
        }

        public VertexDisplacement(short x, short y, short z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    public struct Triple<Type1, Type2, Type3>
    {
        Type1 a;
        Type2 b;
        Type3 c;

        public Type1 A { get { return this.a; } set { this.a = value; } }
        public Type2 B { get { return this.b; } set { this.b = value; } }
        public Type3 C { get { return this.c; } set { this.c = value; } }

        public Type1 X { get { return this.a; } set { this.a = value; } }
        public Type2 Y { get { return this.b; } set { this.b = value; } }
        public Type3 Z { get { return this.c; } set { this.c = value; } }


        public Triple(Type1 a, Type2 b, Type3 c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

    }
}