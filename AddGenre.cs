using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class AddGenre : Forms
    {
        public AddGenre()
        {
            InitializeComponent();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(genreNameTextBox.Text)) Program.IncorrectDataInformation();
            else
            {
                communicationHandler.AddGenre(genreNameTextBox.Text);
                MessageBox.Show("Genre successfully added.");
            }
        }
    }
}
