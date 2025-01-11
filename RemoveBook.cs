using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class RemoveBook : Forms
    {
        public RemoveBook()
        {
            InitializeComponent();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            bool ifIDNumeric = int.TryParse(bookIDTextBox.Text, out int id);

            if (ifIDNumeric && string.IsNullOrEmpty(bookIDTextBox.Text) && !communicationHandler.IsBookInDatabase(id))
                Program.IncorrectDataInformation();
            else
            {
                communicationHandler.RemoveBook(id);
                MessageBox.Show("Book succcessfully removed.");
            }
        }
    }
}
