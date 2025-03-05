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
            List<String> genres = Program.communicationHandler.genresHandler.GetGenres();
            genreComboBox.Items.Add("Show All");
            foreach (String genre in genres)
            {
                genreComboBox.Items.Add(genre);
            }
        }

        private void BooksCatalog_Load(object sender, EventArgs e)
        {
            List<BookData> books = new List<BookData>();
            try
            {
                if (genreComboBox.Text == "Show All")
                    books = Program.communicationHandler.booksHandler.GetBooksCatalog(null);
                else
                    books = Program.communicationHandler.booksHandler.GetBooksCatalog(genreComboBox.Text);

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
