using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseApp.Presenter
{
    public class AuthorsHandler
    {
        public void AddAuthor(string firstName, string lastName)
        {
            try
            {
                MessageBox.Show($"User type set to: {Program.communicationHandler.currentUserType}");
                Program.communicationHandler.InitializeConnection();
                string query = "INSERT INTO Autor (Imie, Nazwisko) VALUES (@FirstName, @LastName)";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.ExecuteNonQuery();

                MessageBox.Show("Author has been added.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error adding the author: {ex.Message}");
            }
        }

        public void RemoveAuthor(string data)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "DELETE FROM Autor WHERE CONCAT(Imie, ' ', Nazwisko) = @Data";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@Data", data);
                command.ExecuteNonQuery();

                MessageBox.Show("Author has been removed.");
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show("To remove the author, you must first delete all their books.");
                }
                else
                {
                    MessageBox.Show($"Error removing the author: {ex.Message}");
                }
            }
        }

        public int GetAuthorID(string data)
        {
            try
            {
                //InitializeConnection();
                string query = "SELECT ID FROM Autor WHERE CONCAT(Imie, ' ', Nazwisko) = @Data";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@Data", data);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    MessageBox.Show("Author's ID has not been found.");
                    return 0;
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error retrieving author's ID: {ex.Message}");
                return -1;
            }

        }
    }
}
