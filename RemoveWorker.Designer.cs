namespace DatabaseApp
{
    partial class RemoveWorker
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
            this.workerDataComboBox = new System.Windows.Forms.ComboBox();
            this.workerDataLabel = new System.Windows.Forms.Label();
            this.commitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // workerDataComboBox
            // 
            this.workerDataComboBox.FormattingEnabled = true;
            this.workerDataComboBox.Location = new System.Drawing.Point(156, 47);
            this.workerDataComboBox.Name = "workerDataComboBox";
            this.workerDataComboBox.Size = new System.Drawing.Size(488, 28);
            this.workerDataComboBox.TabIndex = 0;
            // 
            // workerDataLabel
            // 
            this.workerDataLabel.AutoSize = true;
            this.workerDataLabel.Location = new System.Drawing.Point(65, 55);
            this.workerDataLabel.Name = "workerDataLabel";
            this.workerDataLabel.Size = new System.Drawing.Size(60, 20);
            this.workerDataLabel.TabIndex = 1;
            this.workerDataLabel.Text = "Worker";
            // 
            // commitButton
            // 
            this.commitButton.Location = new System.Drawing.Point(524, 81);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(120, 30);
            this.commitButton.TabIndex = 2;
            this.commitButton.Text = "Commit";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.commitButton_Click);
            // 
            // RemoveWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 151);
            this.Controls.Add(this.commitButton);
            this.Controls.Add(this.workerDataLabel);
            this.Controls.Add(this.workerDataComboBox);
            this.Name = "RemoveWorker";
            this.Text = "RemoveWorker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox workerDataComboBox;
        private System.Windows.Forms.Label workerDataLabel;
        private System.Windows.Forms.Button commitButton;
    }
}