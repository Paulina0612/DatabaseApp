using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class SearchingClient : Form
    {
        public SearchingClient()
        {
            InitializeComponent();
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            ClientData clientData = Program.communicationHandler.clientsHandler.GetClientData(
                Program.communicationHandler.clientsHandler.GetClientID(emailTextBox.Text));
            bool ifClientRegistered = clientData.getEmail() != null ? true : false;

            if (string.IsNullOrEmpty(emailTextBox.Text)) Program.IncorrectDataInformation();
            else if (ifClientRegistered)
            {
                MessageBox.Show(
                    "Client data: \nID: " + clientData.getID() + "\n"
                    + "Name: " + clientData.getFirstName() + " " + clientData.getLastName() + "\n"
                    + "E-mail: " + clientData.getEmail() + "\n"
                    + "Penalty: " + clientData.getPenalty() + " zl\n"
                    );

            }
            else MessageBox.Show("Client is not registered in database.");
        }
    }
}
