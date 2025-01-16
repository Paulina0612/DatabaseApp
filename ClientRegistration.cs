using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class ClientRegistration : Form
    {
        public ClientRegistration()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNameTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(lastNameTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(emailTextBox.Text)) Program.IncorrectDataInformation();
            else
            {
                Program.communicationHandler.ClientRegistration(firstNameTextBox.Text, lastNameTextBox.Text, emailTextBox.Text);
                MessageBox.Show("Registration successful.");
            }
        }
    }
}
