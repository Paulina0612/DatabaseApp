namespace DatabaseApp
{
    partial class AddGenre
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
            this.genreNameTextBox = new System.Windows.Forms.TextBox();
            this.enterGenreNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // commitButton
            // 
            this.commitButton.Location = new System.Drawing.Point(375, 81);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(108, 29);
            this.commitButton.TabIndex = 5;
            this.commitButton.Text = "Commit";
            this.commitButton.UseVisualStyleBackColor = true;
            // 
            // genreNameTextBox
            // 
            this.genreNameTextBox.Location = new System.Drawing.Point(189, 38);
            this.genreNameTextBox.Name = "genreNameTextBox";
            this.genreNameTextBox.Size = new System.Drawing.Size(294, 26);
            this.genreNameTextBox.TabIndex = 4;
            // 
            // enterGenreNameLabel
            // 
            this.enterGenreNameLabel.AutoSize = true;
            this.enterGenreNameLabel.Location = new System.Drawing.Point(36, 44);
            this.enterGenreNameLabel.Name = "enterGenreNameLabel";
            this.enterGenreNameLabel.Size = new System.Drawing.Size(137, 20);
            this.enterGenreNameLabel.TabIndex = 3;
            this.enterGenreNameLabel.Text = "Enter genre name";
            // 
            // AddGenre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 159);
            this.Controls.Add(this.commitButton);
            this.Controls.Add(this.genreNameTextBox);
            this.Controls.Add(this.enterGenreNameLabel);
            this.Name = "AddGenre";
            this.Text = "AddGenre";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button commitButton;
        private System.Windows.Forms.TextBox genreNameTextBox;
        private System.Windows.Forms.Label enterGenreNameLabel;
    }
}