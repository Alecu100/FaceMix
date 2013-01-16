using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FaceMix.Base
{
    public class TRIModifierData : List<int>
    {
        private int nameSize;
        private string name;
        private int dataSize;

        public int NameSize { get { return this.nameSize; } set { this.nameSize = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public int DataSize { get { return this.dataSize; } set { this.dataSize = value; } }

        public TRIModifierData()
            : base()
        {
            this.nameSize = 0;
            this.name = "";
            this.dataSize = 0;
        }

        public TRIModifierData(TRIModifierData mod) 
            : base()
        {
            this.nameSize = mod.nameSize;
            this.name = mod.name.Clone() as string;
            this.dataSize = mod.dataSize;
            foreach (int nr in mod)
            {
                this.Add(nr);
            }
        }

        public TRIModifierData(BinaryReader reader) :
            base()
        {
            this.nameSize = reader.ReadInt32();
            byte[] bytes = reader.ReadBytes(this.nameSize);
            this.name = TRIFile.BytesToString(bytes);
            this.dataSize = reader.ReadInt32();
            for (int i = 0; i < this.dataSize; i++)
            {
                this.Add(reader.ReadInt32());
            }
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(this.nameSize);
            writer.Write(TRIFile.StringToBytes(this.name));
            writer.Write(this.dataSize);
            foreach (int nr in this)
            {
                writer.Write(nr);
            }
        }

        public ListViewItem ToListViewItem(int index)
        {
            ListViewItem ret = new ListViewItem(index.ToString());
            ret.SubItems.Add(this.nameSize.ToString());
            ret.SubItems.Add(this.name);
            ret.SubItems.Add(this.dataSize.ToString());
            StringBuilder bld = new StringBuilder();
            foreach (int nr in this)
            {
                bld.Append(nr.ToString() + " ");
            }
            ret.SubItems.Add(bld.ToString());
            return ret;
        }

    }
}
