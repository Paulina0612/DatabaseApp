namespace DatabaseApp
{
    partial class ClientPanel
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
            this.historyButton = new System.Windows.Forms.Button();
            this.borrowedBooksButton = new System.Windows.Forms.Button();
            this.catalogButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // historyButton
            // 
            this.historyButton.Location = new System.Drawing.Point(39, 42);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(165, 40);
            this.historyButton.TabIndex = 0;
            this.historyButton.Text = "History";
            this.historyButton.UseVisualStyleBackColor = true;
            // 
            // borrowedBooksButton
            // 
            this.borrowedBooksButton.Location = new System.Drawing.Point(39, 88);
            this.borrowedBooksButton.Name = "borrowedBooksButton";
            this.borrowedBooksButton.Size = new System.Drawing.Size(165, 40);
            this.borrowedBooksButton.TabIndex = 1;
            this.borrowedBooksButton.Text = "Borrowed Books";
            this.borrowedBooksButton.UseVisualStyleBackColor = true;
            // 
            // catalogButton
            // 
            this.catalogButton.Location = new System.Drawing.Point(39, 134);
            this.catalogButton.Name = "catalogButton";
            this.catalogButton.Size = new System.Drawing.Size(165, 40);
            this.catalogButton.TabIndex = 2;
            this.catalogButton.Text = "Catalog";
            this.catalogButton.UseVisualStyleBackColor = true;
            // 
            // ClientPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 224);
            this.Controls.Add(this.catalogButton);
            this.Controls.Add(this.borrowedBooksButton);
            this.Controls.Add(this.historyButton);
            this.Name = "ClientPanel";
            this.Text = "ClientPanel";
            this.Load += new System.EventHandler(this.ClientPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button historyButton;
        private System.Windows.Forms.Button borrowedBooksButton;
        private System.Windows.Forms.Button catalogButton;
    }
}