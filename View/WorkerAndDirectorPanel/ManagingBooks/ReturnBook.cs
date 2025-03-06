using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class ReturnBook : Form
    {

        public ReturnBook()
        {
            InitializeComponent();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            bool ifBookIDNumeric = int.TryParse(bookIDTextBox.Text, out int bookID);

            if (!ifBookIDNumeric) Program.IncorrectDataInformation();
            else
            {
                bool ifSuccess = Program.communicationHandler.booksHandler.ReturnBook(bookID);

                if (ifSuccess) MessageBox.Show("Book returned successfully");
                else MessageBox.Show("Error returning the book");
            }
        }
    }
}
