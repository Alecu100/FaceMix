using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using FaceMix.Base;

namespace FaceMix
{
    [Modifier("Update TRI Mesh")]
    public class UpdateTRIMesh : AbstractModifier
    {
        private HeadFile target;
        private bool applied;
        private OBJFile reference;
        private UpdateTRIMeshControl menu;

        public override event AbstractModifier.Ready WhenReady;

        public override string Name { get { return "Update TRI Mesh"; } }

        public UpdateTRIMesh()
        {
            this.applied = false;
            this.menu = new UpdateTRIMeshControl();
            this.menu.applyButton.Click += new EventHandler(applyButton_Click);
            this.menu.openButton.Click += new EventHandler(openButton_Click);
        }

        void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "OBJ Files (*.obj)|*.OBJ|" + "All files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                FileStream stream = new FileStream(open.FileName, FileMode.Open);
                OBJFile buf = new OBJFile(stream);
                stream.Close();
                if (buf.Vertices.Count != this.target.TRI.Header.VertexCount)
                {
                    return;
                }
                this.reference = buf;
                this.menu.textBox1.Text = open.FileName;
            }
        }

        void applyButton_Click(object sender, EventArgs e)
        {
            this.WhenReady(this, new EventArgs());
        }

        public override HeadFile Apply()
        {
            if (this.target == null || this.reference == null)
                return this.target;
            HeadFile ret = new HeadFile(this.target);
            for (int i = 0; i < this.target.TRI.Header.VertexCount; i++)
            {
                ret.TRI.Vertices[i] = this.reference.Vertices[i];
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
            get 
            {
                return this.menu;
            }
        }

        public override ListViewItem ToListViewItem(int index)
        {
            ListViewItem ret = new ListViewItem(index.ToString());
            ret.SubItems.Add("Update TRI Mesh");
            if (this.applied == false)
            {
                ret.SubItems.Add("Applied: " + this.applied.ToString() + ", Reference file: None");
            }
            else
            {
                ret.SubItems.Add("Applied: " + this.applied.ToString() + ", Reference file: " + this.menu.textBox1.Text);
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
                StringBuilder bld = new StringBuilder();
                bld.Append("Applied: False, ");
                if (this.reference == null)
                    bld.Append("Reference file: None");
                else
                    bld.Append("Reference file: " + this.menu.textBox1.Text);
                return bld.ToString();
            }
        }
    }
}
