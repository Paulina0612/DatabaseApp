namespace DatabaseApp
{
    partial class RemoveAuthor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.authorDataComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.commitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // authorDataComboBox
            // 
            this.authorDataComboBox.FormattingEnabled = true;
            this.authorDataComboBox.Location = new System.Drawing.Point(46, 65);
            this.authorDataComboBox.Name = "authorDataComboBox";
            this.authorDataComboBox.Size = new System.Drawing.Size(423, 28);
            this.authorDataComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose Author";
            // 
            // commitButton
            // 
            this.commitButton.Location = new System.Drawing.Point(329, 99);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(140, 33);
            this.commitButton.TabIndex = 2;
            this.commitButton.Text = "Commit";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.commitButton_Click);
            // 
            // RemoveAuthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 175);
            this.Controls.Add(this.commitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.authorDataComboBox);
            this.Name = "RemoveAuthor";
            this.Text = "Remove_Author";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox authorDataComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button commitButton;
    }
}