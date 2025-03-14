

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
            this.clientsLogInButton = new System.Windows.Forms.Button();
            this.cardNumberTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.cardNumberLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.clientEmailTextBox = new System.Windows.Forms.TextBox();
            this.clientLastNameTextBox = new System.Windows.Forms.TextBox();
            this.clientFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.clientEmailLabel = new System.Windows.Forms.Label();
            this.clientLastNameLabel = new System.Windows.Forms.Label();
            this.clientFirstNameLabel = new System.Windows.Forms.Label();
            this.registerButton = new System.Windows.Forms.Button();
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
            this.label2.Size = new System.Drawing.Size(132, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Our Library";
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
            this.firstNameTextBox.Location = new System.Drawing.Point(32723, Program.y[1]);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(Program.textBoxWidth, 26);
            this.firstNameTextBox.TabIndex = 21;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(32723, Program.y[0]);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(88, 20);
            this.nameLabel.TabIndex = 20;
            this.nameLabel.Text = "First name";
            // 
            // workerLogInButton
            // 
            this.workerLogInButton.BackColor = System.Drawing.Color.Linen;
            this.workerLogInButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.workerLogInButton.Location = new System.Drawing.Point(32723, Program.y[6]);
            this.workerLogInButton.Name = "workerLogInButton";
            this.workerLogInButton.Size = new System.Drawing.Size(100, 26);
            this.workerLogInButton.TabIndex = 19;
            this.workerLogInButton.Text = "Log In";
            this.workerLogInButton.UseVisualStyleBackColor = false;
            this.workerLogInButton.Click += new System.EventHandler(this.WorkerLogInButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(32756, Program.y[5]);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(Program.textBoxWidth, 26);
            this.passwordTextBox.TabIndex = 18;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(32723, Program.y[3]);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(Program.textBoxWidth, 26);
            this.lastNameTextBox.TabIndex = 17;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(32723, Program.y[4]);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(83, 20);
            this.passwordLabel.TabIndex = 16;
            this.passwordLabel.Text = "Password";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(32723, Program.y[2]);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(86, 20);
            this.lastNameLabel.TabIndex = 15;
            this.lastNameLabel.Text = "Last name";
            // 
            // clientsLogInButton
            // 
            this.clientsLogInButton.BackColor = System.Drawing.Color.Linen;
            this.clientsLogInButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clientsLogInButton.Location = new System.Drawing.Point(32723, Program.y[4]);
            this.clientsLogInButton.Name = "clientsLogInButton";
            this.clientsLogInButton.Size = new System.Drawing.Size(100, 26);
            this.clientsLogInButton.TabIndex = 26;
            this.clientsLogInButton.Text = "Log In";
            this.clientsLogInButton.UseVisualStyleBackColor = false;
            this.clientsLogInButton.Click += new System.EventHandler(this.ClientLogInButton_Click);
            // 
            // cardNumberTextBox
            // 
            this.cardNumberTextBox.Location = new System.Drawing.Point(32723, Program.y[3]);
            this.cardNumberTextBox.Name = "cardNumberTextBox";
            this.cardNumberTextBox.Size = new System.Drawing.Size(Program.textBoxWidth, 26);
            this.cardNumberTextBox.TabIndex = 25;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(32723, Program.y[1]);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(Program.textBoxWidth, 26);
            this.emailTextBox.TabIndex = 24;
            // 
            // cardNumberLabel
            // 
            this.cardNumberLabel.AutoSize = true;
            this.cardNumberLabel.Location = new System.Drawing.Point(32723, Program.y[2]);
            this.cardNumberLabel.Name = "cardNumberLabel";
            this.cardNumberLabel.Size = new System.Drawing.Size(111, 20);
            this.cardNumberLabel.TabIndex = 23;
            this.cardNumberLabel.Text = "Card Number";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(32723, Program.y[0]);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(50, 20);
            this.emailLabel.TabIndex = 22;
            this.emailLabel.Text = "Email";
            // 
            // clientEmailTextBox
            // 
            this.clientEmailTextBox.Location = new System.Drawing.Point(Program.MAX, Program.y[5]);
            this.clientEmailTextBox.Name = "clientEmailTextBox";
            this.clientEmailTextBox.Size = new System.Drawing.Size(Program.textBoxWidth, 26);
            this.clientEmailTextBox.TabIndex = 33;
            // 
            // clientLastNameTextBox
            // 
            this.clientLastNameTextBox.Location = new System.Drawing.Point(Program.MAX, Program.y[3]);
            this.clientLastNameTextBox.Name = "clientLastNameTextBox";
            this.clientLastNameTextBox.Size = new System.Drawing.Size(Program.textBoxWidth, 26);
            this.clientLastNameTextBox.TabIndex = 32;
            // 
            // clientFirstNameTextBox
            // 
            this.clientFirstNameTextBox.Location = new System.Drawing.Point(Program.MAX, Program.y[1]);
            this.clientFirstNameTextBox.Name = "clientFirstNameTextBox";
            this.clientFirstNameTextBox.Size = new System.Drawing.Size(Program.textBoxWidth, 26);
            this.clientFirstNameTextBox.TabIndex = 31;
            // 
            // clientEmailLabel
            // 
            this.clientEmailLabel.AutoSize = true;
            this.clientEmailLabel.Location = new System.Drawing.Point(Program.MAX, Program.y[4]);
            this.clientEmailLabel.Name = "clientEmailLabel";
            this.clientEmailLabel.Size = new System.Drawing.Size(55, 20);
            this.clientEmailLabel.TabIndex = 30;
            this.clientEmailLabel.Text = "E-mail";
            // 
            // clientLastNameLabel
            // 
            this.clientLastNameLabel.AutoSize = true;
            this.clientLastNameLabel.Location = new System.Drawing.Point(Program.MAX, Program.y[2]);
            this.clientLastNameLabel.Name = "clientLastNameLabel";
            this.clientLastNameLabel.Size = new System.Drawing.Size(86, 20);
            this.clientLastNameLabel.TabIndex = 29;
            this.clientLastNameLabel.Text = "Last name";
            // 
            // clientFirstNameLabel
            // 
            this.clientFirstNameLabel.AutoSize = true;
            this.clientFirstNameLabel.Location = new System.Drawing.Point(Program.MAX, Program.y[0]);
            this.clientFirstNameLabel.Name = "clientFirstNameLabel";
            this.clientFirstNameLabel.Size = new System.Drawing.Size(88, 20);
            this.clientFirstNameLabel.TabIndex = 28;
            this.clientFirstNameLabel.Text = "First name";
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.Linen;
            this.registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.registerButton.Location = new System.Drawing.Point(Program.MAX, Program.y[6]);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(100, 26);
            this.registerButton.TabIndex = 27;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.ClientRegistrationButton_Click);
            // 
            // MainLogInForm
            // 
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(619, 254);
            this.Controls.Add(this.clientEmailTextBox);
            this.Controls.Add(this.clientLastNameTextBox);
            this.Controls.Add(this.clientFirstNameTextBox);
            this.Controls.Add(this.clientEmailLabel);
            this.Controls.Add(this.clientLastNameLabel);
            this.Controls.Add(this.clientFirstNameLabel);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.clientsLogInButton);
            this.Controls.Add(this.cardNumberTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.cardNumberLabel);
            this.Controls.Add(this.emailLabel);
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
        private System.Windows.Forms.Button clientsLogInButton;
        private System.Windows.Forms.TextBox cardNumberTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label cardNumberLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox clientEmailTextBox;
        private System.Windows.Forms.TextBox clientLastNameTextBox;
        private System.Windows.Forms.TextBox clientFirstNameTextBox;
        private System.Windows.Forms.Label clientEmailLabel;
        private System.Windows.Forms.Label clientLastNameLabel;
        private System.Windows.Forms.Label clientFirstNameLabel;
        private System.Windows.Forms.Button registerButton;
    }
}

