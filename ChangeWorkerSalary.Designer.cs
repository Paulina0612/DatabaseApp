namespace DatabaseApp
{
    partial class ChangeWorkerSalary
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
            this.currentSalaryLabel = new System.Windows.Forms.Label();
            this.currentSalaryTextBox = new System.Windows.Forms.TextBox();
            this.newSalaryLabel = new System.Windows.Forms.Label();
            this.newSalaryTextBox = new System.Windows.Forms.TextBox();
            this.commitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // workerDataComboBox
            // 
            this.workerDataComboBox.FormattingEnabled = true;
            this.workerDataComboBox.Location = new System.Drawing.Point(174, 33);
            this.workerDataComboBox.Name = "workerDataComboBox";
            this.workerDataComboBox.Size = new System.Drawing.Size(247, 28);
            this.workerDataComboBox.TabIndex = 0;
            this.workerDataComboBox.SelectedIndexChanged += new System.EventHandler(this.workerDataComboBox_SelectedIndexChanged);
            // 
            // workerDataLabel
            // 
            this.workerDataLabel.AutoSize = true;
            this.workerDataLabel.Location = new System.Drawing.Point(36, 41);
            this.workerDataLabel.Name = "workerDataLabel";
            this.workerDataLabel.Size = new System.Drawing.Size(96, 20);
            this.workerDataLabel.TabIndex = 1;
            this.workerDataLabel.Text = "Worker data";
            // 
            // currentSalaryLabel
            // 
            this.currentSalaryLabel.AutoSize = true;
            this.currentSalaryLabel.Location = new System.Drawing.Point(36, 73);
            this.currentSalaryLabel.Name = "currentSalaryLabel";
            this.currentSalaryLabel.Size = new System.Drawing.Size(110, 20);
            this.currentSalaryLabel.TabIndex = 2;
            this.currentSalaryLabel.Text = "Current Salary";
            // 
            // currentSalaryTextBox
            // 
            this.currentSalaryTextBox.Location = new System.Drawing.Point(174, 67);
            this.currentSalaryTextBox.Name = "currentSalaryTextBox";
            this.currentSalaryTextBox.Size = new System.Drawing.Size(247, 26);
            this.currentSalaryTextBox.TabIndex = 3;
            // 
            // newSalaryLabel
            // 
            this.newSalaryLabel.AutoSize = true;
            this.newSalaryLabel.Location = new System.Drawing.Point(36, 105);
            this.newSalaryLabel.Name = "newSalaryLabel";
            this.newSalaryLabel.Size = new System.Drawing.Size(92, 20);
            this.newSalaryLabel.TabIndex = 4;
            this.newSalaryLabel.Text = "New Salary ";
            // 
            // newSalaryTextBox
            // 
            this.newSalaryTextBox.Location = new System.Drawing.Point(174, 99);
            this.newSalaryTextBox.Name = "newSalaryTextBox";
            this.newSalaryTextBox.Size = new System.Drawing.Size(247, 26);
            this.newSalaryTextBox.TabIndex = 5;
            // 
            // commitButton
            // 
            this.commitButton.Location = new System.Drawing.Point(319, 131);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(102, 30);
            this.commitButton.TabIndex = 6;
            this.commitButton.Text = "Commit";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.commitButton_Click);
            // 
            // ChangeWorkerSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 193);
            this.Controls.Add(this.commitButton);
            this.Controls.Add(this.newSalaryTextBox);
            this.Controls.Add(this.newSalaryLabel);
            this.Controls.Add(this.currentSalaryTextBox);
            this.Controls.Add(this.currentSalaryLabel);
            this.Controls.Add(this.workerDataLabel);
            this.Controls.Add(this.workerDataComboBox);
            this.Name = "ChangeWorkerSalary";
            this.Text = "ChangeWorkerSalary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox workerDataComboBox;
        private System.Windows.Forms.Label workerDataLabel;
        private System.Windows.Forms.Label currentSalaryLabel;
        private System.Windows.Forms.TextBox currentSalaryTextBox;
        private System.Windows.Forms.Label newSalaryLabel;
        private System.Windows.Forms.TextBox newSalaryTextBox;
        private System.Windows.Forms.Button commitButton;
    }
}