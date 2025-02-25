namespace DatabaseApp
{
    partial class AddBook
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.ISBNLabel = new System.Windows.Forms.Label();
            this.genreLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.ISBNTextBox = new System.Windows.Forms.TextBox();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.commitButton = new System.Windows.Forms.Button();
            this.authorDataComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(18, 27);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(27, 13);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title";
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(18, 48);
            this.authorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(62, 13);
            this.authorLabel.TabIndex = 2;
            this.authorLabel.Text = "Author data";
            // 
            // ISBNLabel
            // 
            this.ISBNLabel.AutoSize = true;
            this.ISBNLabel.Location = new System.Drawing.Point(18, 69);
            this.ISBNLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ISBNLabel.Name = "ISBNLabel";
            this.ISBNLabel.Size = new System.Drawing.Size(32, 13);
            this.ISBNLabel.TabIndex = 3;
            this.ISBNLabel.Text = "ISBN";
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Location = new System.Drawing.Point(18, 91);
            this.genreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(36, 13);
            this.genreLabel.TabIndex = 4;
            this.genreLabel.Text = "Genre";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(89, 23);
            this.titleTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(257, 20);
            this.titleTextBox.TabIndex = 5;
            // 
            // ISBNTextBox
            // 
            this.ISBNTextBox.Location = new System.Drawing.Point(89, 65);
            this.ISBNTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ISBNTextBox.Name = "ISBNTextBox";
            this.ISBNTextBox.Size = new System.Drawing.Size(257, 20);
            this.ISBNTextBox.TabIndex = 7;
            // 
            // genreComboBox
            // 
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(89, 86);
            this.genreComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(257, 21);
            this.genreComboBox.TabIndex = 8;
            // 
            // commitButton
            // 
            this.commitButton.Location = new System.Drawing.Point(238, 108);
            this.commitButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(106, 20);
            this.commitButton.TabIndex = 9;
            this.commitButton.Text = "Commit";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.commitButton_Click);
            // 
            // authorDataComboBox
            // 
            this.authorDataComboBox.FormattingEnabled = true;
            this.authorDataComboBox.Location = new System.Drawing.Point(89, 43);
            this.authorDataComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.authorDataComboBox.Name = "authorDataComboBox";
            this.authorDataComboBox.Size = new System.Drawing.Size(257, 21);
            this.authorDataComboBox.TabIndex = 10;
            this.authorDataComboBox.SelectedIndexChanged += new System.EventHandler(this.authorDataComboBox_SelectedIndexChanged);
            // 
            // AddBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 148);
            this.Controls.Add(this.authorDataComboBox);
            this.Controls.Add(this.commitButton);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.ISBNTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.genreLabel);
            this.Controls.Add(this.ISBNLabel);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.titleLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AddBook";
            this.Text = "AddBook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label ISBNLabel;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox ISBNTextBox;
        private System.Windows.Forms.ComboBox genreComboBox;
        private System.Windows.Forms.Button commitButton;
        private System.Windows.Forms.ComboBox authorDataComboBox;
    }
}
