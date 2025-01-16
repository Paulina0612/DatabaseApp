using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class BooksCatalog : Forms
    {
        public BooksCatalog()
        {
            InitializeComponent();

            List<String> genres = new List<String>();
            genres = communicationHandler.GetGenres();
            foreach (String genre in genres) 
                genreComboBox.Items.Add(genre);
        }

        private void BooksCatalog_Load(object sender, EventArgs e)
        {
            List<BookData> books = new List<BookData>();
            books = communicationHandler.GetBooksCatalog(genreComboBox.Text);
            
            foreach (BookData book in books)
            {
                try
                {
                    dataGridView1.Rows.Add(book.ID, book.title, book.authorFirstName + " " + book.authorLastName, book.genreName, book.ISBN, book.ifAvailable);
                }
                catch(MySqlException ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        private void genreComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BooksCatalog_Load(sender, e);
        }
    }
}
