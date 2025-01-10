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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.currentSalaryLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.newSalaryLabel = new System.Windows.Forms.Label();
            this.newSalaryTextBox = new System.Windows.Forms.TextBox();
            this.commitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(174, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(247, 28);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "PESEL ";
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(174, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(247, 26);
            this.textBox1.TabIndex = 3;
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
            this.commitButton.Location = new System.Drawing.Point(319, 146);
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
            this.ClientSize = new System.Drawing.Size(487, 207);
            this.Controls.Add(this.commitButton);
            this.Controls.Add(this.newSalaryTextBox);
            this.Controls.Add(this.newSalaryLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.currentSalaryLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "ChangeWorkerSalary";
            this.Text = "ChangeWorkerSalary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentSalaryLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label newSalaryLabel;
        private System.Windows.Forms.TextBox newSalaryTextBox;
        private System.Windows.Forms.Button commitButton;
    }
}