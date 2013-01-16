using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using FaceMix.Base;
using FaceMix.Core;
using FaceMix.Wrappers;

namespace FaceMix
{
    [Modifier("Replace FaceGen Morph")]
    public class ReplaceFaceGenMorph : AbstractMorphModifier
    {
        private ReplaceFaceGenMorphcontrol menu;

        private HeadFile target;

        private MeshBase reference;
        
        public override event AbstractModifier.Ready WhenReady;

        private bool applied;

        private string targetMorph;

        private double accuracy;

        private List<int> ignoreList;

        public ReplaceFaceGenMorph()
        {
            this.menu = new ReplaceFaceGenMorphcontrol();
            this.menu.targetMorphComboBox.TextChanged += new EventHandler(targetMorphComboBox_TextChanged);
            this.menu.accuracyNumericUpDown.ValueChanged += new EventHandler(accuracyNumericUpDown_ValueChanged);
            this.menu.openOBJFileButton.Click += new EventHandler(openOBJFileButton_Click);
            this.menu.applyButton.Click += new EventHandler(applyButton_Click);
            this.menu.openIgnoreListbutton.Click += new EventHandler(openIgnoreListbutton_Click);
            this.menu.clearIgnoreListButton.Click += new EventHandler(clearIgnoreListButton_Click);
            this.applied = false;
            this.accuracy = (double)this.menu.accuracyNumericUpDown.Value;
            this.ignoreList = new List<int>();
        }

        void clearIgnoreListButton_Click(object sender, EventArgs e)
        {
            this.ignoreList.Clear();
            this.menu.ignoreListTextBox.Clear();
        }

        void openIgnoreListbutton_Click(object sender, EventArgs e)
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
                this.ignoreList.AddRange(buff);
                StringBuilder bld = new StringBuilder();
                foreach (int nr in buff)
                {
                    bld.Append(nr.ToString() + " , ");
                }
                this.menu.ignoreListTextBox.Text = bld.ToString();
            }
            
        }

        void applyButton_Click(object sender, EventArgs e)
        {
            if(this.WhenReady != null)
                this.WhenReady(this, new EventArgs());
        }

        void openOBJFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "OBJ Files (*.obj)|*.obj|" + "Nif Files (*.nif)|*.nif|" + "All files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if(open.FileName.ToLower().EndsWith(".obj"))
                    {
                        FileStream stream = new FileStream(open.FileName, FileMode.Open);
                        OBJFile objFile = new OBJFile(stream);
                        this.reference = objFile.Mesh;
                        stream.Close();
                        this.menu.referenceTextBox.Text = open.FileName;
                        return;
                    }
                    if (open.FileName.ToLower().EndsWith(".nif"))
                    {
                        FileStream stream = new FileStream(open.FileName, FileMode.Open);
                        NifFile nifFile = new NifFile(stream);
                        this.reference = nifFile.MeshData[0];
                        stream.Close();
                        this.menu.referenceTextBox.Text = open.FileName;
                        return;
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        void accuracyNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.accuracy = (double)this.menu.accuracyNumericUpDown.Value;
        }

        void targetMorphComboBox_TextChanged(object sender, EventArgs e)
        {
            this.targetMorph = this.menu.targetMorphComboBox.Text;
        }

        public override string Name
        {
            get { return "Replace FaceGen Morph"; }
        }

        public override HeadFile Apply(HeadFile target)
        {
            throw new NotImplementedException();
        }

        public override UserControl Menu
        {
            get { return this.menu; }
        }

        public override ListViewItem ToListViewItem(int index)
        {
            ListViewItem ret = new ListViewItem(index.ToString());
            if (this.applied == false)
            {
                ret.SubItems.Add("Replace FaceGen Morph");
                ret.SubItems.Add("Target morph: Not Applied");
            }
            else
            {
                ret.SubItems.Add("Replace FaceGen Morph");
                ret.SubItems.Add("Target morph: " + this.targetMorph);
            }
            return ret;
        }

        public override string Properties
        {
            get { return "Target Morph: " + this.targetMorph; }
        }

        public override HeadFile Apply()
        {
            if (this.reference == null || this.targetMorph == null)
                return this.target;
            if(this.reference.Vertices.Count != this.target.TRI.Header.VertexCount)
                return this.target;
            if(!(this.targetMorph.StartsWith("SYM") || this.targetMorph.StartsWith("ASYM")))
                return this.target;
            List<VertexDisplacement> morphList = this.CalculateDisplacements(this.target.TRI.Vertices, this.reference.Vertices, this.ignoreList, this.accuracy);
            HeadFile ret = new HeadFile(this.target);
            try
            {
                int number = int.Parse(this.targetMorph.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1]);
                if (this.targetMorph.StartsWith("SYM"))
                {
                    for (int i = 0; i < ret.TRI.Header.VertexCount; i++)
                        ret.EGM.SymMorps[number][i] = morphList[i];
                    //ret.EGM.SymMorps[number].Unknown = BitConverter.GetBytes(((float)(scale))).Reverse<byte>().ToArray<byte>();
                }
                if (this.targetMorph.StartsWith("ASYM"))
                {
                    for (int i = 0; i < ret.TRI.Header.VertexCount; i++)
                        ret.EGM.AsymMorps[number][i] = morphList[i];
                    //ret.EGM.AsymMorps[number].Unknown = BitConverter.GetBytes(((float)(scale))).Reverse<byte>().ToArray<byte>();
                }
                this.applied = true;
            }
            catch (Exception)
            {
  
            }
            return ret;
        }

        public override HeadFile Target
        {
            get
            {
                return this.target;
            }
            set
            {
                this.target = value;
                this.menu.targetMorphComboBox.Items.Clear();
                if (this.target.EGM.SymMorps != null)
                {
                    for (int i = 0; i < this.target.EGM.SymMorps.Count; i++)
                    {
                        this.menu.targetMorphComboBox.Items.Add("SYM " + i.ToString());
                    }
                }
                if (this.target.EGM.AsymMorps != null)
                {
                    for (int i = 0; i < this.target.EGM.AsymMorps.Count; i++)
                    {
                        this.menu.targetMorphComboBox.Items.Add("ASYM " + i.ToString());
                    }
                }
            }
        }

        public override bool Applied
        {
            get { return this.applied; }
        }
    }
}
