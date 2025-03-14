using System;
using System.ComponentModel;
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
            RestetForm();
            int i = 0;
            emailLabel.Location = 
                new System.Drawing.Point(componentsLocation, y[i++]);
            emailTextBox.Location = 
                new System.Drawing.Point(componentsLocation, y[i++]);
            cardNumberLabel.Location =
                new System.Drawing.Point(componentsLocation, y[i++]);
            cardNumberTextBox.Location =
                new System.Drawing.Point(componentsLocation, y[i++]);
            clientsLogInButton.Location =
                new System.Drawing.Point(componentsLocation + firstNameTextBox.Width - workerLogInButton.Width,
                y[i++]);
        }

        private void WorkerLogInAsWorkerButton_Click(object sender, EventArgs e)
        {
            RestetForm();
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
                new System.Drawing.Point(componentsLocation+firstNameTextBox.Width-workerLogInButton.Width, 
                workerLogInButton.Location.Y);
        }

        private void RegisterClientButton_Click(object sender, EventArgs e)
        {
            RestetForm();
            clientFirstNameLabel.Location =
                new System.Drawing.Point(componentsLocation, nameLabel.Location.Y);
            clientFirstNameTextBox.Location =
                new System.Drawing.Point(componentsLocation, firstNameTextBox.Location.Y);
            clientLastNameLabel.Location =
                new System.Drawing.Point(componentsLocation, lastNameLabel.Location.Y);
            clientLastNameTextBox.Location =
                new System.Drawing.Point(componentsLocation, lastNameTextBox.Location.Y);
            clientEmailLabel.Location =
                new System.Drawing.Point(componentsLocation, passwordLabel.Location.Y);
            clientEmailTextBox.Location =
                new System.Drawing.Point(componentsLocation, passwordTextBox.Location.Y);
            registerButton.Location =
                new System.Drawing.Point(componentsLocation + firstNameTextBox.Width - registerButton.Width,
                workerLogInButton.Location.Y);
        }

        private void RestetForm()
        {
            emailLabel.Location =
                new System.Drawing.Point(Program.MAX, emailLabel.Location.Y);
            emailTextBox.Location =
                new System.Drawing.Point(Program.MAX, emailTextBox.Location.Y);
            cardNumberLabel.Location =
                new System.Drawing.Point(Program.MAX, cardNumberLabel.Location.Y);
            cardNumberTextBox.Location =
                new System.Drawing.Point(Program.MAX, cardNumberTextBox.Location.Y);
            clientsLogInButton.Location =
                new System.Drawing.Point(Program.MAX, clientsLogInButton.Location.Y);
            nameLabel.Location =
                new System.Drawing.Point(Program.MAX, nameLabel.Location.Y);
            firstNameTextBox.Location =
                new System.Drawing.Point(Program.MAX, firstNameTextBox.Location.Y);
            lastNameLabel.Location =
                new System.Drawing.Point(Program.MAX, lastNameLabel.Location.Y);
            lastNameTextBox.Location =
                new System.Drawing.Point(Program.MAX, lastNameTextBox.Location.Y);
            passwordLabel.Location =
                new System.Drawing.Point(Program.MAX, passwordLabel.Location.Y);
            passwordTextBox.Location =
                new System.Drawing.Point(Program.MAX, passwordTextBox.Location.Y);
            workerLogInButton.Location =
                new System.Drawing.Point(Program.MAX, workerLogInButton.Location.Y);
            clientFirstNameLabel.Location =
                new System.Drawing.Point(Program.MAX, nameLabel.Location.Y);
            clientFirstNameTextBox.Location =
                new System.Drawing.Point(Program.MAX, firstNameTextBox.Location.Y);
            clientLastNameLabel.Location =
                new System.Drawing.Point(Program.MAX, lastNameLabel.Location.Y);
            clientLastNameTextBox.Location =
                new System.Drawing.Point(Program.MAX, lastNameTextBox.Location.Y);
            clientEmailLabel.Location =
                new System.Drawing.Point(Program.MAX, passwordLabel.Location.Y);
            clientEmailTextBox.Location =
                new System.Drawing.Point(Program.MAX, passwordTextBox.Location.Y);
            registerButton.Location =
                new System.Drawing.Point(Program.MAX, workerLogInButton.Location.Y);
        }
    }
}

