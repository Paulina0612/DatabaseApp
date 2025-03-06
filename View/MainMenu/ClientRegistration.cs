using System;
using System.Text;
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

            if (string.IsNullOrEmpty(firstNameTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(lastNameTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(emailTextBox.Text)) Program.IncorrectDataInformation();
            else
            {
                try
                {
                    bool ifSuccess = Program.communicationHandler.clientsHandler.ClientRegistration(
                        firstNameTextBox.Text, lastNameTextBox.Text, emailTextBox.Text, password);

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
