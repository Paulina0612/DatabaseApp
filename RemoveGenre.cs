using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class RemoveGenre : Forms
    {
        public RemoveGenre()
        {
            InitializeComponent();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(genreNameComboBox.Text)) Program.IncorrectDataInformation();
            else
            {
                communicationHandler.RemoveGenre(genreNameComboBox.Text);
                MessageBox.Show("Genre successfully removed.");
            }
        }
    }
}
