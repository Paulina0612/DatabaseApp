using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class BooksCatalog : Form
    {
        public BooksCatalog()
        {
            InitializeComponent();
            LoadGenres(); // Wczytaj gatunki przy starcie formularza
            BooksCatalog_Load(null, EventArgs.Empty); // Wywołaj ładowanie książek
        }

        private void LoadGenres()
        {
            genreComboBox.Items.Clear();
            List<ComboBoxItem> genres = Program.communicationHandler.genresHandler.GetGenres();
            genreComboBox.Items.Add("Show All");
            foreach (ComboBoxItem genre in genres)
            {
                genreComboBox.Items.Add(genre.ID + " " + genre.Text);
            }
        }

        private void BooksCatalog_Load(object sender, EventArgs e)
        {
            //TODO: Nie wyswietlac ksiazek, ktore sa usuniete
            List<BookData> books = new List<BookData>();
            try
            {
                if (genreComboBox.Text == "Show All" || String.IsNullOrEmpty(genreComboBox.Text))
                    books = Program.communicationHandler.booksHandler.GetBooksCatalog(-1);
                else
                    books = Program.communicationHandler.booksHandler.GetBooksCatalog(ComboBoxItem.GetIDByText(genreComboBox.Text));

                Console.WriteLine($"Pobrano {books.Count} książek");

                if (books.Count == 0)
                {
                    MessageBox.Show("Brak książek w katalogu dla wybranego gatunku.");
                    return;
                }

                dataGridView1.Rows.Clear();
                foreach (BookData book in books)
                {
                    try
                    {
                        dataGridView1.Rows.Add(book.ID, book.title,
                            $"{book.authorFirstName} {book.authorLastName}",
                            book.genreName, book.ISBN, book.ifAvailable);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Błąd podczas dodawania książki: {ex.Message}");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Błąd bazy danych: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void genreComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BooksCatalog_Load(sender, e); // Aktualizuj katalog po zmianie gatunku
        }
    }
}
