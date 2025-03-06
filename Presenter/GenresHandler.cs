using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                string query = "INSERT INTO Gatunki (ID, Nazwa_gatunku) VALUES (0, @Name)"; //TODO: Ustawic automatyczne inkrementowanie ID
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();

                MessageBox.Show("Genre has been added.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error adding genre: {ex.Message}");
            }
        }

        public void RemoveGenre(string name)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string booksQuery = "DELETE FROM katalog_ksiazek kk WHERE (SELECT gatunekID from ksiazki k where kk.ksiazkiid=k.id)=@GatunekID";
                MySqlCommand booksCommand = new MySqlCommand(booksQuery, Program.communicationHandler.connection);

                booksCommand.Parameters.AddWithValue("@GatunekID", GetGenreID(name));
                booksCommand.ExecuteNonQuery();

                string genreQuery = "DELETE FROM Gatunki WHERE Nazwa_gatunku = @Nazwa_gatunku";
                MySqlCommand genreCommand = new MySqlCommand(genreQuery, Program.communicationHandler.connection);

                genreCommand.Parameters.AddWithValue("@Nazwa_gatunku", name);
                genreCommand.ExecuteNonQuery();


                MessageBox.Show("Genre has been deleted.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error deleting the genre: {ex.Message}");
            }
        }


        public List<ComboBoxItem> GetGenres()
        {
            List<ComboBoxItem> genres = new List<ComboBoxItem>();

            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "SELECT * FROM gatunki";

                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ComboBoxItem genre = new ComboBoxItem
                        {
                            ID = reader.GetInt32("ID"), 
                            Text = reader.GetString("Nazwa_gatunku")
                        };
                        genres.Add(genre);
                    }
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error fetching genres: {ex.Message}");
            }

            return genres;
        }


        public int GetGenreID(string genreName)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "SELECT ID FROM Gatunki WHERE Nazwa_gatunku = @GenreName";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@GenreName", genreName);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    MessageBox.Show("The genre has not been found.");
                    return 0;
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error retrieving genre's ID {ex.Message}");
                return -1;
            }
        }
    }
}
