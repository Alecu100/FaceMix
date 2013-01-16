using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using FaceMix.Wrappers;


namespace FaceMix.Base
{
    public class HeadFile
    {
        public static string ReplaceExtention(string file, string newExtension)
        {
            StringBuilder bld = new StringBuilder(file);
            int i = bld.Length - 1;
            while (bld[i] != '.' && bld.Length > 0)
            {
                bld.Remove(i, 1);
                i--;
            }
            bld.Append(newExtension);
            if (newExtension == "" && i != file.Length)
                bld.Remove(bld.Length - 1, 1);
            return bld.ToString();
        }
        
        private EGMFile egm;
        private TRIFile tri;
        private NifFile nif;

        public EGMFile EGM { get { return this.egm; } set { this.egm = value; } }
        public TRIFile TRI { get { return this.tri; } set { this.tri = value; } }
        public NifFile Nif { get { return this.nif; } set { this.nif = value; } }  

        public HeadFile()
        {

        }

        public HeadFile(HeadFile file)
        {
            this.tri = new TRIFile(file.TRI);
            this.egm = new EGMFile(file.EGM);
            this.nif = new NifFile(file.Nif);
        }

        public HeadFile(string fileName)
        {
            if (fileName.ToLower().EndsWith("egm"))
            {
                FileStream stream = new FileStream(fileName, FileMode.Open);
                this.egm = new EGMFile(stream);
                stream.Close();
                stream = new FileStream(HeadFile.ReplaceExtention(fileName, "tri"),FileMode.Open);
                this.tri = new TRIFile(stream);
                stream.Close();
                stream = new FileStream(HeadFile.ReplaceExtention(fileName, "nif"), FileMode.Open);
                this.nif = new NifFile(stream);
                stream.Close();
            }
            if (fileName.ToLower().EndsWith("tri"))
            {
                FileStream stream = new FileStream(fileName, FileMode.Open);
                this.tri = new TRIFile(stream);
                stream.Close();
                stream = new FileStream(HeadFile.ReplaceExtention(fileName, "egm"), FileMode.Open);
                this.egm = new EGMFile(stream);
                stream.Close();
                stream = new FileStream(HeadFile.ReplaceExtention(fileName, "nif"), FileMode.Open);
                this.nif = new NifFile(stream);
                stream.Close();
            }
            if (fileName.ToLower().EndsWith("nif"))
            {
                FileStream stream = new FileStream(fileName, FileMode.Open);
                this.nif = new NifFile(stream);
                stream.Close();
                stream = new FileStream(HeadFile.ReplaceExtention(fileName, "egm"), FileMode.Open);
                this.egm = new EGMFile(stream);
                stream.Close();
                stream = new FileStream(HeadFile.ReplaceExtention(fileName, "tri"), FileMode.Open);
                this.tri = new TRIFile(stream);
                stream.Close();
            }
        }

        public void WriteToFile(string fileName)
        {
            if (fileName.ToLower().EndsWith("egm"))
            {
                FileStream stream = new FileStream(fileName, FileMode.Create);
                this.egm.WriteToFile(stream);
                stream.Close();
                stream = new FileStream(HeadFile.ReplaceExtention(fileName, "tri"), FileMode.Create);
                this.tri.WriteToFile(stream);
                stream.Close();
                stream = new FileStream(HeadFile.ReplaceExtention(fileName, "nif"), FileMode.Create);
                this.nif.WriteToFile(stream);
                stream.Close();
            }
            if (fileName.ToLower().EndsWith("tri"))
            {
                FileStream stream = new FileStream(fileName, FileMode.Create);
                this.tri.WriteToFile(stream);
                stream.Close();
                stream = new FileStream(HeadFile.ReplaceExtention(fileName, "egm"), FileMode.Create);
                this.egm.WriteToFile(stream);
                stream.Close();
                stream = new FileStream(HeadFile.ReplaceExtention(fileName, "nif"), FileMode.Create);
                this.nif.WriteToFile(stream);
                stream.Close();
            }
            if (fileName.ToLower().EndsWith("nif"))
            {
                FileStream stream = new FileStream(fileName, FileMode.Create);
                this.nif.WriteToFile(stream);
                stream.Close();
                stream = new FileStream(HeadFile.ReplaceExtention(fileName, "egm"), FileMode.Create);
                this.egm.WriteToFile(stream);
                stream.Close();
                stream = new FileStream(HeadFile.ReplaceExtention(fileName, "tri"), FileMode.Create);
                this.tri.WriteToFile(stream);
                stream.Close();
            }
        }
    }
}
