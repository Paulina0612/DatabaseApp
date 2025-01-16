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
                bool ifSuccessful = Program.communicationHandler.WorkerLogIn(ifDirector, firstNameTextBox.Text, lastNameTextBox.Text,
                    passwordTextBox.Text);

                if (ifSuccessful)
                {
                    if (ifDirector)
                    {
                        DirectorPanel directorPanel = new DirectorPanel();
                        directorPanel.Show();
                    }
                    else
                    {
                        WorkerPanel workerPanel = new WorkerPanel();
                        workerPanel.Show();
                    }
                }
                else Program.IncorrectDataInformation();
            }

        } //TODO: Dodac szyfrowanie

        private void directorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ifDirector = directorCheckBox.Checked;
        }
    }
}
