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
            this.LogInAsClientButton = new System.Windows.Forms.Button();
            this.LogInAsWorkerButton = new System.Windows.Forms.Button();
            this.RegisterClientButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogInAsClientButton
            // 
            this.LogInAsClientButton.Location = new System.Drawing.Point(68, 42);
            this.LogInAsClientButton.Name = "LogInAsClientButton";
            this.LogInAsClientButton.Size = new System.Drawing.Size(161, 67);
            this.LogInAsClientButton.TabIndex = 0;
            this.LogInAsClientButton.Text = "Log In As Client";
            this.LogInAsClientButton.UseVisualStyleBackColor = true;
            this.LogInAsClientButton.Click += new System.EventHandler(this.LogInAsClientButton_Click);
            // 
            // LogInAsWorkerButton
            // 
            this.LogInAsWorkerButton.Location = new System.Drawing.Point(68, 139);
            this.LogInAsWorkerButton.Name = "LogInAsWorkerButton";
            this.LogInAsWorkerButton.Size = new System.Drawing.Size(161, 66);
            this.LogInAsWorkerButton.TabIndex = 1;
            this.LogInAsWorkerButton.Text = "Log In As Worker";
            this.LogInAsWorkerButton.UseVisualStyleBackColor = true;
            this.LogInAsWorkerButton.Click += new System.EventHandler(this.LogInAsWorkerButton_Click);
            // 
            // RegisterClientButton
            // 
            this.RegisterClientButton.Location = new System.Drawing.Point(68, 237);
            this.RegisterClientButton.Name = "RegisterClientButton";
            this.RegisterClientButton.Size = new System.Drawing.Size(161, 64);
            this.RegisterClientButton.TabIndex = 3;
            this.RegisterClientButton.Text = "Register";
            this.RegisterClientButton.UseVisualStyleBackColor = true;
            this.RegisterClientButton.Click += new System.EventHandler(this.RegisterClientButton_Click);
            // 
            // MainLogInForm
            // 
            this.ClientSize = new System.Drawing.Size(314, 356);
            this.Controls.Add(this.RegisterClientButton);
            this.Controls.Add(this.LogInAsWorkerButton);
            this.Controls.Add(this.LogInAsClientButton);
            this.Name = "MainLogInForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LogInAsClientButton;
        private System.Windows.Forms.Button LogInAsWorkerButton;
        private System.Windows.Forms.Button RegisterClientButton;
    }
}

