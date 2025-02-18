using System;
using System.Windows.Forms;

namespace DatabaseApp
{

    public partial class WorkerLogInForm : Form
    {
        private bool ifDirector = false;

        public WorkerLogInForm()
        {
            InitializeComponent();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNameTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(lastNameTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(passwordTextBox.Text)) Program.IncorrectDataInformation();
            else
            {
                bool ifSuccessful = Program.communicationHandler.workersHandler.WorkerLogIn( firstNameTextBox.Text, lastNameTextBox.Text,
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
                        workerPanel.SetWelcomeLabelText("Welcome, " + firstNameTextBox.Text  + " " + lastNameTextBox.Text + "!");
                        workerPanel.Show();
                    }
                }
            }

        } //TODO: Dodac szyfrowanie

    }
}
