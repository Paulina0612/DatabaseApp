using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            bool ifSuccessful = communicationHandler.ClientLogIn(emailTextBox.Text, cardNumberTextBox.Text);

            if (ifSuccessful)
            {
                ClientPanel clientPanel = new ClientPanel();
                clientPanel.Show();
            }
            else MessageBox.Show("Incorrect data");
        }
    }
}
