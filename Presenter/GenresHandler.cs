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
    }
}
