using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class LendBook : Form
    {
        public LendBook()
        {
            InitializeComponent();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(clientEmailTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(bookIDTextBox.Text)) Program.IncorrectDataInformation();
            else if(!Program.communicationHandler.booksHandler.IsBookAvailable(int.Parse(bookIDTextBox.Text))) Program.IncorrectDataInformation();
            else
            {
                Program.communicationHandler.booksHandler.LendBook(clientEmailTextBox.Text, int.Parse(bookIDTextBox.Text));
                MessageBox.Show("Operation successful.");
            }
        }

        private void catalogButton_Click(object sender, EventArgs e)
        {
            BooksCatalog catalog = new BooksCatalog();
            catalog.Show();
        }

    }
}
