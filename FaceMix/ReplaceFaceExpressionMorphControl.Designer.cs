namespace FaceMix
{
    partial class ReplaceFaceExpressionMorphControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.referenceTextBox = new System.Windows.Forms.TextBox();
            this.openOBJFileButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.accuracyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.targetMorphComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ignoreListTextBox = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.clearIgnoreListButton = new System.Windows.Forms.Button();
            this.openIgnoreListButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.accuracyNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "OBJ File:";
            // 
            // referenceTextBox
            // 
            this.referenceTextBox.Location = new System.Drawing.Point(58, 7);
            this.referenceTextBox.Name = "referenceTextBox";
            this.referenceTextBox.ReadOnly = true;
            this.referenceTextBox.Size = new System.Drawing.Size(341, 20);
            this.referenceTextBox.TabIndex = 1;
            // 
            // openOBJFileButton
            // 
            this.openOBJFileButton.Location = new System.Drawing.Point(405, 5);
            this.openOBJFileButton.Name = "openOBJFileButton";
            this.openOBJFileButton.Size = new System.Drawing.Size(75, 23);
            this.openOBJFileButton.TabIndex = 2;
            this.openOBJFileButton.Text = "Open OBJ File";
            this.openOBJFileButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Accuracy:";
            // 
            // accuracyNumericUpDown
            // 
            this.accuracyNumericUpDown.DecimalPlaces = 5;
            this.accuracyNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.accuracyNumericUpDown.Location = new System.Drawing.Point(64, 33);
            this.accuracyNumericUpDown.Name = "accuracyNumericUpDown";
            this.accuracyNumericUpDown.Size = new System.Drawing.Size(92, 20);
            this.accuracyNumericUpDown.TabIndex = 4;
            this.accuracyNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Target Morph:";
            // 
            // targetMorphComboBox
            // 
            this.targetMorphComboBox.FormattingEnabled = true;
            this.targetMorphComboBox.Location = new System.Drawing.Point(242, 34);
            this.targetMorphComboBox.Name = "targetMorphComboBox";
            this.targetMorphComboBox.Size = new System.Drawing.Size(157, 21);
            this.targetMorphComboBox.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ignoreListTextBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 144);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ignore List";
            // 
            // ignoreListTextBox
            // 
            this.ignoreListTextBox.Location = new System.Drawing.Point(6, 19);
            this.ignoreListTextBox.Multiline = true;
            this.ignoreListTextBox.Name = "ignoreListTextBox";
            this.ignoreListTextBox.ReadOnly = true;
            this.ignoreListTextBox.Size = new System.Drawing.Size(462, 119);
            this.ignoreListTextBox.TabIndex = 0;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(405, 33);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 8;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // clearIgnoreListButton
            // 
            this.clearIgnoreListButton.Location = new System.Drawing.Point(142, 209);
            this.clearIgnoreListButton.Name = "clearIgnoreListButton";
            this.clearIgnoreListButton.Size = new System.Drawing.Size(94, 23);
            this.clearIgnoreListButton.TabIndex = 9;
            this.clearIgnoreListButton.Text = "Clear Ignore List";
            this.clearIgnoreListButton.UseVisualStyleBackColor = true;
            // 
            // openIgnoreListButton
            // 
            this.openIgnoreListButton.Location = new System.Drawing.Point(242, 209);
            this.openIgnoreListButton.Name = "openIgnoreListButton";
            this.openIgnoreListButton.Size = new System.Drawing.Size(102, 23);
            this.openIgnoreListButton.TabIndex = 10;
            this.openIgnoreListButton.Text = "Open Ignore List";
            this.openIgnoreListButton.UseVisualStyleBackColor = true;
            // 
            // ReplaceFaceExpressionMorphControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.openIgnoreListButton);
            this.Controls.Add(this.clearIgnoreListButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.targetMorphComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.accuracyNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.openOBJFileButton);
            this.Controls.Add(this.referenceTextBox);
            this.Controls.Add(this.label1);
            this.Name = "ReplaceFaceExpressionMorphControl";
            this.Size = new System.Drawing.Size(496, 249);
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
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox referenceTextBox;
        public System.Windows.Forms.Button openOBJFileButton;
        public System.Windows.Forms.NumericUpDown accuracyNumericUpDown;
        public System.Windows.Forms.ComboBox targetMorphComboBox;
        public System.Windows.Forms.Button applyButton;
        public System.Windows.Forms.Button clearIgnoreListButton;
        public System.Windows.Forms.Button openIgnoreListButton;
        public System.Windows.Forms.TextBox ignoreListTextBox;
    }
}
