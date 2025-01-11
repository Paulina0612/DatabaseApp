using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class RemoveAuthor : Forms
    {
        public RemoveAuthor()
        {
            InitializeComponent();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(authorDataComboBox.Text)) Program.IncorrectDataInformation();
            else
            {
                communicationHandler.RemoveAuthor(authorDataComboBox.Text);
                MessageBox.Show("Author removed successfully.");
            }
        }
    }
}
