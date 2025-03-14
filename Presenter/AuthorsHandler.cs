using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DatabaseApp.Presenter
{
    public class AuthorsHandler
    {
        public bool AddAuthor(string firstName, string lastName)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "INSERT INTO AUTHORS (ID, FIRST_NAME, LAST_NAME) " +
                    "VALUES (@ID, @FirstName, @LastName)";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ID", GetNextAuthorID());
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return false;
            }
        }

        public int GetNextAuthorID()
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "SELECT MAX(ID) FROM AUTHORS";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    try
                    {
                        Convert.ToInt32(result);
                    }
                    catch (InvalidCastException)
                    {
                        return 1;
                    }
                }
                else
                {
                    return 1;
                }
                return 1;
            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return -1;
            }
        }

        public List<ComboBoxItem> GetAuthors()
        {
            List<ComboBoxItem> authors = new List<ComboBoxItem>();

            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "SELECT * FROM AUTHORS";

                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ComboBoxItem book = new ComboBoxItem
                        {
                            ID = reader.GetInt32("ID"),
                            Text = reader.GetString("FIRST_NAME") + " " + reader.GetString("LAST_NAME")
                        };
                        authors.Add(book);
                    }
                }

            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
            }

            return authors;
        }
    }
}
