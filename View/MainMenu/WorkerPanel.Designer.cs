using System;

namespace DatabaseApp
{
    partial class WorkerPanel
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
            this.searchClientButton = new System.Windows.Forms.Button();
            this.payPenaltyButton = new System.Windows.Forms.Button();
            this.searchForBooksButton = new System.Windows.Forms.Button();
            this.lendBookButton = new System.Windows.Forms.Button();
            this.returnBookButton = new System.Windows.Forms.Button();
            this.manageClientsLabel = new System.Windows.Forms.Label();
            this.manageBooksLabel = new System.Windows.Forms.Label();
            this.addBookButton = new System.Windows.Forms.Button();
            this.removeBookButton = new System.Windows.Forms.Button();
            this.addGenreButton = new System.Windows.Forms.Button();
            this.removeGenreButton = new System.Windows.Forms.Button();
            this.removeAuthorButton = new System.Windows.Forms.Button();
            this.addAuthorButton = new System.Windows.Forms.Button();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // searchClientButton
            // 
            this.searchClientButton.Location = new System.Drawing.Point(35, 93);
            this.searchClientButton.Name = "searchClientButton";
            this.searchClientButton.Size = new System.Drawing.Size(172, 31);
            this.searchClientButton.TabIndex = 0;
            this.searchClientButton.Text = "Search For Client";
            this.searchClientButton.UseVisualStyleBackColor = true;
            this.searchClientButton.Click += new System.EventHandler(this.searchClientButton_Click);
            // 
            // payPenaltyButton
            // 
            this.payPenaltyButton.Location = new System.Drawing.Point(35, 130);
            this.payPenaltyButton.Name = "payPenaltyButton";
            this.payPenaltyButton.Size = new System.Drawing.Size(172, 31);
            this.payPenaltyButton.TabIndex = 0;
            this.payPenaltyButton.Text = "Penalty Payment";
            this.payPenaltyButton.Click += new System.EventHandler(this.payPenaltyButton_Click);
            // 
            // searchForBooksButton
            // 
            this.searchForBooksButton.Location = new System.Drawing.Point(239, 93);
            this.searchForBooksButton.Name = "searchForBooksButton";
            this.searchForBooksButton.Size = new System.Drawing.Size(172, 31);
            this.searchForBooksButton.TabIndex = 1;
            this.searchForBooksButton.Text = "Search For Books";
            this.searchForBooksButton.UseVisualStyleBackColor = true;
            this.searchForBooksButton.Click += new System.EventHandler(this.searchForBooksButton_Click);
            // 
            // lendBookButton
            // 
            this.lendBookButton.Location = new System.Drawing.Point(239, 130);
            this.lendBookButton.Name = "lendBookButton";
            this.lendBookButton.Size = new System.Drawing.Size(172, 31);
            this.lendBookButton.TabIndex = 2;
            this.lendBookButton.Text = "Lend Book";
            this.lendBookButton.UseVisualStyleBackColor = true;
            this.lendBookButton.Click += new System.EventHandler(this.lendBookButton_Click);
            // 
            // returnBookButton
            // 
            this.returnBookButton.Location = new System.Drawing.Point(239, 167);
            this.returnBookButton.Name = "returnBookButton";
            this.returnBookButton.Size = new System.Drawing.Size(172, 31);
            this.returnBookButton.TabIndex = 3;
            this.returnBookButton.Text = "Return Book";
            this.returnBookButton.UseVisualStyleBackColor = true;
            this.returnBookButton.Click += new System.EventHandler(this.returnBookButton_Click);
            // 
            // manageClientsLabel
            // 
            this.manageClientsLabel.AutoSize = true;
            this.manageClientsLabel.Location = new System.Drawing.Point(62, 58);
            this.manageClientsLabel.Name = "manageClientsLabel";
            this.manageClientsLabel.Size = new System.Drawing.Size(119, 20);
            this.manageClientsLabel.TabIndex = 4;
            this.manageClientsLabel.Text = "Manage Clients";
            // 
            // manageBooksLabel
            // 
            this.manageBooksLabel.AutoSize = true;
            this.manageBooksLabel.Location = new System.Drawing.Point(265, 58);
            this.manageBooksLabel.Name = "manageBooksLabel";
            this.manageBooksLabel.Size = new System.Drawing.Size(116, 20);
            this.manageBooksLabel.TabIndex = 5;
            this.manageBooksLabel.Text = "Manage Books";
            // 
            // addBookButton
            // 
            this.addBookButton.Location = new System.Drawing.Point(239, 204);
            this.addBookButton.Name = "addBookButton";
            this.addBookButton.Size = new System.Drawing.Size(172, 31);
            this.addBookButton.TabIndex = 6;
            this.addBookButton.Text = "Add Book";
            this.addBookButton.UseVisualStyleBackColor = true;
            this.addBookButton.Click += new System.EventHandler(this.addBookButton_Click);
            // 
            // removeBookButton
            // 
            this.removeBookButton.Location = new System.Drawing.Point(239, 241);
            this.removeBookButton.Name = "removeBookButton";
            this.removeBookButton.Size = new System.Drawing.Size(172, 31);
            this.removeBookButton.TabIndex = 7;
            this.removeBookButton.Text = "Remove Book";
            this.removeBookButton.UseVisualStyleBackColor = true;
            this.removeBookButton.Click += new System.EventHandler(this.removeBookButton_Click);
            // 
            // addGenreButton
            // 
            this.addGenreButton.Location = new System.Drawing.Point(239, 278);
            this.addGenreButton.Name = "addGenreButton";
            this.addGenreButton.Size = new System.Drawing.Size(172, 31);
            this.addGenreButton.TabIndex = 8;
            this.addGenreButton.Text = "Add Genre";
            this.addGenreButton.UseVisualStyleBackColor = true;
            this.addGenreButton.Click += new System.EventHandler(this.addGenreButton_Click);
            // 
            // removeGenreButton
            // 
            this.removeGenreButton.Location = new System.Drawing.Point(239, 315);
            this.removeGenreButton.Name = "removeGenreButton";
            this.removeGenreButton.Size = new System.Drawing.Size(172, 31);
            this.removeGenreButton.TabIndex = 9;
            this.removeGenreButton.Text = "Remove Genre";
            this.removeGenreButton.UseVisualStyleBackColor = true;
            this.removeGenreButton.Click += new System.EventHandler(this.removeGenreButton_Click);
            // 
            // removeAuthorButton
            // 
            this.removeAuthorButton.Location = new System.Drawing.Point(239, 389);
            this.removeAuthorButton.Name = "removeAuthorButton";
            this.removeAuthorButton.Size = new System.Drawing.Size(172, 31);
            this.removeAuthorButton.TabIndex = 11;
            this.removeAuthorButton.Text = "Remove Author";
            this.removeAuthorButton.UseVisualStyleBackColor = true;
            this.removeAuthorButton.Click += new System.EventHandler(this.removeAuthorButton_Click);
            // 
            // addAuthorButton
            // 
            this.addAuthorButton.Location = new System.Drawing.Point(239, 352);
            this.addAuthorButton.Name = "addAuthorButton";
            this.addAuthorButton.Size = new System.Drawing.Size(172, 31);
            this.addAuthorButton.TabIndex = 10;
            this.addAuthorButton.Text = "Add Author";
            this.addAuthorButton.UseVisualStyleBackColor = true;
            this.addAuthorButton.Click += new System.EventHandler(this.addAuthorButton_Click);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Location = new System.Drawing.Point(31, 22);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(119, 20);
            this.welcomeLabel.TabIndex = 12;
            this.welcomeLabel.Text = "Manage Clients";
            // 
            // WorkerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 443);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.removeAuthorButton);
            this.Controls.Add(this.addAuthorButton);
            this.Controls.Add(this.removeGenreButton);
            this.Controls.Add(this.addGenreButton);
            this.Controls.Add(this.removeBookButton);
            this.Controls.Add(this.addBookButton);
            this.Controls.Add(this.manageBooksLabel);
            this.Controls.Add(this.manageClientsLabel);
            this.Controls.Add(this.payPenaltyButton);
            this.Controls.Add(this.returnBookButton);
            this.Controls.Add(this.lendBookButton);
            this.Controls.Add(this.searchForBooksButton);
            this.Controls.Add(this.searchClientButton);
            this.Name = "WorkerPanel";
            this.Text = "WorkerPanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public void SetWelcomeLabelText(string text)
        {
            welcomeLabel.Text = text;
        }

        private System.Windows.Forms.Button searchClientButton;
        private System.Windows.Forms.Button payPenaltyButton;
        private System.Windows.Forms.Button searchForBooksButton;
        private System.Windows.Forms.Button lendBookButton;
        private System.Windows.Forms.Button returnBookButton;
        private System.Windows.Forms.Label manageClientsLabel;
        private System.Windows.Forms.Label manageBooksLabel;
        private System.Windows.Forms.Button addBookButton;
        private System.Windows.Forms.Button removeBookButton;
        private System.Windows.Forms.Button addGenreButton;
        private System.Windows.Forms.Button removeGenreButton;
        private System.Windows.Forms.Button removeAuthorButton;
        private System.Windows.Forms.Button addAuthorButton;
        private System.Windows.Forms.Label welcomeLabel;
    }
}