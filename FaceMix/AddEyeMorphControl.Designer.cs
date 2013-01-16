namespace FaceMix
{
    partial class AddEyeMorphControl
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
            this.vertexIndexesTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openVertexIndexesButton = new System.Windows.Forms.Button();
            this.openReferenceFileButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.tresholdUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tresholdUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // vertexIndexesTextBox
            // 
            this.vertexIndexesTextBox.Location = new System.Drawing.Point(6, 19);
            this.vertexIndexesTextBox.Multiline = true;
            this.vertexIndexesTextBox.Name = "vertexIndexesTextBox";
            this.vertexIndexesTextBox.ReadOnly = true;
            this.vertexIndexesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.vertexIndexesTextBox.Size = new System.Drawing.Size(365, 138);
            this.vertexIndexesTextBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vertexIndexesTextBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 163);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vertex Indexes";
            // 
            // openVertexIndexesButton
            // 
            this.openVertexIndexesButton.Location = new System.Drawing.Point(62, 282);
            this.openVertexIndexesButton.Name = "openVertexIndexesButton";
            this.openVertexIndexesButton.Size = new System.Drawing.Size(118, 23);
            this.openVertexIndexesButton.TabIndex = 2;
            this.openVertexIndexesButton.Text = "Open Vertex Indexes";
            this.openVertexIndexesButton.UseVisualStyleBackColor = true;
            // 
            // openReferenceFileButton
            // 
            this.openReferenceFileButton.Location = new System.Drawing.Point(186, 282);
            this.openReferenceFileButton.Name = "openReferenceFileButton";
            this.openReferenceFileButton.Size = new System.Drawing.Size(115, 23);
            this.openReferenceFileButton.TabIndex = 3;
            this.openReferenceFileButton.Text = "Open Reference File";
            this.openReferenceFileButton.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(201, 252);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(100, 23);
            this.applyButton.TabIndex = 4;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // tresholdUpDown
            // 
            this.tresholdUpDown.DecimalPlaces = 4;
            this.tresholdUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.tresholdUpDown.Location = new System.Drawing.Point(245, 43);
            this.tresholdUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tresholdUpDown.Name = "tresholdUpDown";
            this.tresholdUpDown.Size = new System.Drawing.Size(120, 20);
            this.tresholdUpDown.TabIndex = 6;
            this.tresholdUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.tresholdUpDown);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 74);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Accuracy:";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 43);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(116, 17);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Autodetect indexes";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(127, 17);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Load indexes from file";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(109, 254);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(86, 20);
            this.nameTextBox.TabIndex = 9;
            // 
            // AddEyesModifierControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.openReferenceFileButton);
            this.Controls.Add(this.openVertexIndexesButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddEyesModifierControl";
            this.Size = new System.Drawing.Size(388, 310);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tresholdUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox vertexIndexesTextBox;
        public System.Windows.Forms.Button openVertexIndexesButton;
        public System.Windows.Forms.Button openReferenceFileButton;
        public System.Windows.Forms.Button applyButton;
        public System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.RadioButton radioButton1;
        public System.Windows.Forms.TextBox nameTextBox;
        public System.Windows.Forms.NumericUpDown tresholdUpDown;
    }
}
