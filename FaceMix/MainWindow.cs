using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FaceMix.Base;
using FaceMix.Wrappers;
using FaceMix.Core;
using System.Reflection;

namespace FaceMix
{
    public partial class MainWindow : Form
    {
        public List<AbstractModifier> modifiers;

        public List<HeadFile> modifiersStages;

        public MainWindow()
        {
            InitializeComponent();
            this.LoadPlugins();
            foreach (string name in AbstractModifier.GetModifierNames())
	        {
                this.modifiersComboBox.Items.Add(name);
	        }

            this.modifiers = new List<AbstractModifier>();
            this.modifiersStages = new List<HeadFile>();

            this.addButton.Enabled = false;
            
            //AbstractModifier mod = AbstractModifier.MakeModifier("Eyes Modifier");
            //this.modifierPropertiesPanel.Controls.Add(mod.Menu);
        }

        private void LoadPlugins()
        {
            AbstractModifier.LoadedAssemblies.Add(Assembly.GetExecutingAssembly());
            DirectoryInfo plugDir = new DirectoryInfo(Environment.CurrentDirectory + "\\Plugins");
            if (!plugDir.Exists)
                return;
            FileInfo[] files = plugDir.GetFiles();
            foreach (FileInfo file in files)
            {
                try
                {
                    Assembly asm = Assembly.LoadFile(file.FullName);
                    AbstractModifier.LoadedAssemblies.Add(asm);
                }
                catch (Exception)
                {
                }
            }
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Nif Files (*.nif)|*.nif|" + "EGM Files (*.egm)|*.egm|" + "TRI Files (*.tri)|*.tri|" + "All files (*.*)|*.*";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    HeadFile nifFile = new HeadFile(open.FileName);
                    this.modifiersStages.Clear();
                    this.modifiers.Clear();
                    this.modifiersStages.Add(nifFile);
                    this.modifierPropertiesPanel.Controls.Clear();
                    this.modifiersListView.Items.Clear();
                    this.addButton.Enabled = true;
                    this.deletebutton.Enabled = true;
                    this.moveUpButton.Enabled = true;
                    this.moveDownbutton.Enabled = true;
                    this.clearButton.Enabled = true;
                    this.resetButton.Enabled = true;
                    this.targetFileTextBox.Text = open.FileName;
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Could not load tri file");
                }
                
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.modifiersStages.Count <= 0)
                return;
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Nif Files (*.nif)|*.nif|" + "EGM Files (*.egm)|*.egm|" + "TRI Files (*.tri)|*.tri|" + "All files (*.*)|*.*";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.modifiersStages[this.modifiersStages.Count - 1].WriteToFile(save.FileName);
            }
        }

        void mod_WhenReady(object sender, EventArgs e)
        {
            this.UpdateModifiers(sender as AbstractModifier);
        }

        private void UpdateModifiers(AbstractModifier startingModifier)
        {
            int start = 0;
            for(int i = 0;i < this.modifiers.Count; i++)
                if (this.modifiers[i] == startingModifier)
                {
                    start = i;
                }
            for (int i = start; i < this.modifiers.Count; i++)
            {
                this.modifiers[i].Target = this.modifiersStages[i];
                this.modifiersStages[i + 1] = this.modifiers[i].Apply(); 
            }
            this.modifiersListView.BeginUpdate();
            this.modifiersListView.Items.Clear();
            for (int i = 0; i < this.modifiers.Count; i++)
                this.modifiersListView.Items.Add(this.modifiers[i].ToListViewItem(i));
            this.modifiersListView.EndUpdate();
        }

        private void modifiersListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (this.modifiersListView.SelectedItems.Count > 0)
            {
                ListView.SelectedIndexCollection index = this.modifiersListView.SelectedIndices;
                this.modifierPropertiesPanel.Controls.Clear();
                this.modifierPropertiesPanel.Controls.Add(this.modifiers[index[0]].Menu);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            this.addButton.Enabled = false;
            this.resetButton.Enabled = false;
            this.moveDownbutton.Enabled = false;
            this.moveUpButton.Enabled = false;
            this.clearButton.Enabled = false;
            this.deletebutton.Enabled = false;
            this.modifiers.Clear();
            this.modifiersStages.Clear();
            this.modifierPropertiesPanel.Controls.Clear();
            this.modifiersListView.Items.Clear();
            this.targetFileTextBox.Text = "";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AbstractModifier mod = AbstractModifier.MakeModifier(this.modifiersComboBox.Text);
            if (mod != null)
            {
                this.modifierPropertiesPanel.Controls.Clear();
                this.modifiersListView.SelectedItems.Clear();
                mod.Target = this.modifiersStages[this.modifiersStages.Count - 1];
                this.modifiersListView.BeginUpdate();
                this.modifiersListView.SelectedItems.Clear();
                this.modifiersListView.Items.Add(mod.ToListViewItem(this.modifiers.Count));
                this.modifiersListView.EndUpdate();
                this.modifierPropertiesPanel.Controls.Clear();
                this.modifierPropertiesPanel.Controls.Add(mod.Menu);
                this.modifiers.Add(mod);
                mod.WhenReady += new AbstractModifier.Ready(mod_WhenReady);
                HeadFile tmp = this.modifiersStages[this.modifiersStages.Count - 1];
                this.modifiersStages.Add(tmp);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            
            if(this.modifiersListView.SelectedItems.Count <=0 )
                return;
            this.modifierPropertiesPanel.Controls.Clear();
            AbstractModifier mod = this.modifiers[this.modifiersListView.SelectedIndices[0]];
            this.modifiers.RemoveAt(this.modifiersListView.SelectedIndices[0]);
            this.modifiersStages.RemoveAt(this.modifiersStages.Count - 1);
            this.UpdateModifiers(mod);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.modifierPropertiesPanel.Controls.Clear();
            HeadFile start = this.modifiersStages[0];
            this.modifiersStages.Clear();
            this.modifiersStages.Add(start);
            this.modifiers.Clear();
            this.modifiersListView.BeginUpdate();
            this.modifiersListView.Items.Clear();
            this.modifiersListView.EndUpdate();
        }

        private void moveDownbutton_Click(object sender, EventArgs e)
        {
            if (this.modifiersListView.SelectedItems.Count <= 0)
                return;
            if (this.modifiersListView.SelectedIndices[0] >= this.modifiers.Count - 1)
            {
                int t = this.modifiersListView.SelectedIndices[0];
                this.modifiersListView.BeginUpdate();
                this.modifiersListView.SelectedIndices.Clear();
                this.modifiersListView.SelectedIndices.Add(t);
                this.modifiersListView.EndUpdate();
                this.modifiersListView.Focus();
                return;
            }
            int selected = this.modifiersListView.SelectedIndices[0];
            AbstractModifier tmp = this.modifiers[selected + 1];
            this.modifiers[selected + 1] = this.modifiers[selected];
            this.modifiers[selected] = tmp;
            this.UpdateModifiers(this.modifiers[selected]);
            this.modifiersListView.BeginUpdate();
            this.modifiersListView.Items.Clear();
            for (int i = 0; i < this.modifiers.Count; i++)
                this.modifiersListView.Items.Add(this.modifiers[i].ToListViewItem(i));
            this.modifiersListView.SelectedIndices.Clear();
            this.modifiersListView.SelectedIndices.Add(selected + 1);
            this.modifiersListView.EndUpdate();
            this.modifiersListView.Focus();
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            if (this.modifiersListView.SelectedItems.Count <= 0)
                return;
            if (this.modifiersListView.SelectedIndices[0] <= 0)
            {
                int t = this.modifiersListView.SelectedIndices[0];
                this.modifiersListView.BeginUpdate();
                this.modifiersListView.SelectedIndices.Clear();
                this.modifiersListView.SelectedIndices.Add(t);
                this.modifiersListView.EndUpdate();
                this.modifiersListView.Focus();
                return;
            }
            int selected = this.modifiersListView.SelectedIndices[0];
            AbstractModifier tmp = this.modifiers[selected - 1];
            this.modifiers[selected - 1] = this.modifiers[selected];
            this.modifiers[selected] = tmp;
            this.UpdateModifiers(this.modifiers[selected - 1]);
            this.modifiersListView.BeginUpdate();
            this.modifiersListView.Items.Clear();
            for (int i = 0; i < this.modifiers.Count; i++)
                this.modifiersListView.Items.Add(this.modifiers[i].ToListViewItem(i));
            this.modifiersListView.SelectedIndices.Clear();
            this.modifiersListView.SelectedIndices.Add(selected - 1);
            this.modifiersListView.EndUpdate();
            this.modifiersListView.Focus();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }
    }
}