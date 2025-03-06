namespace DatabaseApp.View.WorkerAndDirectorPanel.ManagingWorkers
{
    partial class ChangeWorkersManager
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
            this.workerComboBox = new System.Windows.Forms.ComboBox();
            this.workerLabel = new System.Windows.Forms.Label();
            this.commitButton = new System.Windows.Forms.Button();
            this.managerComboBox = new System.Windows.Forms.ComboBox();
            this.newManagerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // workerComboBox
            // 
            this.workerComboBox.FormattingEnabled = true;
            this.workerComboBox.Location = new System.Drawing.Point(191, 31);
            this.workerComboBox.Name = "workerComboBox";
            this.workerComboBox.Size = new System.Drawing.Size(319, 28);
            this.workerComboBox.TabIndex = 0;
            // 
            // workerLabel
            // 
            this.workerLabel.AutoSize = true;
            this.workerLabel.Location = new System.Drawing.Point(76, 39);
            this.workerLabel.Name = "workerLabel";
            this.workerLabel.Size = new System.Drawing.Size(109, 20);
            this.workerLabel.TabIndex = 1;
            this.workerLabel.Text = "Select Worker";
            // 
            // commitButton
            // 
            this.commitButton.Location = new System.Drawing.Point(397, 99);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(113, 31);
            this.commitButton.TabIndex = 2;
            this.commitButton.Text = "Commit";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.commitButton_Click);
            // 
            // managerComboBox
            // 
            this.managerComboBox.FormattingEnabled = true;
            this.managerComboBox.Location = new System.Drawing.Point(191, 65);
            this.managerComboBox.Name = "managerComboBox";
            this.managerComboBox.Size = new System.Drawing.Size(319, 28);
            this.managerComboBox.TabIndex = 3;
            // 
            // newManagerLabel
            // 
            this.newManagerLabel.AutoSize = true;
            this.newManagerLabel.Location = new System.Drawing.Point(29, 73);
            this.newManagerLabel.Name = "newManagerLabel";
            this.newManagerLabel.Size = new System.Drawing.Size(156, 20);
            this.newManagerLabel.TabIndex = 4;
            this.newManagerLabel.Text = "Select New Manager";
            // 
            // ChangeWorkersManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 152);
            this.Controls.Add(this.newManagerLabel);
            this.Controls.Add(this.managerComboBox);
            this.Controls.Add(this.commitButton);
            this.Controls.Add(this.workerLabel);
            this.Controls.Add(this.workerComboBox);
            this.Name = "ChangeWorkersManager";
            this.Text = "ChangeWorkersManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox workerComboBox;
        private System.Windows.Forms.Label workerLabel;
        private System.Windows.Forms.Button commitButton;
        private System.Windows.Forms.ComboBox managerComboBox;
        private System.Windows.Forms.Label newManagerLabel;
    }
}