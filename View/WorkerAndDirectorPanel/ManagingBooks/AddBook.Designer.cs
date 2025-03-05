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
            this.addNewTitleButton = new System.Windows.Forms.Button();
            this.authorDataComboBox = new System.Windows.Forms.ComboBox();
            this.addNewCopyButton = new System.Windows.Forms.Button();
            this.bookIDLabel = new System.Windows.Forms.Label();
            this.bookIDTextBox = new System.Windows.Forms.TextBox();
            this.catalogButton = new System.Windows.Forms.Button();
            this.titlesCatalogButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(27, 42);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(38, 20);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title";
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(27, 74);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(93, 20);
            this.authorLabel.TabIndex = 2;
            this.authorLabel.Text = "Author data";
            // 
            // ISBNLabel
            // 
            this.ISBNLabel.AutoSize = true;
            this.ISBNLabel.Location = new System.Drawing.Point(27, 106);
            this.ISBNLabel.Name = "ISBNLabel";
            this.ISBNLabel.Size = new System.Drawing.Size(47, 20);
            this.ISBNLabel.TabIndex = 3;
            this.ISBNLabel.Text = "ISBN";
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Location = new System.Drawing.Point(27, 140);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(54, 20);
            this.genreLabel.TabIndex = 4;
            this.genreLabel.Text = "Genre";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(134, 35);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(384, 26);
            this.titleTextBox.TabIndex = 5;
            // 
            // ISBNTextBox
            // 
            this.ISBNTextBox.Location = new System.Drawing.Point(134, 100);
            this.ISBNTextBox.Name = "ISBNTextBox";
            this.ISBNTextBox.Size = new System.Drawing.Size(384, 26);
            this.ISBNTextBox.TabIndex = 7;
            // 
            // genreComboBox
            // 
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(134, 132);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(384, 28);
            this.genreComboBox.TabIndex = 8;
            // 
            // addNewTitleButton
            // 
            this.addNewTitleButton.Location = new System.Drawing.Point(332, 166);
            this.addNewTitleButton.Name = "addNewTitleButton";
            this.addNewTitleButton.Size = new System.Drawing.Size(184, 39);
            this.addNewTitleButton.TabIndex = 9;
            this.addNewTitleButton.Text = "Add New Title";
            this.addNewTitleButton.UseVisualStyleBackColor = true;
            this.addNewTitleButton.Click += new System.EventHandler(this.addNewTitleButton_Click);
            // 
            // authorDataComboBox
            // 
            this.authorDataComboBox.FormattingEnabled = true;
            this.authorDataComboBox.Location = new System.Drawing.Point(134, 66);
            this.authorDataComboBox.Name = "authorDataComboBox";
            this.authorDataComboBox.Size = new System.Drawing.Size(384, 28);
            this.authorDataComboBox.TabIndex = 10;
            // 
            // addNewCopyButton
            // 
            this.addNewCopyButton.Location = new System.Drawing.Point(332, 243);
            this.addNewCopyButton.Name = "addNewCopyButton";
            this.addNewCopyButton.Size = new System.Drawing.Size(184, 37);
            this.addNewCopyButton.TabIndex = 13;
            this.addNewCopyButton.Text = "Add New Copy";
            this.addNewCopyButton.UseVisualStyleBackColor = true;
            this.addNewCopyButton.Click += new System.EventHandler(this.addNewCopyButton_Click);
            // 
            // bookIDLabel
            // 
            this.bookIDLabel.AutoSize = true;
            this.bookIDLabel.Location = new System.Drawing.Point(27, 217);
            this.bookIDLabel.Name = "bookIDLabel";
            this.bookIDLabel.Size = new System.Drawing.Size(67, 20);
            this.bookIDLabel.TabIndex = 11;
            this.bookIDLabel.Text = "Book ID";
            // 
            // bookIDTextBox
            // 
            this.bookIDTextBox.Location = new System.Drawing.Point(134, 211);
            this.bookIDTextBox.Name = "bookIDTextBox";
            this.bookIDTextBox.Size = new System.Drawing.Size(384, 26);
            this.bookIDTextBox.TabIndex = 14;
            // 
            // catalogButton
            // 
            this.catalogButton.Location = new System.Drawing.Point(134, 243);
            this.catalogButton.Name = "catalogButton";
            this.catalogButton.Size = new System.Drawing.Size(192, 37);
            this.catalogButton.TabIndex = 15;
            this.catalogButton.Text = "Catalog";
            this.catalogButton.UseVisualStyleBackColor = true;
            this.catalogButton.Click += new System.EventHandler(this.catalogButton_Click);
            // 
            // titlesCatalogButton
            // 
            this.titlesCatalogButton.Location = new System.Drawing.Point(134, 167);
            this.titlesCatalogButton.Name = "titlesCatalogButton";
            this.titlesCatalogButton.Size = new System.Drawing.Size(192, 37);
            this.titlesCatalogButton.TabIndex = 16;
            this.titlesCatalogButton.Text = "Titles Catalog";
            this.titlesCatalogButton.UseVisualStyleBackColor = true;
            this.titlesCatalogButton.Click += new System.EventHandler(this.titlesCatalogButton_Click);
            // 
            // AddBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 296);
            this.Controls.Add(this.titlesCatalogButton);
            this.Controls.Add(this.catalogButton);
            this.Controls.Add(this.bookIDTextBox);
            this.Controls.Add(this.addNewCopyButton);
            this.Controls.Add(this.bookIDLabel);
            this.Controls.Add(this.authorDataComboBox);
            this.Controls.Add(this.addNewTitleButton);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.ISBNTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.genreLabel);
            this.Controls.Add(this.ISBNLabel);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.titleLabel);
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
        private System.Windows.Forms.Button addNewTitleButton;
        private System.Windows.Forms.ComboBox authorDataComboBox;
        private System.Windows.Forms.Button addNewCopyButton;
        private System.Windows.Forms.Label bookIDLabel;
        private System.Windows.Forms.TextBox bookIDTextBox;
        private System.Windows.Forms.Button catalogButton;
        private System.Windows.Forms.Button titlesCatalogButton;
    }
}
