

namespace DatabaseApp
{
    partial class MainLogInForm
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
            this.RegisterClientButton = new System.Windows.Forms.Button();
            this.LogInAsWorkerButton = new System.Windows.Forms.Button();
            this.LogInAsClientButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.workerLogInButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RegisterClientButton
            // 
            this.RegisterClientButton.BackColor = System.Drawing.Color.Bisque;
            this.RegisterClientButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RegisterClientButton.Location = new System.Drawing.Point(24, 173);
            this.RegisterClientButton.Name = "RegisterClientButton";
            this.RegisterClientButton.Size = new System.Drawing.Size(161, 42);
            this.RegisterClientButton.TabIndex = 3;
            this.RegisterClientButton.Text = "Register";
            this.RegisterClientButton.UseVisualStyleBackColor = false;
            this.RegisterClientButton.Click += new System.EventHandler(this.RegisterClientButton_Click);
            // 
            // LogInAsWorkerButton
            // 
            this.LogInAsWorkerButton.BackColor = System.Drawing.Color.Bisque;
            this.LogInAsWorkerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LogInAsWorkerButton.Location = new System.Drawing.Point(24, 124);
            this.LogInAsWorkerButton.Name = "LogInAsWorkerButton";
            this.LogInAsWorkerButton.Size = new System.Drawing.Size(161, 43);
            this.LogInAsWorkerButton.TabIndex = 1;
            this.LogInAsWorkerButton.Text = "Log In As Worker";
            this.LogInAsWorkerButton.UseVisualStyleBackColor = false;
            this.LogInAsWorkerButton.Click += new System.EventHandler(this.WorkerLogInAsWorkerButton_Click);
            // 
            // LogInAsClientButton
            // 
            this.LogInAsClientButton.BackColor = System.Drawing.Color.Bisque;
            this.LogInAsClientButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LogInAsClientButton.Location = new System.Drawing.Point(24, 76);
            this.LogInAsClientButton.Name = "LogInAsClientButton";
            this.LogInAsClientButton.Size = new System.Drawing.Size(161, 42);
            this.LogInAsClientButton.TabIndex = 0;
            this.LogInAsClientButton.Text = "Log In As Client";
            this.LogInAsClientButton.UseVisualStyleBackColor = false;
            this.LogInAsClientButton.Click += new System.EventHandler(this.LogInAsClientButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSalmon;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.RegisterClientButton);
            this.panel1.Controls.Add(this.LogInAsWorkerButton);
            this.panel1.Controls.Add(this.LogInAsClientButton);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 363);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "My Library";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Welome to ";
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(32723, 49);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(344, 26);
            this.firstNameTextBox.TabIndex = 21;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(32723, 26);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(88, 20);
            this.nameLabel.TabIndex = 20;
            this.nameLabel.Text = "First name";
            // 
            // workerLogInButton
            // 
            this.workerLogInButton.BackColor = System.Drawing.Color.Linen;
            this.workerLogInButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.workerLogInButton.Location = new System.Drawing.Point(Program.MAX, 185);
            this.workerLogInButton.Name = "workerLogInButton";
            this.workerLogInButton.Size = new System.Drawing.Size(164, 38);
            this.workerLogInButton.TabIndex = 19;
            this.workerLogInButton.Text = "Log In";
            this.workerLogInButton.UseVisualStyleBackColor = false;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(32756, 153);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(344, 26);
            this.passwordTextBox.TabIndex = 18;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(32723, 101);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(344, 26);
            this.lastNameTextBox.TabIndex = 17;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(32723, 130);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(83, 20);
            this.passwordLabel.TabIndex = 16;
            this.passwordLabel.Text = "Password";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(32723, 78);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(86, 20);
            this.lastNameLabel.TabIndex = 15;
            this.lastNameLabel.Text = "Last name";
            // 
            // MainLogInForm
            // 
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(613, 254);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.workerLogInButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Bright", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainLogInForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LogInAsClientButton;
        private System.Windows.Forms.Button LogInAsWorkerButton;
        private System.Windows.Forms.Button RegisterClientButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button workerLogInButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label lastNameLabel;
    }
}

