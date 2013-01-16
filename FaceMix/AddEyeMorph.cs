using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using FaceMix.Base;

namespace FaceMix
{
    [Modifier("Add Eye Morph")]
    public class AddEyeMorph : AbstractModifier
    {
        private AddEyeMorphControl menu;

        private string modifierName;

        private List<int> vertexIndexes;

        private bool autodetect;

        private HeadFile referenceFile;

        private HeadFile targetFile;
        
        public override event AbstractModifier.Ready WhenReady;

        private bool applied;

        public AddEyeMorph()
        {
            this.menu = new AddEyeMorphControl();
            this.menu.openVertexIndexesButton.Click += new EventHandler(openVertexIndexesButton_Click);
            this.menu.openReferenceFileButton.Click += new EventHandler(openReferenceFileButton_Click);
            this.menu.applyButton.Click += new EventHandler(applyButton_Click);
            this.menu.radioButton1.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);
            this.menu.radioButton2.CheckedChanged += new EventHandler(radioButton2_CheckedChanged);
            this.autodetect = false;
            this.applied = false;
            this.targetFile = null;
            this.referenceFile = null;
        }

        void applyButton_Click(object sender, EventArgs e)
        {
            if (this.WhenReady != null)
                this.WhenReady(this, new EventArgs());
        }

        void openReferenceFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Nif Files (*.nif)|*.nif|" + "EGM Files (*.egm)|*.egm|" + "TRI Files (*.tri)|*.tri|" + "All files (*.*)|*.*";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    HeadFile nifFile = new HeadFile(open.FileName);
                    if (nifFile.TRI.Header.VertexCount == this.targetFile.TRI.Header.VertexCount)
                    {
                        this.referenceFile = nifFile;
                        if (this.autodetect == true)
                        {
                            this.AutoDetectVertices();
                        }
                    }              
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.menu.radioButton2.Checked == true)
            {
                this.autodetect = true;
                if (this.referenceFile != null && this.targetFile != null)
                    this.AutoDetectVertices();
            }
        }

        void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.menu.radioButton1.Checked == true)
            {
                this.autodetect = false;
                this.menu.openVertexIndexesButton.Enabled = true;
            }
        }

        void AutoDetectVertices()
        {
            if (this.referenceFile == null)
                return;
            if (this.targetFile == null)
                return;
            if (this.targetFile.TRI.Header.VertexCount != this.referenceFile.TRI.Header.VertexCount)
            {
                MessageBox.Show("Target file and reference file have different vertex count");
                return;
            }
            List<int> buf = new List<int>();
            float treshold = (float)this.menu.tresholdUpDown.Value;
            for (int i = 0; i < this.targetFile.TRI.Header.VertexCount; i++)
            {
                if (Math.Abs(this.referenceFile.TRI.Vertices[i].X - this.targetFile.TRI.Vertices[i].X) >= treshold ||
                    Math.Abs(this.referenceFile.TRI.Vertices[i].Y - this.targetFile.TRI.Vertices[i].Y) >= treshold ||
                    Math.Abs(this.referenceFile.TRI.Vertices[i].Z - this.targetFile.TRI.Vertices[i].Z) >= treshold)
                    buf.Add(i);
            }
            this.vertexIndexes = buf;
            StringBuilder bld = new StringBuilder();
            foreach (int nr in buf)
            {
                bld.Append(nr.ToString() + " , ");
            }
            this.menu.vertexIndexesTextBox.Text = bld.ToString();
        }

        void openVertexIndexesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text Files (*.txt)|*.TXT|" + "All files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(new FileStream(open.FileName, FileMode.Open));
                string text = reader.ReadToEnd().Replace("\r", "");
                string[] result = text.Split(new char[] { '\n', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                List<int> buff = new List<int>();
                //bool warning = false;
                foreach (string str in result)
                {
                    try
                    {
                        buff.Add(int.Parse(str));
                    }
                    catch (Exception)
                    {
                        //warning = true;
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
                this.vertexIndexes = buff;
                StringBuilder bld = new StringBuilder();
                foreach (int nr in buff)
                {
                    bld.Append(nr.ToString() + " , ");
                }
                this.menu.vertexIndexesTextBox.Text = bld.ToString();
            }
        }

        public override string Name
        {
            get { return "Add Eye Morph"; }
        }

        public override HeadFile Apply(HeadFile target)
        {
            throw new NotImplementedException();
        }

        public override UserControl Menu
        {
            get { return this.menu; }
        }

        public override string Properties
        {
            get { return "Modifier Name: " + this.modifierName +  ",  Vertex Count: " + this.vertexIndexes.Count.ToString(); }
        }

        public override ListViewItem ToListViewItem(int index)
        {
            if (this.applied == true)
            {
                ListViewItem ret = new ListViewItem(index.ToString());
                ret.SubItems.Add("Add Eye Morph");
                ret.SubItems.Add("Modifier Name: " + this.modifierName.Substring(0,this.modifierName.Length - 1) + ",  Vertex Count: " + this.vertexIndexes.Count.ToString());
                return ret;
            }
            else
            {
                ListViewItem ret = new ListViewItem(index.ToString());
                ret.SubItems.Add("Add Eye Morph");
                ret.SubItems.Add("Modifier Name: " + "Not applied " + ",  Vertex Count: 0");
                return ret;
            }
        }

        public override HeadFile Apply()
        {
            if (this.targetFile == null)
            {
                //MessageBox.Show("No target file");
                return this.targetFile;
            }
            if (this.referenceFile == null)
            {
                //MessageBox.Show("No reference file");
                return this.targetFile;
            }
            if (this.vertexIndexes == null || this.vertexIndexes.Count == 0)
            {
                //MessageBox.Show("No vertex indexes");
                return this.targetFile;
            }
            HeadFile ret = new HeadFile(this.targetFile);
            ret.EGM.Append(this.vertexIndexes, this.referenceFile.EGM);
            StringBuilder bld = new StringBuilder(this.menu.nameTextBox.Text);
            bld.Append("\0");
            this.modifierName = bld.ToString();
            ret.TRI.AppendModifier(this.vertexIndexes, this.referenceFile.TRI, bld.ToString());
            this.applied = true;
            return ret;
        }

        public override HeadFile Target
        {
            get
            {
                return this.targetFile;
            }
            set
            {
                this.targetFile = value;
                if (this.autodetect == true)
                {
                    this.AutoDetectVertices();
                }
            }
        }

        public override bool Applied
        {
            get { return this.applied; }
        }
    }
}
