using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseApp.View.WorkerAndDirectorPanel.ManagingBooks
{
    public partial class TitlesCatalog : Form
    {
        public TitlesCatalog()
        {
            InitializeComponent();
            LoadGenres(); // Wczytaj gatunki przy starcie formularza
            TitlesCatalog_Load(null, EventArgs.Empty); // Wywołaj ładowanie książek
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

        private void TitlesCatalog_Load(object sender, EventArgs e)
        {
            List<BookData> books = new List<BookData>();
            try
            {
                if (genreComboBox.Text == "Show All" || String.IsNullOrEmpty(genreComboBox.Text))
                    books = Program.communicationHandler.booksHandler.GetTitlesCatalog(-1);
                else
                    books = Program.communicationHandler.booksHandler.GetTitlesCatalog(ComboBoxItem.GetIDByText(genreComboBox.Text));

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
            TitlesCatalog_Load(sender, e); // Aktualizuj katalog po zmianie gatunku
        }
    }
}
