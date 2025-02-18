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
    public partial class BorrowedBooks : Form
    {
        public BorrowedBooks()
        {
            InitializeComponent();
        }

        private void BorrowedBooks_Load(object sender, EventArgs e)
        {
            List<BookData> books = new List<BookData>();
            books = Program.communicationHandler.GetBorrowedBooks();

            foreach (BookData book in books)
            {
                try
                {
                    dataGridView2.Rows.Add(book.ID, book.title, book.authorFirstName + " " + book.authorLastName, book.genreName, book.ISBN, book.ifAvailable);
                }
                catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            }
        }
    }
}
