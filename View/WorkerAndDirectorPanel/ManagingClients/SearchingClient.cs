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
            if (string.IsNullOrEmpty(emailTextBox.Text)) Program.IncorrectDataInformation();
            else if (Program.communicationHandler.clientsHandler.IsClientInDatabase(Program.communicationHandler.clientsHandler.GetClientID(emailTextBox.Text))) 
                MessageBox.Show("Client is registered in database.");
            else MessageBox.Show("Client is not registered in database.");
            // TODO: Wyswietlenie informacji o kliencie
        }
    }
}
