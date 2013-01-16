using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FaceMix.Base;
using FaceMix.Core;

namespace FaceMix
{
    [Modifier("Remove Vampirism Effect")]
    public class RemoveVampirismEffect : AbstractModifier
    {
        private RemoveVampirismEffectControl menu;

        private bool applied;
        
        public override event AbstractModifier.Ready WhenReady;

        private HeadFile target;

        public RemoveVampirismEffect()
        {
            this.menu = new RemoveVampirismEffectControl();
            this.menu.applyButton.Click += new EventHandler(applyButton_Click);
            this.applied = false;
        }

        void applyButton_Click(object sender, EventArgs e)
        {
            this.WhenReady(this, e);
        }

        public override string Name
        {
            get { return "Remove Vampirism Effect"; }
        }

        public override HeadFile Apply()
        {
            if (this.target == null)
                return null;
            HeadFile ret = new HeadFile(this.target);
            TRIMorphData targetMorph = null;
            foreach (TRIMorphData morph in ret.TRI.Morphs)
            {
                if(morph.Name.ToLower().StartsWith("vampiremorph"))
                {
                    targetMorph = morph;
                    break;
                }
            }
            if(targetMorph != null)
            {
                for (int i = 0; i < ret.TRI.Header.VertexCount; i++)
                    targetMorph[i] = new VertexDisplacement(0, 0, 0);
                this.applied = true;
                this.menu.appliedLabel.Text = "Applied: True";
            }
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
            if (this.applied == true)
            {
                ListViewItem ret = new ListViewItem(index.ToString());
                ret.SubItems.Add("Remove Vampirism Effect");
                ret.SubItems.Add("Applied: True");
                return ret;
            }
            else
            {
                ListViewItem ret = new ListViewItem(index.ToString());
                ret.SubItems.Add("Remove Vampirism Effect");
                ret.SubItems.Add("Applied: False");
                return ret;
            }

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
                return "Remove Vampirism Effect  " + "Applied: " + this.applied.ToString(); 
            }
        }
    }
}

