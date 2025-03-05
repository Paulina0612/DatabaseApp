namespace DatabaseApp
{
    partial class WorkerLogInForm
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
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.logInButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(144, 42);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(344, 26);
            this.firstNameTextBox.TabIndex = 14;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(38, 48);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(84, 20);
            this.nameLabel.TabIndex = 13;
            this.nameLabel.Text = "First name";
            // 
            // logInButton
            // 
            this.logInButton.Location = new System.Drawing.Point(326, 137);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(164, 38);
            this.logInButton.TabIndex = 12;
            this.logInButton.Text = "Log In";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(144, 105);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(344, 26);
            this.passwordTextBox.TabIndex = 11;
            this.passwordTextBox.PasswordChar = '*';
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(144, 72);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(344, 26);
            this.lastNameTextBox.TabIndex = 10;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(38, 111);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(78, 20);
            this.passwordLabel.TabIndex = 9;
            this.passwordLabel.Text = "Password";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(38, 78);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(84, 20);
            this.lastNameLabel.TabIndex = 8;
            this.lastNameLabel.Text = "Last name";
            // 
            // WorkerLogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 208);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.logInButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.lastNameLabel);
            this.Name = "WorkerLogInForm";
            this.Text = "WorkerLogInForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button logInButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label lastNameLabel;


    }
}