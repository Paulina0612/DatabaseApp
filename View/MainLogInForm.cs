using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class MainLogInForm : Form
    {
        private int componentsLocation = 250;
        public MainLogInForm()
        {
            InitializeComponent();
        }

        private void LogInAsClientButton_Click(object sender, EventArgs e)
        {
            ClientLogInForm clientLogInForm = new ClientLogInForm();
            clientLogInForm.Show();
        }

        private void WorkerLogInAsWorkerButton_Click(object sender, EventArgs e)
        {
            nameLabel.Location = 
                new System.Drawing.Point(componentsLocation, nameLabel.Location.Y);
            firstNameTextBox.Location = 
                new System.Drawing.Point(componentsLocation, firstNameTextBox.Location.Y);
            lastNameLabel.Location = 
                new System.Drawing.Point(componentsLocation, lastNameLabel.Location.Y);
            lastNameTextBox.Location = 
                new System.Drawing.Point(componentsLocation, lastNameTextBox.Location.Y);
            passwordLabel.Location =
                new System.Drawing.Point(componentsLocation, passwordLabel.Location.Y);
            passwordTextBox.Location =
                new System.Drawing.Point(componentsLocation, passwordTextBox.Location.Y);
            workerLogInButton.Location =
                new System.Drawing.Point(componentsLocation, workerLogInButton.Location.Y);
        }

        private void RegisterClientButton_Click(object sender, EventArgs e)
        {
            ClientRegistration clientRegistration = new ClientRegistration();
            clientRegistration.Show();
        }

    }
}

