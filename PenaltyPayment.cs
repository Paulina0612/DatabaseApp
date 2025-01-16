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
                Program.communicationHandler.IsClientInDatabase(Program.communicationHandler.GetClientID(clientEmailTextBox.Text))) 
                Program.IncorrectDataInformation();
            else
            {
                Program.communicationHandler.PenaltyPayment(clientEmailTextBox.Text);
                MessageBox.Show("Operation successful.");
            }
        }
    }
}
