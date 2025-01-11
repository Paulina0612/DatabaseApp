using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class PenaltyPayment : Forms
    {
        public PenaltyPayment()
        {
            InitializeComponent();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(clientEmailTextBox.Text) && 
                communicationHandler.IsClientInDatabase(communicationHandler.GetClientID(clientEmailTextBox.Text))) 
                Program.IncorrectDataInformation();
            else
            {
                communicationHandler.PenaltyPayment(clientEmailTextBox.Text);
                MessageBox.Show("Operation successful.");
            }
        }
    }
}
