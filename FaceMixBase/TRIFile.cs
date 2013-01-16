using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using FaceMix.Core;

namespace FaceMix.Base
{
    public class TRIFile
    {
        public static byte[] StringToBytes(string text)
        {
            byte[] ret = new byte[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                ret[i] = BitConverter.GetBytes(text[i])[0];
            }
            return ret;
        }

        public static string BytesToString(byte[] bytes)
        {
            byte[] ch = new byte[2];
            StringBuilder bld = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                ch[0] = bytes[i];
                bld.Append(BitConverter.ToChar(ch, 0));
            }
            return bld.ToString();
        }

        private TRIHeader header;
        private List<VertexPosition> vertices;
        private List<VertexPosition> modVertices;
        private List<TriangleFace> triFaces;
        private List<QuadFace> quadFaces;
        private List<UvVertexPosition> uvVertices;
        private List<UvTriangleFace> uvTriFaces;
        private List<TRIMorphData> morphs;
        private List<TRIModifierData> modifiers;

        public TRIHeader Header { get { return this.header; } set { this.header = value; } }
        public List<VertexPosition> Vertices { get { return this.vertices; } set { this.vertices = value; } }
        public List<VertexPosition> ModeVertices { get { return this.modVertices; } set { this.modVertices = value; } }
        public List<TriangleFace> TriFaces { get { return this.triFaces; } set { this.triFaces = value; } }
        public List<QuadFace> QuadFaces { get { return this.quadFaces; } set { this.quadFaces = value; } }
        public List<UvVertexPosition> UvVertices { get { return this.uvVertices; } set { this.uvVertices = value; } }
        public List<UvTriangleFace> UvFaces { get { return this.uvTriFaces; } set { this.uvTriFaces = value; } }
        public List<TRIMorphData> Morphs { get { return this.morphs; } set { this.morphs = value; } }
        public List<TRIModifierData> Modifiers { get { return this.modifiers; } set { this.modifiers = value; } }

        public TRIFile()
        {
            this.header = new TRIHeader();
            this.vertices = new List<VertexPosition>();
            this.modVertices = new List<VertexPosition>();
            this.triFaces = new List<TriangleFace>();
            this.quadFaces = new List<QuadFace>();
            this.uvVertices = new List<UvVertexPosition>();
            this.uvTriFaces = new List<UvTriangleFace>();
            this.morphs = new List<TRIMorphData>();
            this.modifiers = new List<TRIModifierData>();
        }

        public TRIFile(TRIFile file)
        {
            this.header = new TRIHeader(file.header);

            this.vertices = new List<VertexPosition>();
            foreach (VertexPosition data in file.vertices)
            {
                this.vertices.Add(data);
            }

            if (this.header.ModVertexCount > 0)
            {
                this.modVertices = new List<VertexPosition>();
                foreach (VertexPosition data in file.modVertices)
                {
                    this.modVertices.Add(data);
                }
            }

            this.triFaces = new List<TriangleFace>();
            foreach (TriangleFace face in file.triFaces)
            {
                this.triFaces.Add(face);
            }

            this.quadFaces = new List<QuadFace>();
            foreach (QuadFace face in file.quadFaces)
            {
                this.quadFaces.Add(face);
            }

            this.uvVertices = new List<UvVertexPosition>();
            foreach (UvVertexPosition vert in file.uvVertices)
            {
                this.uvVertices.Add(vert);
            }

            this.uvTriFaces = new List<UvTriangleFace>();
            foreach (UvTriangleFace uvFace in file.uvTriFaces)
            {
                this.uvTriFaces.Add(uvFace);
            }

            this.morphs = new List<TRIMorphData>();
            foreach (TRIMorphData morph in file.morphs)
            {
                this.morphs.Add(new TRIMorphData(morph));
            }

            if (file.header.ModifierCount > 0)
            {
                this.modifiers = new List<TRIModifierData>();
                foreach (TRIModifierData mod in file.modifiers)
                {
                    this.modifiers.Add(new TRIModifierData(mod));
                }
            }
        }

