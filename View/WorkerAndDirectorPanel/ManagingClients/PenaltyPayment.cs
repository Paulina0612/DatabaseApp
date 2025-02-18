using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class PenaltyPayment : Form
    {
        public PenaltyPayment()
        {
            InitializeComponent();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(clientEmailTextBox.Text) && 
                Program.communicationHandler.clientsHandler.IsClientInDatabase(Program.communicationHandler.clientsHandler.GetClientID(clientEmailTextBox.Text))) 
                Program.IncorrectDataInformation();
            else
            {
                Program.communicationHandler.clientsHandler.PenaltyPayment(clientEmailTextBox.Text);
                MessageBox.Show("Operation successful.");
            }
        }
    }
}
