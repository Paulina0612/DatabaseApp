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
                Program.communicationHandler.clientsHandler.GetClientData(Program.communicationHandler.clientsHandler.GetClientID(clientEmailTextBox.Text)).getEmail() != null) 
                Program.IncorrectDataInformation();
            else
            {
                bool ifSuccess = Program.communicationHandler.clientsHandler.PenaltyPayment(clientEmailTextBox.Text);
                if (ifSuccess) MessageBox.Show("Operation successful.");
                else MessageBox.Show("Operation failed.");
            }
        }
    }
}
