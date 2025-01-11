using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class AddAuthor : Forms
    {
        public AddAuthor()
        {
            InitializeComponent();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNameTextBox.Text)) Program.IncorrectDataInformation();
            else if (string.IsNullOrEmpty(lastNameTextBox.Text)) Program.IncorrectDataInformation();
            else
            {
                communicationHandler.AddAuthor(firstNameTextBox.Text, lastNameTextBox.Text);
                MessageBox.Show("Author successfully added. ");
            }
        }
    }
}
