namespace FaceMix
{
    partial class RemoveVampirismEffectControl
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
            this.applyButton = new System.Windows.Forms.Button();
            this.appliedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(93, 3);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 0;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // appliedLabel
            // 
            this.appliedLabel.AutoSize = true;
            this.appliedLabel.Location = new System.Drawing.Point(14, 8);
            this.appliedLabel.Name = "appliedLabel";
            this.appliedLabel.Size = new System.Drawing.Size(73, 13);
            this.appliedLabel.TabIndex = 1;
            this.appliedLabel.Text = "Applied: False";
            // 
            // RemoveVampirismEffectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.appliedLabel);
            this.Controls.Add(this.applyButton);
            this.Name = "RemoveVampirismEffectControl";
            this.Size = new System.Drawing.Size(188, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button applyButton;
        public System.Windows.Forms.Label appliedLabel;

    }
}
