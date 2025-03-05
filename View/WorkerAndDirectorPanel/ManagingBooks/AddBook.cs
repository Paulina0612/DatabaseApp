using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class AddBook : Form
    {
        private List<ComboBoxItem> authors;
        private List<ComboBoxItem> genres;

        public AddBook()
        {
            InitializeComponent();
            LoadAuthors();
            LoadGenres();
        }

        private void LoadAuthors()
        {
            authorDataComboBox.Items.Clear();
            authors = Program.communicationHandler.authorsHandler.GetAuthors();
            foreach (ComboBoxItem author in authors)
            {
                authorDataComboBox.Items.Add(author.ID + " " + author.Text);
            }
        }

        private void LoadGenres()
        {
            genreComboBox.Items.Clear();
            genres = Program.communicationHandler.genresHandler.GetGenres();
            foreach (ComboBoxItem genre in genres)
            {
                genreComboBox.Items.Add(genre.ID + " " + genre.Text);
            }
        }

        private void addNewTitleButton_Click(object sender, EventArgs e)
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

        private void catalogButton_Click(object sender, EventArgs e)
        {
            BooksCatalog catalog = new BooksCatalog();
            catalog.Show();
        }

        private void addNewCopyButton_Click(object sender, EventArgs e)
        {

        }
    }
}
