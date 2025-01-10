namespace DatabaseApp
{
    partial class RemoveBook
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
            this.enterBookIDLabel = new System.Windows.Forms.Label();
            this.bookIDTextBox = new System.Windows.Forms.TextBox();
            this.commitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // enterBookIDLabel
            // 
            this.enterBookIDLabel.AutoSize = true;
            this.enterBookIDLabel.Location = new System.Drawing.Point(36, 47);
            this.enterBookIDLabel.Name = "enterBookIDLabel";
            this.enterBookIDLabel.Size = new System.Drawing.Size(108, 20);
            this.enterBookIDLabel.TabIndex = 0;
            this.enterBookIDLabel.Text = "Enter book ID";
            // 
            // bookIDTextBox
            // 
            this.bookIDTextBox.Location = new System.Drawing.Point(189, 41);
            this.bookIDTextBox.Name = "bookIDTextBox";
            this.bookIDTextBox.Size = new System.Drawing.Size(294, 26);
            this.bookIDTextBox.TabIndex = 1;
            // 
            // commitButton
            // 
            this.commitButton.Location = new System.Drawing.Point(375, 73);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(108, 29);
            this.commitButton.TabIndex = 2;
            this.commitButton.Text = "Commit";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.commitButton_Click);
            // 
            // RemoveBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 136);
            this.Controls.Add(this.commitButton);
            this.Controls.Add(this.bookIDTextBox);
            this.Controls.Add(this.enterBookIDLabel);
            this.Name = "RemoveBook";
            this.Text = "RemoveBook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label enterBookIDLabel;
        private System.Windows.Forms.TextBox bookIDTextBox;
        private System.Windows.Forms.Button commitButton;
    }
}