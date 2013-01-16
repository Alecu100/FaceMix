namespace FaceMix.ExtendedModifiers
{
    partial class GenerateDispAngerExpressionsMorphsControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.accuracyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ignoreListTextBox = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.clearIgnoreListButton = new System.Windows.Forms.Button();
            this.openIgnoreListButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.expressionsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openWeightsButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.absoluteRadioButton = new System.Windows.Forms.RadioButton();
            this.relativeRadiobutton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.accuracyNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openOBJFileButton
            // 
            this.openOBJFileButton.Location = new System.Drawing.Point(167, 8);
            this.openOBJFileButton.Name = "openOBJFileButton";
            this.openOBJFileButton.Size = new System.Drawing.Size(75, 23);
            this.openOBJFileButton.TabIndex = 2;
            this.openOBJFileButton.Text = "Open OBJ File";
            this.openOBJFileButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 13);
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
            this.accuracyNumericUpDown.Location = new System.Drawing.Point(69, 11);
            this.accuracyNumericUpDown.Name = "accuracyNumericUpDown";
            this.accuracyNumericUpDown.Size = new System.Drawing.Size(92, 20);
            this.accuracyNumericUpDown.TabIndex = 4;
            this.accuracyNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ignoreListTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 228);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 117);
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
            this.ignoreListTextBox.Size = new System.Drawing.Size(480, 92);
            this.ignoreListTextBox.TabIndex = 0;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(248, 37);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(90, 23);
            this.applyButton.TabIndex = 8;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // clearIgnoreListButton
            // 
            this.clearIgnoreListButton.Location = new System.Drawing.Point(136, 351);
            this.clearIgnoreListButton.Name = "clearIgnoreListButton";
            this.clearIgnoreListButton.Size = new System.Drawing.Size(94, 23);
            this.clearIgnoreListButton.TabIndex = 9;
            this.clearIgnoreListButton.Text = "Clear Ignore List";
            this.clearIgnoreListButton.UseVisualStyleBackColor = true;
            // 
            // openIgnoreListButton
            // 
            this.openIgnoreListButton.Location = new System.Drawing.Point(236, 351);
            this.openIgnoreListButton.Name = "openIgnoreListButton";
            this.openIgnoreListButton.Size = new System.Drawing.Size(102, 23);
            this.openIgnoreListButton.TabIndex = 10;
            this.openIgnoreListButton.Text = "Open Ignore List";
            this.openIgnoreListButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.expressionsListView);
            this.groupBox2.Location = new System.Drawing.Point(12, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(492, 159);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Expressions";
            // 
            // expressionsListView
            // 
            this.expressionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.expressionsListView.FullRowSelect = true;
            this.expressionsListView.GridLines = true;
            this.expressionsListView.Location = new System.Drawing.Point(6, 19);
            this.expressionsListView.Name = "expressionsListView";
            this.expressionsListView.Size = new System.Drawing.Size(480, 133);
            this.expressionsListView.TabIndex = 0;
            this.expressionsListView.UseCompatibleStateImageBehavior = false;
            this.expressionsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Weight";
            this.columnHeader2.Width = 102;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "File";
            // 
            // openWeightsButton
            // 
            this.openWeightsButton.Location = new System.Drawing.Point(248, 8);
            this.openWeightsButton.Name = "openWeightsButton";
            this.openWeightsButton.Size = new System.Drawing.Size(90, 23);
            this.openWeightsButton.TabIndex = 12;
            this.openWeightsButton.Text = "Open Weights";
            this.openWeightsButton.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.absoluteRadioButton);
            this.groupBox3.Controls.Add(this.relativeRadiobutton);
            this.groupBox3.Location = new System.Drawing.Point(344, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(160, 55);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mode";
            // 
            // absoluteRadioButton
            // 
            this.absoluteRadioButton.AutoSize = true;
            this.absoluteRadioButton.Location = new System.Drawing.Point(77, 20);
            this.absoluteRadioButton.Name = "absoluteRadioButton";
            this.absoluteRadioButton.Size = new System.Drawing.Size(66, 17);
            this.absoluteRadioButton.TabIndex = 1;
            this.absoluteRadioButton.TabStop = true;
            this.absoluteRadioButton.Text = "Absolute";
            this.absoluteRadioButton.UseVisualStyleBackColor = true;
            // 
            // relativeRadiobutton
            // 
            this.relativeRadiobutton.AutoSize = true;
            this.relativeRadiobutton.Location = new System.Drawing.Point(6, 19);
            this.relativeRadiobutton.Name = "relativeRadiobutton";
            this.relativeRadiobutton.Size = new System.Drawing.Size(64, 17);
            this.relativeRadiobutton.TabIndex = 0;
            this.relativeRadiobutton.TabStop = true;
            this.relativeRadiobutton.Text = "Relative";
            this.relativeRadiobutton.UseVisualStyleBackColor = true;
            // 
            // ReplaceFaceExpressionMorphControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.openWeightsButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.openIgnoreListButton);
            this.Controls.Add(this.clearIgnoreListButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.accuracyNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.openOBJFileButton);
            this.Name = "ReplaceFaceExpressionMorphControl";
            this.Size = new System.Drawing.Size(507, 385);
            ((System.ComponentModel.ISupportInitialize)(this.accuracyNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button openOBJFileButton;
        public System.Windows.Forms.NumericUpDown accuracyNumericUpDown;
        public System.Windows.Forms.Button applyButton;
        public System.Windows.Forms.Button clearIgnoreListButton;
        public System.Windows.Forms.Button openIgnoreListButton;
        public System.Windows.Forms.TextBox ignoreListTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Button openWeightsButton;
        public System.Windows.Forms.RadioButton absoluteRadioButton;
        public System.Windows.Forms.RadioButton relativeRadiobutton;
        public System.Windows.Forms.ListView expressionsListView;
    }
}
