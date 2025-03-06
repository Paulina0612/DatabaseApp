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
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }

        private void History_Load(object sender, EventArgs e)
        {
            List<BookData> books = new List<BookData>();
            try
            {
                books = Program.communicationHandler.booksHandler.GetHistory();

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


        // TODO: Tu trzeba zrobic, zeby wyswietaly sie dane w tabeli, ale narazie to zostawiam, bo potrzebujemy, zeby reszta rzeczy dziala
    }
}
