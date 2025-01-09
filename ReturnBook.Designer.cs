namespace DatabaseApp
{
    partial class ReturnBook
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
            this.clientEmailTextBox = new System.Windows.Forms.TextBox();
            this.clientEmailLabel = new System.Windows.Forms.Label();
            this.bookIDLabel = new System.Windows.Forms.Label();
            this.bookIDTextBox = new System.Windows.Forms.TextBox();
            this.commitButton = new System.Windows.Forms.Button();
            this.penaltyCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // clientEmailTextBox
            // 
            this.clientEmailTextBox.Location = new System.Drawing.Point(205, 44);
            this.clientEmailTextBox.Name = "clientEmailTextBox";
            this.clientEmailTextBox.Size = new System.Drawing.Size(392, 26);
            this.clientEmailTextBox.TabIndex = 0;
            // 
            // clientEmailLabel
            // 
            this.clientEmailLabel.AutoSize = true;
            this.clientEmailLabel.Location = new System.Drawing.Point(30, 47);
            this.clientEmailLabel.Name = "clientEmailLabel";
            this.clientEmailLabel.Size = new System.Drawing.Size(146, 20);
            this.clientEmailLabel.TabIndex = 1;
            this.clientEmailLabel.Text = "Enter client\'s e-mail";
            // 
            // bookIDLabel
            // 
            this.bookIDLabel.AutoSize = true;
            this.bookIDLabel.Location = new System.Drawing.Point(30, 99);
            this.bookIDLabel.Name = "bookIDLabel";
            this.bookIDLabel.Size = new System.Drawing.Size(108, 20);
            this.bookIDLabel.TabIndex = 3;
            this.bookIDLabel.Text = "Enter book ID";
            // 
            // bookIDTextBox
            // 
            this.bookIDTextBox.Location = new System.Drawing.Point(205, 96);
            this.bookIDTextBox.Name = "bookIDTextBox";
            this.bookIDTextBox.Size = new System.Drawing.Size(392, 26);
            this.bookIDTextBox.TabIndex = 2;
            // 
            // commitButton
            // 
            this.commitButton.Location = new System.Drawing.Point(465, 145);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(132, 35);
            this.commitButton.TabIndex = 4;
            this.commitButton.Text = "Commit";
            this.commitButton.UseVisualStyleBackColor = true;
            // 
            // penaltyCheckBox
            // 
            this.penaltyCheckBox.AutoSize = true;
            this.penaltyCheckBox.Location = new System.Drawing.Point(300, 151);
            this.penaltyCheckBox.Name = "penaltyCheckBox";
            this.penaltyCheckBox.Size = new System.Drawing.Size(134, 24);
            this.penaltyCheckBox.TabIndex = 5;
            this.penaltyCheckBox.Text = "Penalty payed";
            this.penaltyCheckBox.UseVisualStyleBackColor = true;
            // 
            // ReturnBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 231);
            this.Controls.Add(this.penaltyCheckBox);
            this.Controls.Add(this.commitButton);
            this.Controls.Add(this.bookIDLabel);
            this.Controls.Add(this.bookIDTextBox);
            this.Controls.Add(this.clientEmailLabel);
            this.Controls.Add(this.clientEmailTextBox);
            this.Name = "ReturnBook";
            this.Text = "ReturnBook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox clientEmailTextBox;
        private System.Windows.Forms.Label clientEmailLabel;
        private System.Windows.Forms.Label bookIDLabel;
        private System.Windows.Forms.TextBox bookIDTextBox;
        private System.Windows.Forms.Button commitButton;
        private System.Windows.Forms.CheckBox penaltyCheckBox;
    }
}