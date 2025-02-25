using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            bool ifISBNNumeric = int.TryParse(ISBNTextBox.Text, out int n);
            
            if (string.IsNullOrEmpty(titleTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(authorDataComboBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(ISBNTextBox.Text) && ifISBNNumeric && ISBNTextBox.Text.Length!=13)
                Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(genreComboBox.Text)) Program.IncorrectDataInformation();
            else
            {
                Program.communicationHandler.booksHandler.AddBook(titleTextBox.Text, authorDataComboBox.Text, ISBNTextBox.Text, genreComboBox.Text);
            }
        }

        private void authorDataComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
