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

namespace DatabaseApp
{
    public partial class ClientPanel : Form
    {
        private int componentX = 243;

        public ClientPanel()
        {
            InitializeComponent();
            LoadGenres(); // Wczytaj gatunki przy starcie formularza
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

        private void genreComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            historyButton_Click(sender, e); // Aktualizuj katalog po zmianie gatunku
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            ResetComponents();
            historyDataGridView.Location = new Point(componentX, historyDataGridView.Location.Y);

            List<BookData> books = new List<BookData>();
            try
            {
                books = Program.communicationHandler.booksHandler.GetHistory();

                if (books.Count == 0)
                {
                    MessageBox.Show("Brak książek w katalogu dla wybranego gatunku.");
                    return;
                }

                historyDataGridView.Rows.Clear();
                foreach (BookData book in books)
                {
                    try
                    {
                        historyDataGridView.Rows.Add(book.ID, book.title,
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

        private void borrowedBooksButton_Click(object sender, EventArgs e)
        {
            ResetComponents();
            borrowedBooksDataGridView.Location = new Point(componentX, borrowedBooksDataGridView.Location.Y);

            List<BookData> books = new List<BookData>();
            books = Program.communicationHandler.booksHandler.GetBorrowedBooks();

            foreach (BookData book in books)
            {
                try
                {
                    borrowedBooksDataGridView.Rows.Add(book.ID, book.title, book.authorFirstName + " " + book.authorLastName, book.genreName, book.ISBN, book.ifAvailable);
                }
                catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        private void catalogButton_Click(object sender, EventArgs e)
        {
            ResetComponents();
            genreLabel.Location = new Point(componentX, genreLabel.Location.Y);
            genreComboBox.Location = new Point(componentX+genreLabel.Width+20, genreComboBox.Location.Y);
            catalogDataGridView.Location = new Point(componentX, catalogDataGridView.Location.Y);

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

                catalogDataGridView.Rows.Clear();
                foreach (BookData book in books)
                {
                    try
                    {
                        catalogDataGridView.Rows.Add(book.ID, book.title,
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

        private void ResetComponents()
        {
            historyDataGridView.Location = new Point(Program.MAX, historyDataGridView.Location.Y);
            borrowedBooksDataGridView.Location = new Point(Program.MAX, borrowedBooksDataGridView.Location.Y);
            genreLabel.Location = new Point(Program.MAX, genreLabel.Location.Y);
            genreComboBox.Location = new Point(Program.MAX, genreComboBox.Location.Y);
            catalogDataGridView.Location = new Point(Program.MAX, catalogDataGridView.Location.Y);
        }
    }
}
