namespace DatabaseApp
{
    partial class RemoveGenre
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
            this.commitButton = new System.Windows.Forms.Button();
            this.enterBookIDLabel = new System.Windows.Forms.Label();
            this.genreNameComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // commitButton
            // 
            this.commitButton.Location = new System.Drawing.Point(364, 76);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(108, 29);
            this.commitButton.TabIndex = 5;
            this.commitButton.Text = "Commit";
            this.commitButton.UseVisualStyleBackColor = true;
            // 
            // enterBookIDLabel
            // 
            this.enterBookIDLabel.AutoSize = true;
            this.enterBookIDLabel.Location = new System.Drawing.Point(25, 39);
            this.enterBookIDLabel.Name = "enterBookIDLabel";
            this.enterBookIDLabel.Size = new System.Drawing.Size(98, 20);
            this.enterBookIDLabel.TabIndex = 3;
            this.enterBookIDLabel.Text = "Genre name";
            // 
            // genreNameComboBox
            // 
            this.genreNameComboBox.FormattingEnabled = true;
            this.genreNameComboBox.Location = new System.Drawing.Point(145, 31);
            this.genreNameComboBox.Name = "genreNameComboBox";
            this.genreNameComboBox.Size = new System.Drawing.Size(327, 28);
            this.genreNameComboBox.TabIndex = 6;
            // 
            // RemoveGenre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 160);
            this.Controls.Add(this.genreNameComboBox);
            this.Controls.Add(this.commitButton);
            this.Controls.Add(this.enterBookIDLabel);
            this.Name = "RemoveGenre";
            this.Text = "RemoveGenre";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button commitButton;
        private System.Windows.Forms.Label enterBookIDLabel;
        private System.Windows.Forms.ComboBox genreNameComboBox;
    }
}