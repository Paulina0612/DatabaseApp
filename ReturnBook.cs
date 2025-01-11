﻿using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class ReturnBook : Forms
    {
        private bool ifPenaltyPayed = false;

        public ReturnBook()
        {
            InitializeComponent();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            bool ifBookIDNumeric = int.TryParse(bookIDTextBox.Text, out int bookID);
            int clientID = communicationHandler.GetClientID(clientEmailTextBox.Text);

            if (string.IsNullOrEmpty(clientEmailTextBox.Text) &&
                communicationHandler.IsClientInDatabase(clientID))
                Program.IncorrectDataInformation();
            else if (!ifBookIDNumeric && !communicationHandler.IsBookBorrowedByClient(clientID, bookID))
                Program.IncorrectDataInformation();
            else
            {
                communicationHandler.ReturnBook(clientEmailTextBox.Text, bookID, ifPenaltyPayed);
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
