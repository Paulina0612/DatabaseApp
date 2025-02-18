using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class RemoveBook : Form
    {
        public RemoveBook()
        {
            InitializeComponent();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            bool ifIDNumeric = int.TryParse(bookIDTextBox.Text, out int id);

            if (ifIDNumeric && string.IsNullOrEmpty(bookIDTextBox.Text) && !Program.communicationHandler.booksHandler.IsBookInDatabase(id))
                Program.IncorrectDataInformation();
            else
            {
                Program.communicationHandler.booksHandler.RemoveBook(id);
                MessageBox.Show("Book succcessfully removed.");
            }
        }
    }
}
