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
                string query = "INSERT INTO GENRES (ID, NAME) VALUES (@ID, @Name)"; 
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ID", GetNextGenreID());
                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
            }
        }

        private int GetNextGenreID()
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "SELECT MAX(ID) FROM GENRES";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);
                
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    try
                    {
                        return Convert.ToInt32(result) + 1;
                    }
                    catch (InvalidCastException)
                    {
                        return 1;
                    }
                }
                else
                    return 0;
            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return -1;
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
                    return Convert.ToInt32(result)+1;
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