        public TRIFile(FileStream stream)
        {
            BinaryReader reader = new BinaryReader(stream);
            this.header = new TRIHeader(reader);

            this.vertices = new List<VertexPosition>();
            for (int i = 0; i < this.header.VertexCount; i++)
            {
                this.vertices.Add(new VertexPosition(reader));
            }

            if (this.header.ModVertexCount > 0)
            {
                this.modVertices = new List<VertexPosition>();
                for (int i = 0; i < this.header.ModVertexCount; i++)
                {
                    this.modVertices.Add(new VertexPosition(reader));
                }
            }

            this.triFaces = new List<TriangleFace>();
            for (int i = 0; i < this.header.PolytriCount; i++)
                this.triFaces.Add(new TriangleFace(reader));

            this.quadFaces = new List<QuadFace>();
            for (int i = 0; i < this.header.PolyQuadCount; i++)
                this.quadFaces.Add(new QuadFace(reader));

            this.uvVertices = new List<UvVertexPosition>();
            for (int i = 0; i < this.header.UvVerticeCount; i++)
            {
                this.uvVertices.Add(new UvVertexPosition(reader));
            }

            this.uvTriFaces = new List<UvTriangleFace>();
            for (int i = 0; i < this.header.PolytriCount; i++)
            {
                this.uvTriFaces.Add(new UvTriangleFace(reader));
            }

            this.morphs = new List<TRIMorphData>();
            for (int i = 0; i < this.header.MorphCount; i++)
            {
                this.morphs.Add(new TRIMorphData(reader, this.header.VertexCount));
            }

            if (this.header.ModifierCount > 0)
            {
                this.modifiers = new List<TRIModifierData>();
                for (int i = 0; i < this.header.ModifierCount; i++)
                    this.modifiers.Add(new TRIModifierData(reader));
            }
        }

        public void WriteToFile(FileStream file)
        {
            BinaryWriter writer = new BinaryWriter(file);
            this.header.Write(writer);

            foreach (VertexPosition vert in this.vertices)
            {
                vert.Write(writer);
            }

            if(this.header.ModVertexCount > 0)
                foreach (VertexPosition vert in this.modVertices)
                {
                    vert.Write(writer);
                }

            foreach (TriangleFace face in this.triFaces)
            {
                face.Write(writer);
            }

            foreach (QuadFace face in this.quadFaces)
            {
                face.Write(writer);
            }

            foreach (UvVertexPosition uvVert in this.uvVertices)
            {
                uvVert.Write(writer);
            }

            foreach (UvTriangleFace uvFace in this.uvTriFaces)
            {
                uvFace.Write(writer);
            }

            foreach (TRIMorphData morph in this.morphs)
            {
                morph.Write(writer);
            }

            if(this.header.ModifierCount > 0 )
                foreach (TRIModifierData mod in this.modifiers)
                {
                    mod.Write(writer);
                }
        }

        public void AppendModifier(List<int> vertexIndexes, TRIFile reference, string name)
        {
            if (this.header.ModVertexCount <= 0)
                this.modVertices = new List<VertexPosition>();
            this.header.ModVertexCount += vertexIndexes.Count;
            foreach (int vertIndex in vertexIndexes)
            {
                this.modVertices.Add(reference.vertices[vertIndex]);
            }
            TRIModifierData mod = new TRIModifierData();
            mod.NameSize = name.Length;
            mod.Name = name.Clone() as string;
            mod.DataSize = vertexIndexes.Count;
            foreach (int vertIndex in vertexIndexes)
            {
                mod.Add(vertIndex);
            }
            if (this.header.ModifierCount <= 0)
                this.modifiers = new List<TRIModifierData>();
            this.modifiers.Add(mod);
            this.header.ModifierCount += 1;
        }
    }
}
