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
            this.button1 = new System.Windows.Forms.Button();
            this.lendBookButton = new System.Windows.Forms.Button();
            this.returnBookButton = new System.Windows.Forms.Button();
            this.manageClientsLabel = new System.Windows.Forms.Label();
            this.manageBooksLabel = new System.Windows.Forms.Label();
            this.addBookButton = new System.Windows.Forms.Button();
            this.deleteBookButton = new System.Windows.Forms.Button();
            this.addGenreButton = new System.Windows.Forms.Button();
            this.deleteGenreButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchClientButton
            // 
            this.searchClientButton.Location = new System.Drawing.Point(34, 62);
            this.searchClientButton.Name = "searchClientButton";
            this.searchClientButton.Size = new System.Drawing.Size(172, 31);
            this.searchClientButton.TabIndex = 0;
            this.searchClientButton.Text = "Search For Client";
            this.searchClientButton.UseVisualStyleBackColor = true;
            // 
            // payPenaltyButton
            // 
            this.payPenaltyButton.Location = new System.Drawing.Point(34, 99);
            this.payPenaltyButton.Name = "payPenaltyButton";
            this.payPenaltyButton.Size = new System.Drawing.Size(172, 31);
            this.payPenaltyButton.TabIndex = 0;
            this.payPenaltyButton.Text = "Penalty Payment";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(238, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Search For Books";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lendBookButton
            // 
            this.lendBookButton.Location = new System.Drawing.Point(238, 99);
            this.lendBookButton.Name = "lendBookButton";
            this.lendBookButton.Size = new System.Drawing.Size(172, 31);
            this.lendBookButton.TabIndex = 2;
            this.lendBookButton.Text = "Lend Book";
            this.lendBookButton.UseVisualStyleBackColor = true;
            // 
            // returnBookButton
            // 
            this.returnBookButton.Location = new System.Drawing.Point(238, 136);
            this.returnBookButton.Name = "returnBookButton";
            this.returnBookButton.Size = new System.Drawing.Size(172, 31);
            this.returnBookButton.TabIndex = 3;
            this.returnBookButton.Text = "Return Book";
            this.returnBookButton.UseVisualStyleBackColor = true;
            // 
            // manageClientsLabel
            // 
            this.manageClientsLabel.AutoSize = true;
            this.manageClientsLabel.Location = new System.Drawing.Point(61, 27);
            this.manageClientsLabel.Name = "manageClientsLabel";
            this.manageClientsLabel.Size = new System.Drawing.Size(119, 20);
            this.manageClientsLabel.TabIndex = 4;
            this.manageClientsLabel.Text = "Manage Clients";
            // 
            // manageBooksLabel
            // 
            this.manageBooksLabel.AutoSize = true;
            this.manageBooksLabel.Location = new System.Drawing.Point(264, 27);
            this.manageBooksLabel.Name = "manageBooksLabel";
            this.manageBooksLabel.Size = new System.Drawing.Size(116, 20);
            this.manageBooksLabel.TabIndex = 5;
            this.manageBooksLabel.Text = "Manage Books";
            // 
            // addBookButton
            // 
            this.addBookButton.Location = new System.Drawing.Point(238, 173);
            this.addBookButton.Name = "addBookButton";
            this.addBookButton.Size = new System.Drawing.Size(172, 31);
            this.addBookButton.TabIndex = 6;
            this.addBookButton.Text = "Add Book";
            this.addBookButton.UseVisualStyleBackColor = true;
            // 
            // deleteBookButton
            // 
            this.deleteBookButton.Location = new System.Drawing.Point(238, 210);
            this.deleteBookButton.Name = "deleteBookButton";
            this.deleteBookButton.Size = new System.Drawing.Size(172, 31);
            this.deleteBookButton.TabIndex = 7;
            this.deleteBookButton.Text = "Delete Book";
            this.deleteBookButton.UseVisualStyleBackColor = true;
            // 
            // addGenreButton
            // 
            this.addGenreButton.Location = new System.Drawing.Point(238, 247);
            this.addGenreButton.Name = "addGenreButton";
            this.addGenreButton.Size = new System.Drawing.Size(172, 31);
            this.addGenreButton.TabIndex = 8;
            this.addGenreButton.Text = "Add Genre";
            this.addGenreButton.UseVisualStyleBackColor = true;
            // 
            // deleteGenreButton
            // 
            this.deleteGenreButton.Location = new System.Drawing.Point(238, 284);
            this.deleteGenreButton.Name = "deleteGenreButton";
            this.deleteGenreButton.Size = new System.Drawing.Size(172, 31);
            this.deleteGenreButton.TabIndex = 9;
            this.deleteGenreButton.Text = "Delete Genre";
            this.deleteGenreButton.UseVisualStyleBackColor = true;
            // 
            // WorkerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 357);
            this.Controls.Add(this.deleteGenreButton);
            this.Controls.Add(this.addGenreButton);
            this.Controls.Add(this.deleteBookButton);
            this.Controls.Add(this.addBookButton);
            this.Controls.Add(this.manageBooksLabel);
            this.Controls.Add(this.manageClientsLabel);
            this.Controls.Add(this.payPenaltyButton);
            this.Controls.Add(this.returnBookButton);
            this.Controls.Add(this.lendBookButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.searchClientButton);
            this.Name = "WorkerPanel";
            this.Text = "WorkerPanel";
            this.Load += new System.EventHandler(this.WorkerPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchClientButton;
        private System.Windows.Forms.Button payPenaltyButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button lendBookButton;
        private System.Windows.Forms.Button returnBookButton;
        private System.Windows.Forms.Label manageClientsLabel;
        private System.Windows.Forms.Label manageBooksLabel;
        private System.Windows.Forms.Button addBookButton;
        private System.Windows.Forms.Button deleteBookButton;
        private System.Windows.Forms.Button addGenreButton;
        private System.Windows.Forms.Button deleteGenreButton;
    }
}