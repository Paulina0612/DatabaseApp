namespace DatabaseApp
{
    partial class PenaltyPayment
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
            this.commitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clientEmailLabel
            // 
            this.clientEmailLabel.AutoSize = true;
            this.clientEmailLabel.Location = new System.Drawing.Point(29, 42);
            this.clientEmailLabel.Name = "clientEmailLabel";
            this.clientEmailLabel.Size = new System.Drawing.Size(146, 20);
            this.clientEmailLabel.TabIndex = 3;
            this.clientEmailLabel.Text = "Enter client\'s e-mail";
            // 
            // clientEmailTextBox
            // 
            this.clientEmailTextBox.Location = new System.Drawing.Point(204, 39);
            this.clientEmailTextBox.Name = "clientEmailTextBox";
            this.clientEmailTextBox.Size = new System.Drawing.Size(392, 26);
            this.clientEmailTextBox.TabIndex = 2;
            // 
            // commitButton
            // 
            this.commitButton.Location = new System.Drawing.Point(484, 84);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(112, 36);
            this.commitButton.TabIndex = 4;
            this.commitButton.Text = "Commit";
            this.commitButton.UseVisualStyleBackColor = true;
            // 
            // PenaltyPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 164);
            this.Controls.Add(this.commitButton);
            this.Controls.Add(this.clientEmailLabel);
            this.Controls.Add(this.clientEmailTextBox);
            this.Name = "PenaltyPayment";
            this.Text = "PenaltyPayment";
            this.Load += new System.EventHandler(this.PenaltyPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label clientEmailLabel;
        private System.Windows.Forms.TextBox clientEmailTextBox;
        private System.Windows.Forms.Button commitButton;
    }
}