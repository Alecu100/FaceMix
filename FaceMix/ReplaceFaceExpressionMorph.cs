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
    [Modifier("Replace Face Expression Morph")]
    public class ReplaceFaceExpressionMorph : AbstractMorphModifier
    {
        public override event AbstractModifier.Ready WhenReady;

        private ReplaceFaceExpressionMorphControl menu;

        private HeadFile target;

        private bool applied;

        private MeshBase reference;

        private List<int> ignoreList;

        private string targetExpression;

        private double accuracy;

        public ReplaceFaceExpressionMorph()
        {
            this.menu = new ReplaceFaceExpressionMorphControl();
            this.ignoreList = new List<int>();
            this.menu.openOBJFileButton.Click += new EventHandler(openOBJFileButton_Click);
            this.menu.openIgnoreListButton.Click += new EventHandler(openIgnoreListButton_Click);
            this.menu.applyButton.Click += new EventHandler(applyButton_Click);
            this.menu.clearIgnoreListButton.Click += new EventHandler(clearIgnoreListButton_Click);
            this.menu.targetMorphComboBox.TextChanged += new EventHandler(targetMorphComboBox_TextChanged);
            this.menu.accuracyNumericUpDown.ValueChanged += new EventHandler(accuracyNumericUpDown_ValueChanged);
            this.applied = false;
            this.accuracy = (double)this.menu.accuracyNumericUpDown.Value;
            this.targetExpression = "";
        }

        void accuracyNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.accuracy = (double)this.menu.accuracyNumericUpDown.Value;
        }

        void targetMorphComboBox_TextChanged(object sender, EventArgs e)
        {
            this.targetExpression = this.menu.targetMorphComboBox.Text;
        }

        void clearIgnoreListButton_Click(object sender, EventArgs e)
        {
            this.ignoreList.Clear();
            this.menu.ignoreListTextBox.Clear();
        }

        void applyButton_Click(object sender, EventArgs e)
        {
            if (this.WhenReady != null)
                this.WhenReady(this, new EventArgs());
        }

        void openIgnoreListButton_Click(object sender, EventArgs e)
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

        void openOBJFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "OBJ Files (*.obj)|*.OBJ|" + "All files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (open.FileName.ToLower().EndsWith(".obj"))
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

        public override string Name
        {
            get { return "Replace Face Expression Morph"; }
        }

        public override HeadFile Apply()
        {
            if (this.reference == null || this.targetExpression == null)
                return this.target;
            if (this.reference.Vertices.Count != this.target.TRI.Header.VertexCount)
                return this.target;
            if (this.targetExpression.Length < 1)
                return this.target;
            List<VertexDisplacement> morphList = this.CalculateDisplacements(this.target.TRI.Vertices, this.reference.Vertices, this.ignoreList, this.accuracy);
            HeadFile ret = new HeadFile(this.target);
            try
            {
                foreach (TRIMorphData morph in ret.TRI.Morphs)
                {
                    if(morph.Name.StartsWith(this.targetExpression))
                    {
                        for(int i = 0;i < ret.TRI.Header.VertexCount; i++)
                            morph[i] = morphList[i];
                        break;
                    }
                }
            }
            catch (Exception)
            {
                return this.target;
            }
            this.applied = true;
            return ret;
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
                ret.SubItems.Add("Replace Face Expression Morph");
                ret.SubItems.Add("Target expression: Not Applied");
            }
            else
            {
                ret.SubItems.Add("Replace Face Expression Morph");
                ret.SubItems.Add("Target expression: " + this.targetExpression);
            }
            return ret;
            throw new NotImplementedException();
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
                foreach (TRIMorphData morph in this.target.TRI.Morphs)
                {
                    this.menu.targetMorphComboBox.Items.Add(morph.Name);
                }
            }
        }

        public override bool Applied
        {
            get { return this.applied; }
        }

        public override string Properties
        {
            get 
            {
                if (this.applied == false)
                    return "Target expression: Not applied";
                else
                {
                    return "Target expression: " + this.targetExpression;
                }
            }
        }
    }
}
