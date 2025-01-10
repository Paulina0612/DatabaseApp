namespace DatabaseApp
{
    partial class LendBook
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
            this.clientEmailLabel = new System.Windows.Forms.Label();
            this.clientEmailTextBox = new System.Windows.Forms.TextBox();
            this.catalogButton = new System.Windows.Forms.Button();
            this.bookIDLabel = new System.Windows.Forms.Label();
            this.bookIDTextBox = new System.Windows.Forms.TextBox();
            this.commitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clientEmailLabel
            // 
            this.clientEmailLabel.AutoSize = true;
            this.clientEmailLabel.Location = new System.Drawing.Point(45, 48);
            this.clientEmailLabel.Name = "clientEmailLabel";
            this.clientEmailLabel.Size = new System.Drawing.Size(146, 20);
            this.clientEmailLabel.TabIndex = 0;
            this.clientEmailLabel.Text = "Enter client\'s e-mail";
            // 
            // clientEmailTextBox
            // 
            this.clientEmailTextBox.Location = new System.Drawing.Point(246, 42);
            this.clientEmailTextBox.Name = "clientEmailTextBox";
            this.clientEmailTextBox.Size = new System.Drawing.Size(417, 26);
            this.clientEmailTextBox.TabIndex = 1;
            // 
            // catalogButton
            // 
            this.catalogButton.Location = new System.Drawing.Point(49, 80);
            this.catalogButton.Name = "catalogButton";
            this.catalogButton.Size = new System.Drawing.Size(142, 36);
            this.catalogButton.TabIndex = 2;
            this.catalogButton.Text = "Catalog";
            this.catalogButton.UseVisualStyleBackColor = true;
            // 
            // bookIDLabel
            // 
            this.bookIDLabel.AutoSize = true;
            this.bookIDLabel.Location = new System.Drawing.Point(242, 80);
            this.bookIDLabel.Name = "bookIDLabel";
            this.bookIDLabel.Size = new System.Drawing.Size(108, 20);
            this.bookIDLabel.TabIndex = 3;
            this.bookIDLabel.Text = "Enter book ID";
            // 
            // bookIDTextBox
            // 
            this.bookIDTextBox.Location = new System.Drawing.Point(379, 74);
            this.bookIDTextBox.Name = "bookIDTextBox";
            this.bookIDTextBox.Size = new System.Drawing.Size(284, 26);
            this.bookIDTextBox.TabIndex = 4;
            // 
            // commitButton
            // 
            this.commitButton.Location = new System.Drawing.Point(556, 106);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(107, 39);
            this.commitButton.TabIndex = 5;
            this.commitButton.Text = "Commit";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.commitButton_Click);
            // 
            // LendBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 174);
            this.Controls.Add(this.commitButton);
            this.Controls.Add(this.bookIDTextBox);
            this.Controls.Add(this.bookIDLabel);
            this.Controls.Add(this.catalogButton);
            this.Controls.Add(this.clientEmailTextBox);
            this.Controls.Add(this.clientEmailLabel);
            this.Name = "LendBook";
            this.Text = "LendBook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label clientEmailLabel;
        private System.Windows.Forms.TextBox clientEmailTextBox;
        private System.Windows.Forms.Button catalogButton;
        private System.Windows.Forms.Label bookIDLabel;
        private System.Windows.Forms.TextBox bookIDTextBox;
        private System.Windows.Forms.Button commitButton;
    }
}