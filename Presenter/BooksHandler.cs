using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseApp.Presenter
{
    public class BooksHandler 
    {
        public void AddBook(string title, string authorData, string ISBN, string genreName)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                int authorID = Program.communicationHandler.GetAuthorID(authorData);
                int genreID = Program.communicationHandler.GetGenreID(genreName);

                string query = "INSERT INTO Ksiazki (Tytul, AutorID, GatunekID, ISBN) VALUES (@Title, @AuthorID, @GenreID, @ISBN)";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@AuthorID", authorID);
                command.Parameters.AddWithValue("@GenreID", genreID);
                command.Parameters.AddWithValue("@ISBN", ISBN);
                command.ExecuteNonQuery();

                MessageBox.Show("Book successfully added. ");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad dodania ksiazki. {ex.Message}");
            }
        }
    }
}
