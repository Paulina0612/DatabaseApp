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
                MessageBox.Show($"User type set to: {Program.communicationHandler.currentUserType}");// ---------------------
                Program.communicationHandler.InitializeConnection();
                string query = "INSERT INTO Autor (Imie, Nazwisko) VALUES (@FirstName, @LastName)";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.ExecuteNonQuery();

                MessageBox.Show("Autor został dodany.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad dodawania autora: {ex.Message}");
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

                MessageBox.Show("Autor zostal usuniety.");
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show("Aby usunac autora najpierw nalezy usunac wszystkie jego ksiazki.");
                }
                else
                {
                    MessageBox.Show($"Blad usuwania autora: {ex.Message}");
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
                    MessageBox.Show("Nie znaleziono ID autora");
                    return 0;
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad pobierania ID autora {ex.Message}");
                return -1;
            }

        }
    }
}
