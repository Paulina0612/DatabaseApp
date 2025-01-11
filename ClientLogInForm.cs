using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class ClientLogInForm : Forms
    {
        public ClientLogInForm()
        {
            InitializeComponent();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            bool ifCardNumberNumeric = int.TryParse(cardNumberTextBox.Text, out int n);

            if (string.IsNullOrEmpty(emailTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(cardNumberTextBox.Text) && ifCardNumberNumeric && cardNumberTextBox.Text.Length != 7)
                Program.IncorrectDataInformation();
            else
            {
                bool ifSuccessful = communicationHandler.ClientLogIn(emailTextBox.Text, cardNumberTextBox.Text);

                if (ifSuccessful)
                {
                    ClientPanel clientPanel = new ClientPanel();
                    clientPanel.Show();
                    this.Close();
                }
                else MessageBox.Show("E-mail or card number incorrect.");
            }
        }
    }
}
