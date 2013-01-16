using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace FaceMix.Base
{
    public class EGTFile
    {
        private List<byte> byteStream;

        public virtual byte[] ByteStream { get { return this.byteStream.ToArray(); } set { this.byteStream = new List<byte>(value); } }


        public EGTFile()
        {
            this.byteStream = new List<byte>();
        }

        public EGTFile(FileStream file)
        {
            file.Position = 0;
            BinaryReader reader = new BinaryReader(file);
            this.byteStream = new List<byte>(reader.ReadBytes((int)file.Length));
        }

        public virtual void WriteToFile(FileStream file)
        {
            BinaryWriter writer = new BinaryWriter(file);
            writer.Write(this.byteStream.ToArray());
        }
    }
}
