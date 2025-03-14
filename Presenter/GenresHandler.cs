using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DatabaseApp.Presenter
{
    public class GenresHandler 
    {
        public void AddGenre(string name)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "INSERT INTO GENRES (ID, NAME) VALUES (0, @Name)"; 
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
            }
        }

        public void RemoveGenre(string name)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string booksQuery = "DELETE FROM BOOKS_CATALOG kk " +
                    "WHERE (SELECT GENRE_ID from BOOKS k where kk.BOOK_ID=k.id)=@GenreID";
                MySqlCommand booksCommand = new MySqlCommand(booksQuery, Program.communicationHandler.connection);

                booksCommand.Parameters.AddWithValue("@GenreID", GetGenreID(name));
                booksCommand.ExecuteNonQuery();

                string genreQuery = "DELETE FROM GENRES WHERE NAME = @GenreName";
                MySqlCommand genreCommand = new MySqlCommand(genreQuery, Program.communicationHandler.connection);

                genreCommand.Parameters.AddWithValue("@GenreName", name);
                genreCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
            }
        }


        public List<ComboBoxItem> GetGenres()
        {
            List<ComboBoxItem> genres = new List<ComboBoxItem>();

            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "SELECT * FROM GENRES";

                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ComboBoxItem genre = new ComboBoxItem
                        {
                            ID = reader.GetInt32("ID"), 
                            Text = reader.GetString("NAME")
                        };
                        genres.Add(genre);
                    }
                }

            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
            }

            return genres;
        }


        public int GetGenreID(string genreName)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "SELECT ID FROM GENRES WHERE NAME = @GenreName";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@GenreName", genreName);
                object result = command.ExecuteScalar();
                if (result != null)
                    return Convert.ToInt32(result);
                else
                    return 0;

            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return -1;
            }
        }
    }
}
