using System;
using System.ComponentModel;
using System.Text;
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
                new System.Drawing.Point(componentsLocation, Program.y[i++]);
            emailTextBox.Location = 
                new System.Drawing.Point(componentsLocation, Program.y[i++]);
            cardNumberLabel.Location =
                new System.Drawing.Point(componentsLocation, Program.y[i++]);
            cardNumberTextBox.Location =
                new System.Drawing.Point(componentsLocation, Program.y[i++]);
            clientsLogInButton.Location =
                new System.Drawing.Point(componentsLocation + firstNameTextBox.Width - workerLogInButton.Width,
                Program.y[i++]);
        }

        private void WorkerLogInAsWorkerButton_Click(object sender, EventArgs e)
        {
            RestetForm();
            int i = 0;
            nameLabel.Location = 
                new System.Drawing.Point(componentsLocation, Program.y[i++]);
            firstNameTextBox.Location = 
                new System.Drawing.Point(componentsLocation, Program.y[i++]);
            lastNameLabel.Location = 
                new System.Drawing.Point(componentsLocation, Program.y[i++]);
            lastNameTextBox.Location = 
                new System.Drawing.Point(componentsLocation, Program.y[i++]);
            passwordLabel.Location =
                new System.Drawing.Point(componentsLocation, Program.y[i++]);
            passwordTextBox.Location =
                new System.Drawing.Point(componentsLocation, Program.y[i++]);
            workerLogInButton.Location =
                new System.Drawing.Point(componentsLocation+firstNameTextBox.Width-workerLogInButton.Width, 
                Program.y[i++]);
        }

        private void RegisterClientButton_Click(object sender, EventArgs e)
        {
            RestetForm();
            int i = 0;
            clientFirstNameLabel.Location =
                new System.Drawing.Point(componentsLocation, Program.y[i++]);
            clientFirstNameTextBox.Location =
                new System.Drawing.Point(componentsLocation, Program.y[i++]);
            clientLastNameLabel.Location =
                new System.Drawing.Point(componentsLocation, Program.y[i++]);
            clientLastNameTextBox.Location =
                new System.Drawing.Point(componentsLocation, Program.y[i++]);
            clientEmailLabel.Location =
                new System.Drawing.Point(componentsLocation, Program.y[i++]);
            clientEmailTextBox.Location =
                new System.Drawing.Point(componentsLocation, Program.y[i++]);
            registerButton.Location =
                new System.Drawing.Point(componentsLocation + firstNameTextBox.Width - registerButton.Width,
                Program.y[i++]);
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

        private void ClientLogInButton_Click(object sender, EventArgs e)
        {
            bool ifCardNumberNumeric = int.TryParse(cardNumberTextBox.Text, out int n);

            if (string.IsNullOrEmpty(emailTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(cardNumberTextBox.Text) && ifCardNumberNumeric && cardNumberTextBox.Text.Length != 7)
                Program.IncorrectDataInformation();
            else
            {
                bool ifSuccessful = Program.communicationHandler.clientsHandler.ClientLogIn(emailTextBox.Text, cardNumberTextBox.Text);

                if (ifSuccessful)
                {
                    ClientPanel clientPanel = new ClientPanel();
                    clientPanel.Show();
                }
                else MessageBox.Show("E-mail or card number incorrect.");
            }
        }

        private void WorkerLogInButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNameTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(lastNameTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(passwordTextBox.Text)) Program.IncorrectDataInformation();
            else
            {
                bool ifSuccessful = Program.communicationHandler.workersHandler.WorkerLogIn(firstNameTextBox.Text, lastNameTextBox.Text,
                    passwordTextBox.Text);

                if (ifSuccessful)
                {
                    if (Program.communicationHandler.workersHandler.IfDirector())
                    {
                        DirectorPanel directorPanel = new DirectorPanel();
                        directorPanel.SetWelcomeLabelText("Welcome, " + firstNameTextBox.Text + " " + lastNameTextBox.Text + "!");
                        directorPanel.Show();
                    }
                    else
                    {
                        WorkerPanel workerPanel = new WorkerPanel();
                        workerPanel.SetWelcomeLabelText("Welcome, " + firstNameTextBox.Text + " " + lastNameTextBox.Text + "!");
                        workerPanel.Show();
                    }
                }
            }
        }

        private void ClientRegistrationButton_Click(object sender, EventArgs e)
        {
            // Generating card number
            string chars = "0123456789";
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < 7; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            string password = sb.ToString();

            if (string.IsNullOrEmpty(clientFirstNameTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(clientLastNameTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(clientEmailTextBox.Text)) Program.IncorrectDataInformation();
            else
            {
                try
                {
                    bool ifSuccess = Program.communicationHandler.clientsHandler.ClientRegistration(
                        clientFirstNameTextBox.Text, clientLastNameTextBox.Text, clientEmailTextBox.Text, password);

                    if (ifSuccess)
                        MessageBox.Show("Client successfully added.\nGenerated password is: " + password);
                    else
                        MessageBox.Show("Adding client failed.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding client: {ex.Message}");
                }

            }
        }
    }
}

