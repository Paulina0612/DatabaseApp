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

                MessageBox.Show("Gatunek zostal dodany.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad dodawania gatunku: {ex.Message}");
            }
        }

        public void RemoveGenre(string name)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "DELETE FROM Gatunki WHERE Nazwa_gatunku = @Nazwa_gatunku";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@Nazwa_gatunku", name);
                command.ExecuteNonQuery();


                MessageBox.Show("Gatunek zostal usuniety.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad usuwania gatunku: {ex.Message}");
            }
        }


        public List<String> GetGenres()
        {
            List<String> genres = new List<String>();

            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = @"
                    SELECT Nazwa_gatunku FROM gatunki";

                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        genres.Add(reader.GetString("Nazwa_gatunku"));
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
                    MessageBox.Show("Nie znaleziono gatunku");
                    return 0;
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad pobierania ID gatunku {ex.Message}");
                return -1;
            }
        }
    }
}
