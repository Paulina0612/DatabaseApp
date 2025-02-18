using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class ReturnBook : Form
    {
        private bool ifPenaltyPayed = false;

        public ReturnBook()
        {
            InitializeComponent();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            bool ifBookIDNumeric = int.TryParse(bookIDTextBox.Text, out int bookID);
            int clientID = Program.communicationHandler.clientsHandler.GetClientID(clientEmailTextBox.Text);

            if (string.IsNullOrEmpty(clientEmailTextBox.Text) &&
                Program.communicationHandler.clientsHandler.IsClientInDatabase(clientID))
                Program.IncorrectDataInformation();
            else if (!ifBookIDNumeric && !Program.communicationHandler.booksHandler.IsBookBorrowedByClient(clientID, bookID))
                Program.IncorrectDataInformation();
            else
            {
                Program.communicationHandler.booksHandler.ReturnBook(clientEmailTextBox.Text, bookID, ifPenaltyPayed);
                MessageBox.Show("Book returned.");
            }
        }

        private void penaltyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(ifPenaltyPayed) ifPenaltyPayed=false;
            else ifPenaltyPayed = true;
        }
    }
}
