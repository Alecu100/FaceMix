namespace FaceMix
{
    partial class ReplaceFaceGenMorphcontrol
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openOBJFileButton = new System.Windows.Forms.Button();
            this.referenceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.targetMorphComboBox = new System.Windows.Forms.ComboBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.accuracyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.openIgnoreListbutton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ignoreListTextBox = new System.Windows.Forms.TextBox();
            this.clearIgnoreListButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.accuracyNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openOBJFileButton
            // 
            this.openOBJFileButton.Location = new System.Drawing.Point(354, 5);
            this.openOBJFileButton.Name = "openOBJFileButton";
            this.openOBJFileButton.Size = new System.Drawing.Size(75, 23);
            this.openOBJFileButton.TabIndex = 0;
            this.openOBJFileButton.Text = "Open OBJ File";
            this.openOBJFileButton.UseVisualStyleBackColor = true;
            // 
            // referenceTextBox
            // 
            this.referenceTextBox.Location = new System.Drawing.Point(58, 7);
            this.referenceTextBox.Name = "referenceTextBox";
            this.referenceTextBox.ReadOnly = true;
            this.referenceTextBox.Size = new System.Drawing.Size(290, 20);
            this.referenceTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "OBJ File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Target Morph:";
            // 
            // targetMorphComboBox
            // 
            this.targetMorphComboBox.FormattingEnabled = true;
            this.targetMorphComboBox.Location = new System.Drawing.Point(263, 33);
            this.targetMorphComboBox.Name = "targetMorphComboBox";
            this.targetMorphComboBox.Size = new System.Drawing.Size(85, 21);
            this.targetMorphComboBox.TabIndex = 4;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(354, 31);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 5;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Accuracy:";
            // 
            // accuracyNumericUpDown
            // 
            this.accuracyNumericUpDown.DecimalPlaces = 5;
            this.accuracyNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.accuracyNumericUpDown.Location = new System.Drawing.Point(60, 33);
            this.accuracyNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.accuracyNumericUpDown.Name = "accuracyNumericUpDown";
            this.accuracyNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.accuracyNumericUpDown.TabIndex = 7;
            this.accuracyNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            // 
            // openIgnoreListbutton
            // 
            this.openIgnoreListbutton.Location = new System.Drawing.Point(219, 230);
            this.openIgnoreListbutton.Name = "openIgnoreListbutton";
            this.openIgnoreListbutton.Size = new System.Drawing.Size(95, 23);
            this.openIgnoreListbutton.TabIndex = 8;
            this.openIgnoreListbutton.Text = "Open Ignore List";
            this.openIgnoreListbutton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ignoreListTextBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 163);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ignore List";
            // 
            // ignoreListTextBox
            // 
            this.ignoreListTextBox.Location = new System.Drawing.Point(7, 20);
            this.ignoreListTextBox.Multiline = true;
            this.ignoreListTextBox.Name = "ignoreListTextBox";
            this.ignoreListTextBox.ReadOnly = true;
            this.ignoreListTextBox.Size = new System.Drawing.Size(410, 135);
            this.ignoreListTextBox.TabIndex = 0;
            // 
            // clearIgnoreListButton
            // 
            this.clearIgnoreListButton.Location = new System.Drawing.Point(122, 230);
            this.clearIgnoreListButton.Name = "clearIgnoreListButton";
            this.clearIgnoreListButton.Size = new System.Drawing.Size(91, 23);
            this.clearIgnoreListButton.TabIndex = 10;
            this.clearIgnoreListButton.Text = "Clear Ignore List";
            this.clearIgnoreListButton.UseVisualStyleBackColor = true;
            // 
            // ReplaceFaceGenMorphcontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clearIgnoreListButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.openIgnoreListbutton);
            this.Controls.Add(this.accuracyNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.targetMorphComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.referenceTextBox);
            this.Controls.Add(this.openOBJFileButton);
            this.Name = "ReplaceFaceGenMorphcontrol";
            this.Size = new System.Drawing.Size(436, 261);
            ((System.ComponentModel.ISupportInitialize)(this.accuracyNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button openOBJFileButton;
        public System.Windows.Forms.TextBox referenceTextBox;
        public System.Windows.Forms.ComboBox targetMorphComboBox;
        public System.Windows.Forms.Button applyButton;
        public System.Windows.Forms.NumericUpDown accuracyNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button openIgnoreListbutton;
        public System.Windows.Forms.TextBox ignoreListTextBox;
        public System.Windows.Forms.Button clearIgnoreListButton;
    }
}
