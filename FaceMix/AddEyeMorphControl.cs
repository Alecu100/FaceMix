using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FaceMix
{
    public partial class AddEyeMorphControl : UserControl
    {   
        public AddEyeMorphControl()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true)
            {
                this.openVertexIndexesButton.Enabled = true;
            }
            else
            {
                this.openVertexIndexesButton.Enabled = false;
            }
        }
    }
}
