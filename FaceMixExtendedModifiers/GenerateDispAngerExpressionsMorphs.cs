using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using FaceMix.Base;
using FaceMix.Core;
using FaceMix.Wrappers;

namespace FaceMix.ExtendedModifiers
{
    [Modifier("Generate DispAnger Expressions Morphs")]
    public class GenerateDispAngerExpressionsMorphs : AbstractMorphModifier
    {
        private enum Expression { Anger40 = 0, Anger30 = 1, Anger20 = 2, Anger10 = 3, Anger0 = 4}
        private enum Morph { DispAnger1, DispAnger2, DispAnger3, DispAnger4 }

        private Dictionary<Expression, MeshBase> expressions;
        private Dictionary<Expression, Dictionary<Morph,double>> weights;
        
        public override event AbstractModifier.Ready WhenReady;

        public enum Mode { Absolute, Relative };

        private Mode mode;

        private GenerateDispAngerExpressionsMorphsControl menu;

        private HeadFile target;

        private bool applied;

        private List<int> ignoreList;

        private double accuracy;

        public GenerateDispAngerExpressionsMorphs()
        {
            this.menu = new GenerateDispAngerExpressionsMorphsControl();
            this.ignoreList = new List<int>();
            this.weights = new Dictionary<Expression, Dictionary<Morph, double>>();
            this.expressions = new Dictionary<Expression, MeshBase>();
            this.menu.openOBJFileButton.Click += new EventHandler(openOBJFileButton_Click);
            this.menu.openIgnoreListButton.Click += new EventHandler(openIgnoreListButton_Click);
            this.menu.applyButton.Click += new EventHandler(applyButton_Click);
            this.menu.clearIgnoreListButton.Click += new EventHandler(clearIgnoreListButton_Click);
            this.menu.openWeightsButton.Click += new EventHandler(openWeightsButton_Click);
            this.menu.accuracyNumericUpDown.ValueChanged += new EventHandler(accuracyNumericUpDown_ValueChanged);
            this.menu.absoluteRadioButton.CheckedChanged += new EventHandler(absoluteRadioButton_CheckedChanged);
            this.menu.relativeRadiobutton.CheckedChanged += new EventHandler(relativeRadiobutton_CheckedChanged);
            this.menu.expressionsListView.MouseDoubleClick += new MouseEventHandler(expressionsListView_MouseDoubleClick);
            for (int i = 0; i < 5; i++)
            {
                Expression exp = (Expression)i;
                ListViewItem item = new ListViewItem(exp.ToString());
                item.SubItems.Add("None");
                item.SubItems.Add("None");
                this.menu.expressionsListView.Items.Add(item);
            }
            this.applied = false;
            this.accuracy = (double)this.menu.accuracyNumericUpDown.Value;
            this.mode = Mode.Relative;
            this.menu.relativeRadiobutton.Checked = true;
            this.LoadWeights(Environment.CurrentDirectory + "\\Defaults\\DispAnger.txt");
        }

        void expressionsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = this.menu.expressionsListView.GetItemAt(e.X, e.Y);
            if (item == null)
                return;
            this.openOBJFileButton_Click(sender, e);
            
        }

        void relativeRadiobutton_CheckedChanged(object sender, EventArgs e)
        {
            this.mode = Mode.Relative;
        }

