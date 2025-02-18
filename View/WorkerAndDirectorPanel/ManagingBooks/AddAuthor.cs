using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class AddAuthor : Form
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
                Program.communicationHandler.authorsHandler.AddAuthor(firstNameTextBox.Text, lastNameTextBox.Text);
                MessageBox.Show("Author successfully added. ");
            }
        }
    }
}
