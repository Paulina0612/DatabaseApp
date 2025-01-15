namespace DatabaseApp
{
    partial class BooksCatalog
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.authorFirstNameLabel = new System.Windows.Forms.Label();
            this.authorFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.ISBNLabel = new System.Windows.Forms.Label();
            this.authorLastNameTextBox = new System.Windows.Forms.TextBox();
            this.authorLastNameLabel = new System.Windows.Forms.Label();
            this.ISBNTextBox = new System.Windows.Forms.TextBox();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.genreLabel = new System.Windows.Forms.Label();
            this.availabilityLabel = new System.Windows.Forms.Label();
            this.availabilityComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Title,
            this.Author,
            this.Genre,
            this.ISBN});
            this.dataGridView1.Location = new System.Drawing.Point(37, 182);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(812, 331);
            this.dataGridView1.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 150;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.MinimumWidth = 8;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 150;
            // 
            // Author
            // 
            this.Author.HeaderText = "Author";
            this.Author.MinimumWidth = 8;
            this.Author.Name = "Author";
            this.Author.Width = 150;
            // 
            // Genre
            // 
            this.Genre.HeaderText = "Genre";
            this.Genre.MinimumWidth = 8;
            this.Genre.Name = "Genre";
            this.Genre.Width = 150;
            // 
            // ISBN
            // 
            this.ISBN.HeaderText = "ISBN";
            this.ISBN.MinimumWidth = 8;
            this.ISBN.Name = "ISBN";
            this.ISBN.Width = 150;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(188, 52);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(267, 26);
            this.titleTextBox.TabIndex = 8;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(40, 52);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(38, 20);
            this.titleLabel.TabIndex = 9;
            this.titleLabel.Text = "Title";
            // 
            // authorFirstNameLabel
            // 
            this.authorFirstNameLabel.AutoSize = true;
            this.authorFirstNameLabel.Location = new System.Drawing.Point(40, 84);
            this.authorFirstNameLabel.Name = "authorFirstNameLabel";
            this.authorFirstNameLabel.Size = new System.Drawing.Size(142, 20);
            this.authorFirstNameLabel.TabIndex = 11;
            this.authorFirstNameLabel.Text = "Author\'s first name";
            // 
            // authorFirstNameTextBox
            // 
            this.authorFirstNameTextBox.Location = new System.Drawing.Point(188, 81);
            this.authorFirstNameTextBox.Name = "authorFirstNameTextBox";
            this.authorFirstNameTextBox.Size = new System.Drawing.Size(267, 26);
            this.authorFirstNameTextBox.TabIndex = 10;
            // 
            // ISBNLabel
            // 
            this.ISBNLabel.AutoSize = true;
            this.ISBNLabel.Location = new System.Drawing.Point(40, 151);
            this.ISBNLabel.Name = "ISBNLabel";
            this.ISBNLabel.Size = new System.Drawing.Size(47, 20);
            this.ISBNLabel.TabIndex = 13;
            this.ISBNLabel.Text = "ISBN";
            // 
            // authorLastNameTextBox
            // 
            this.authorLastNameTextBox.Location = new System.Drawing.Point(188, 113);
            this.authorLastNameTextBox.Name = "authorLastNameTextBox";
            this.authorLastNameTextBox.Size = new System.Drawing.Size(267, 26);
            this.authorLastNameTextBox.TabIndex = 12;
            // 
            // authorLastNameLabel
            // 
            this.authorLastNameLabel.AutoSize = true;
            this.authorLastNameLabel.Location = new System.Drawing.Point(40, 119);
            this.authorLastNameLabel.Name = "authorLastNameLabel";
            this.authorLastNameLabel.Size = new System.Drawing.Size(141, 20);
            this.authorLastNameLabel.TabIndex = 14;
            this.authorLastNameLabel.Text = "Author\'s last name";
            // 
            // ISBNTextBox
            // 
            this.ISBNTextBox.Location = new System.Drawing.Point(188, 145);
            this.ISBNTextBox.Name = "ISBNTextBox";
            this.ISBNTextBox.Size = new System.Drawing.Size(267, 26);
            this.ISBNTextBox.TabIndex = 15;
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(188, 20);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(267, 26);
            this.IDTextBox.TabIndex = 17;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(40, 23);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(26, 20);
            this.IDLabel.TabIndex = 16;
            this.IDLabel.Text = "ID";
            // 
            // genreComboBox
            // 
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(660, 18);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(189, 28);
            this.genreComboBox.TabIndex = 18;
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Location = new System.Drawing.Point(500, 26);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(54, 20);
            this.genreLabel.TabIndex = 19;
            this.genreLabel.Text = "Genre";
            // 
            // availabilityLabel
            // 
            this.availabilityLabel.AutoSize = true;
            this.availabilityLabel.Location = new System.Drawing.Point(500, 60);
            this.availabilityLabel.Name = "availabilityLabel";
            this.availabilityLabel.Size = new System.Drawing.Size(81, 20);
            this.availabilityLabel.TabIndex = 21;
            this.availabilityLabel.Text = "Availability";
            // 
            // availabilityComboBox
            // 
            this.availabilityComboBox.FormattingEnabled = true;
            this.availabilityComboBox.Location = new System.Drawing.Point(660, 52);
            this.availabilityComboBox.Name = "availabilityComboBox";
            this.availabilityComboBox.Size = new System.Drawing.Size(189, 28);
            this.availabilityComboBox.TabIndex = 20;
            // 
            // BooksCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 530);
            this.Controls.Add(this.availabilityLabel);
            this.Controls.Add(this.availabilityComboBox);
            this.Controls.Add(this.genreLabel);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.ISBNTextBox);
            this.Controls.Add(this.authorLastNameLabel);
            this.Controls.Add(this.ISBNLabel);
            this.Controls.Add(this.authorLastNameTextBox);
            this.Controls.Add(this.authorFirstNameLabel);
            this.Controls.Add(this.authorFirstNameTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BooksCatalog";
            this.Text = "BooksCatalog";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISBN;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label authorFirstNameLabel;
        private System.Windows.Forms.TextBox authorFirstNameTextBox;
        private System.Windows.Forms.Label ISBNLabel;
        private System.Windows.Forms.TextBox authorLastNameTextBox;
        private System.Windows.Forms.Label authorLastNameLabel;
        private System.Windows.Forms.TextBox ISBNTextBox;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.ComboBox genreComboBox;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.Label availabilityLabel;
        private System.Windows.Forms.ComboBox availabilityComboBox;
    }
}