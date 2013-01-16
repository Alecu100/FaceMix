using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using FaceMix.Core;

namespace FaceMix.Base
{
    public class EGMFile
    {
        private string version;
        private int verticeCount;
        private int symSize;
        private int asymSize;
        private uint dateStamp;
        private int[] unknown;
        private List<EGMMorphset> symMorphs;
        private List<EGMMorphset> asymMorphs;

        public string Indentifier { get { return "FR"; } }
        public string FileType { get { return "EGM"; } }
        public string Version { get { return this.version; } set { this.version = value; } }
        public int VerticeCount { get { return this.verticeCount; } set { this.verticeCount = value; } }
        public int SymSize { get { return this.symSize; } set { this.symSize = value; } }
        public int AsymSize { get { return this.asymSize; } set { this.asymSize = value; } }
        public uint DateStamp { get { return this.dateStamp; } set { this.dateStamp = value; } }
        public int[] Unknown { get { return this.unknown; } set { this.unknown = value; } }
        public List<EGMMorphset> SymMorps { get { return this.symMorphs; } set { this.symMorphs = value; } }
        public List<EGMMorphset> AsymMorps { get { return this.asymMorphs; } set { this.asymMorphs = value; } }

        public EGMFile()
        {
            this.version = "000";
            this.verticeCount = 0;
            this.symSize = 0;
            this.asymSize = 0;
            this.dateStamp = 0;
            this.unknown = new int[10];
            this.symMorphs = new List<EGMMorphset>();
            this.asymMorphs = new List<EGMMorphset>();
        }

        public EGMFile(EGMFile file)
        {
            this.version = file.version.Clone() as string;
            this.verticeCount = file.verticeCount;
            this.symSize = file.symSize;
            this.asymSize = file.asymSize;
            this.dateStamp = file.dateStamp;
            this.unknown = new int[file.unknown.Length];
            for (int i = 0; i < file.unknown.Length; i++)
                this.unknown[i] = file.unknown[i];

            this.symMorphs = new List<EGMMorphset>();
            foreach (EGMMorphset morph in file.SymMorps)
            {
                this.symMorphs.Add(new EGMMorphset(morph));
            }

            this.asymMorphs = new List<EGMMorphset>();
            foreach (EGMMorphset morph in file.asymMorphs)
            {
                this.asymMorphs.Add(new EGMMorphset(morph));
            }

        }

        public EGMFile(FileStream stream)
        {
            BinaryReader reader = new BinaryReader(stream);
            reader.ReadBytes(5);
            byte[] bytes = new byte[2];

            bytes[0] = reader.ReadByte();
            StringBuilder bld = new StringBuilder();
            bld.Append(BitConverter.ToChar(bytes, 0));
            bytes[0] = reader.ReadByte();
            bld.Append(BitConverter.ToChar(bytes, 0));
            bytes[0] = reader.ReadByte();
            bld.Append(BitConverter.ToChar(bytes, 0));
            this.version = bld.ToString();

            this.verticeCount = reader.ReadInt32();
            this.symSize = reader.ReadInt32();
            this.asymSize = reader.ReadInt32();
            this.dateStamp = reader.ReadUInt32();

            this.unknown = new int[10];
            for (int i = 0; i < 10; i++)
                this.unknown[i] = reader.ReadInt32();

            this.symMorphs = new List<EGMMorphset>();
            for (int i = 0; i < this.symSize; i++)
            {
                EGMMorphset morph = new EGMMorphset();
                morph.Unknown = reader.ReadBytes(4);
                for (int j = 0; j < this.verticeCount; j++)
                {
                    VertexDisplacement data = new VertexDisplacement(reader);
                    morph.Add(data);
                }
                this.symMorphs.Add(morph);
            }

            this.asymMorphs = new List<EGMMorphset>();
            for (int i = 0; i < this.asymSize; i++)
            {
                EGMMorphset morph = new EGMMorphset();
                morph.Unknown = reader.ReadBytes(4);
                for (int j = 0; j < this.verticeCount; j++)
                {
                    VertexDisplacement data = new VertexDisplacement(reader);
                    morph.Add(data);
                }
                this.asymMorphs.Add(morph);
            }
        }

        public void Append(List<int> verticeIndexes,EGMFile referenceFile)
        {
            this.verticeCount += verticeIndexes.Count;
            for (int i = 0; i < this.SymSize; i++)
            {
                List<VertexDisplacement> extraData = new List<VertexDisplacement>();
                for(int j = 0;j < verticeIndexes.Count; j++)
                    extraData.Add(referenceFile.SymMorps[i][verticeIndexes[j]]);
                this.symMorphs[i].AddRange(extraData.ToArray());
            }
            for (int i = 0; i < this.AsymSize; i++)
            {
                List<VertexDisplacement> extraData = new List<VertexDisplacement>();
                for (int j = 0; j < verticeIndexes.Count; j++)
                {
                    extraData.Add(referenceFile.AsymMorps[i][verticeIndexes[j]]);
                }
                this.asymMorphs[i].AddRange(extraData.ToArray());
            }
        }

        public void WriteToFile(FileStream stream)
        {
            BinaryWriter writer = new BinaryWriter(stream);

            writer.Write(BitConverter.GetBytes('F')[0]);
            writer.Write(BitConverter.GetBytes('R')[0]);
            writer.Write(BitConverter.GetBytes('E')[0]);
            writer.Write(BitConverter.GetBytes('G')[0]);
            writer.Write(BitConverter.GetBytes('M')[0]);

            foreach (char ch in this.version)
            {
                writer.Write(BitConverter.GetBytes(ch)[0]);   
            }

            writer.Write(this.verticeCount);
            writer.Write(this.symSize);
            writer.Write(this.asymSize);
            writer.Write(this.dateStamp);

            foreach (int nr in this.unknown)
            {
                writer.Write(nr);
            }

            foreach (EGMMorphset morph in this.symMorphs)
            {
                morph.Write(writer);
            }

            foreach (EGMMorphset morph in this.asymMorphs)
            {
                morph.Write(writer);
            }
        }
    }
}