        void absoluteRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.mode = Mode.Absolute;
        }

        void openWeightsButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text Files (*.txt)|*.TXT|" + "All files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                this.LoadWeights(open.FileName);
            }
        }

        void LoadWeights(string file)
        {
            try
            {
                StreamReader reader = new StreamReader(new FileStream(file, FileMode.Open));
                string text2 = reader.ReadToEnd().Replace("\r", "");
                reader.Close();
                string text = text2.Replace(" ", "");
                string[] lines = text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<Expression, Dictionary<Morph, double>> buf = new Dictionary<Expression, Dictionary<Morph, double>>();
                foreach (string str in lines)
                {
                    string[] sub = str.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    Expression exp = (Expression)Enum.Parse(typeof(Expression), sub[0]);
                    if (buf.ContainsKey(exp))
                        return;
                    Dictionary<Morph, double> weights = new Dictionary<Morph, double>();
                    string[] sub2 = sub[1].Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string str2 in sub2)
                    {
                        string[] sub3 = str2.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                        double weight = double.Parse(sub3[0]);
                        Morph morph = (Morph)Enum.Parse(typeof(Morph), sub3[1]);
                        if (weights.ContainsKey(morph))
                            return;
                        weights.Add(morph, weight);
                    }
                    buf.Add(exp, weights);
                }
                if (buf.Count < 5)
                    return;
                this.weights = buf;
                lines = text2.Split(new char[] { '\n' });
                foreach (string str in lines)
                {
                    string[] sub = str.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    Expression exp = (Expression)Enum.Parse(typeof(Expression), sub[0]);
                    foreach (ListViewItem item in this.menu.expressionsListView.Items)
                    {
                        Expression exp2 = (Expression)Enum.Parse(typeof(Expression), item.Text);
                        if (exp2 == exp)
                        {
                            item.SubItems[1].Text = sub[1];
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        void accuracyNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.accuracy = (double)this.menu.accuracyNumericUpDown.Value;
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
            open.Filter = "OBJ Files (*.obj)|*.OBJ|" + "Nif Files (*.nif)|*.nif|" + "All files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK && this.menu.expressionsListView.SelectedItems.Count > 0)
            {
                try
                {
                    FileStream stream = new FileStream(open.FileName, FileMode.Open);
                    ListViewItem item = this.menu.expressionsListView.SelectedItems[0];
                    Expression exp = (Expression)Enum.Parse(typeof(Expression), item.Text);
                    if (this.expressions.ContainsKey(exp))
                    {
                        if (open.FileName.ToLower().EndsWith(".obj"))
                        {
                            OBJFile objFile = new OBJFile(stream);
                            MeshBase mesh = objFile.Mesh;
                            this.expressions[exp] = mesh;
                        }
                        else
                        {
                            NifFile nifFile = new NifFile(stream);
                            MeshBase mesh = nifFile.MeshData[0];
                            this.expressions[exp] = mesh;
                        }
                    }
                    else
                    {
                        if (open.FileName.ToLower().EndsWith(".obj"))
                        {
                            OBJFile objFile = new OBJFile(stream);
                            MeshBase mesh = objFile.Mesh;
                            this.expressions.Add(exp, mesh);
                        }
                        else
                        {
                            NifFile nifFile = new NifFile(stream);
                            MeshBase mesh = nifFile.MeshData[0];
                            this.expressions.Add(exp, mesh);
                        }
                    }
                    //this.reference = new OBJFile(stream);
                    item.SubItems[2].Text = open.FileName;
                    stream.Close();
                }
                catch (Exception ex)
                {

                }
            }
        }

        public override string Name
        {
            get { return "Generate DispAnger Expressions Morphs"; }
        }

        public override HeadFile Apply()
        {
            if (this.weights.Count < 5)
                return this.target;
            if (this.expressions.Count < 5)
                return this.target;
            foreach (KeyValuePair<Expression,MeshBase> keypair in this.expressions)
            {
                if (keypair.Value == null)
                    return this.target;
            }
            if (this.mode == Mode.Relative)
                return this.ApplyRelative();
            else
                return this.ApplyAbsolute();
            
        }

        private HeadFile ApplyRelative()
        {
            Dictionary<Expression, List<VertexDisplacement>> displacements = new Dictionary<Expression, List<VertexDisplacement>>();
            for (int j = 0; j < 5; j++)
            {
                Expression exp = (Expression)j;
                displacements.Add(exp, this.CalculateDisplacements(this.target.TRI.Vertices, this.expressions[exp].Vertices, this.ignoreList, this.accuracy));
            }
            Dictionary<Morph, List<Triple<double, double, double>>> unmorphs = new Dictionary<Morph, List<Triple<double, double, double>>>();
            for (int i = 0; i < 4; i++)
            {
                Morph morph = (Morph)i;
                List<Triple<double, double, double>> unmorph = new List<Triple<double, double, double>>();
                for (int j = 0; j < this.target.TRI.Header.VertexCount; j++)
                {
                    unmorph.Add(new Triple<double, double, double>());
                }
                foreach (KeyValuePair<Expression, Dictionary<Morph, double>> weight in this.weights)
                {
                    if (weight.Value.ContainsKey(morph))
                    {
                        List<VertexDisplacement> mlist = displacements[weight.Key];
                        double w = weight.Value[morph];
                        for (int k = 0; k < mlist.Count; k++)
                        {
                            Triple<double, double, double> aux = unmorph[k];
                            aux.X = aux.X + w * (double)(mlist[k].X);
                            aux.Y = aux.Y + w * (double)(mlist[k].Y);
                            aux.Z = aux.Z + w * (double)(mlist[k].Z);
                            unmorph[k] = aux;
                        }
                    }
                }
                for (int j = 0; j < unmorph.Count; j++)
                {
                    Triple<double, double, double> aux = unmorph[j];
                    aux.X = aux.X / 100d;
                    aux.Y = aux.Y / 100d;
                    aux.Z = aux.Z / 100d;
                    unmorph[j] = aux;
                }
                unmorphs.Add(morph, unmorph);
            }
            Dictionary<Morph, List<VertexDisplacement>> morphs = new Dictionary<Morph, List<VertexDisplacement>>();
            foreach (KeyValuePair<Morph, List<Triple<double, double, double>>> keypair in unmorphs)
            {
                double totalscale = 0;
                foreach (KeyValuePair<Expression, Dictionary<Morph, double>> weight in this.weights)
                {
                    if (weight.Value.ContainsKey(keypair.Key))
                        totalscale += weight.Value[keypair.Key];
                }
                if (totalscale > 100)
                {
                    List<VertexDisplacement> morph = new List<VertexDisplacement>();
                    double max = 100 / totalscale;
                    for (int i = 0; i < keypair.Value.Count; i++)
                    {
                        Triple<double, double, double> triple = keypair.Value[i];
                        morph.Add(new VertexDisplacement((short)(Math.Min(triple.X * max, short.MaxValue)), (short)(Math.Min(triple.Y * max, short.MaxValue)), (short)(Math.Min(triple.Z * max, short.MaxValue))));
                    }
                    morphs.Add(keypair.Key, morph);
                }
                else
                {
                    List<VertexDisplacement> morph = new List<VertexDisplacement>();
                    for (int i = 0; i < keypair.Value.Count; i++)
                    {
                        Triple<double, double, double> triple = keypair.Value[i];
                        morph.Add(new VertexDisplacement((short)(triple.X), (short)(triple.Y), (short)(triple.Z)));
                    }
                    morphs.Add(keypair.Key, morph);
                }
            }
            HeadFile ret = new HeadFile(this.target);
            try
            {
                foreach (KeyValuePair<Morph, List<VertexDisplacement>> keypair in morphs)
                {
                    List<VertexDisplacement> morph2 = keypair.Value;
                    foreach (TRIMorphData morph in ret.TRI.Morphs)
                    {
                        if (morph.Name.ToLower().StartsWith(keypair.Key.ToString().ToLower()))
                        {
                            for (int i = 0; i < ret.TRI.Header.VertexCount; i++)
                            {
                                morph[i] = morph2[i];
                            }
                        }
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

        private HeadFile ApplyAbsolute()
        {
            Dictionary<Expression, List<Triple<double, double, double>>> offsets = new Dictionary<Expression, List<Triple<double, double, double>>>();
            foreach (KeyValuePair<Expression, MeshBase> expression in this.expressions)
            {
                offsets.Add(expression.Key, this.CalculateOffsets(this.target.TRI.Vertices, expression.Value.Vertices));
            }
            Dictionary<Morph, List<VertexPosition>> unmorphs = new Dictionary<Morph, List<VertexPosition>>();
            for (int i = 0; i < 4; i++)
            {
                Morph morph = (Morph)i;
                List<Triple<double, double, double>> unmorph = new List<Triple<double, double, double>>();
                for (int j = 0; j < this.target.TRI.Header.VertexCount; j++)
                {
                    unmorph.Add(new Triple<double, double, double>());
                }
                foreach (KeyValuePair<Expression, Dictionary<Morph, double>> weight in this.weights)
                {
                    if (weight.Value.ContainsKey(morph))
                    {
                        List<Triple<double, double, double>> mlist = offsets[weight.Key];
                        double w = weight.Value[morph];
                        for (int k = 0; k < mlist.Count; k++)
                        {
                            Triple<double, double, double> aux = unmorph[k];
                            aux.X = aux.X + w * (double)(mlist[k].X);
                            aux.Y = aux.Y + w * (double)(mlist[k].Y);
                            aux.Z = aux.Z + w * (double)(mlist[k].Z);
                            unmorph[k] = aux;
                        }
                    }
                }
                List<VertexPosition> unmorph2 = new List<VertexPosition>();
                for (int j = 0; j < unmorph.Count; j++)
                {
                    Triple<double, double, double> aux = unmorph[j];
                    VertexPosition pos = new VertexPosition();
                    pos.X = this.target.TRI.Vertices[j].X - (float)(aux.X / 100d);
                    pos.Y = this.target.TRI.Vertices[j].Y - (float)(aux.Y / 100d);
                    pos.Z = this.target.TRI.Vertices[j].Z - (float)(aux.Z / 100d);
                    unmorph2.Add(pos);
                }

                unmorphs.Add(morph, unmorph2);
            }
            Dictionary<Morph, List<VertexDisplacement>> displacements = new Dictionary<Morph, List<VertexDisplacement>>();
            for (int i = 0; i < 4; i++)
            {
                Morph morph = (Morph)i;
                displacements.Add(morph, this.CalculateDisplacements(this.target.TRI.Vertices, unmorphs[morph], this.ignoreList, this.accuracy));
            }
            HeadFile ret = new HeadFile(this.target);
            try
            {
                foreach (KeyValuePair<Morph, List<VertexDisplacement>> keypair in displacements)
                {
                    foreach (TRIMorphData morph in ret.TRI.Morphs)
                    {
                        if (morph.Name.ToLower().StartsWith(keypair.Key.ToString().ToLower()))
                        {
                            for (int i = 0; i < ret.TRI.Header.VertexCount; i++)
                                morph[i] = keypair.Value[i];
                        }
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
            ret.SubItems.Add("Generate DispAnger Expressions Morphs");
            ret.SubItems.Add("Applied: " + this.applied.ToString());
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
                return "Applied: " + this.applied.ToString();
            }
        }
    }
}
