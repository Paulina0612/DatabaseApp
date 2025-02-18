using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class RemoveAuthor : Form
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
                Program.communicationHandler.RemoveAuthor(authorDataComboBox.Text);
                MessageBox.Show("Author removed successfully.");
            }
        }
    }
}
