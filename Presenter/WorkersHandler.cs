using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DatabaseApp.SQLCommunicationHandler;

//-----------------------------------------------------------------------------------------------

// TODO: Nie działa wypożyczanie książek: Po wpisaniu danych wyrzuca incorrect data

//-----------------------------------------------------------------------------------------------

namespace DatabaseApp.Presenter
{
    public class WorkersHandler
    {
        public bool AddWorker(string firstName, string lastName, string phoneNumber, string email, string PESEL, float salary, int managerID, int positionID, string password)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();

                string query = "INSERT INTO Pracownik (ID, Imie, Nazwisko, Numer_Telefonu, Adres_e_mail, PESEL, Wyplata, Kierownik_ID, StanowiskoID, Haslo)" +
                    "VALUES (@ID, @FirstName, @LastName, @PhoneNumber, @Email, @PESEL, @Salary, @ManagerID, @PositionID, @Password)";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ID", GetNextWorkerID());
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PESEL", PESEL);
                command.Parameters.AddWithValue("@Salary", salary);
                command.Parameters.AddWithValue("@ManagerID", managerID);
                command.Parameters.AddWithValue("@PositionID", positionID);
                command.Parameters.AddWithValue("@Password", password);
                command.ExecuteNonQuery();

                return true;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error adding the employee: {ex.Message}");
                return false;
            }
        }

        private int GetNextWorkerID()
        {
            try
            {
                //InitializeConnection();
                string query = "SELECT MAX(ID) FROM Pracownik";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result) + 1;
                }
                else
                {
                    return -1;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error checking the borrowing ID: {ex.Message}");
                return 0;
            }
        }

        public bool WorkerLogIn(string firstName, string lastName, string password)
        {
            MySqlCommand command = null;

            try
            {
                // Inicjalizacja połączenia jako 'Pracownik'
                Program.communicationHandler.currentUserType = UserType.Pracownik;
                Program.communicationHandler.InitializeConnection();

                // Sprawdzanie, czy użytkownik istnieje i czy jest pracownikiem czy kierownikiem
                string getPositionID =
                   "SELECT StanowiskoID FROM Pracownik WHERE Imie = @FirstName AND Nazwisko = @LastName AND Haslo = @Password";

                command = new MySqlCommand(getPositionID, Program.communicationHandler.connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Password", password);

                int positionID = Convert.ToInt32(command.ExecuteScalar());
                if (positionID == 1)
                    Program.communicationHandler.currentUserType = UserType.Kierownik;
                else
                    Program.communicationHandler.currentUserType = UserType.Pracownik;

                // Pobieranie ID zalogowanego użytkownika
                string query =
                    "SELECT ID FROM Pracownik WHERE Imie = @FirstName AND Nazwisko = @LastName AND Haslo = @Password";

                command = new MySqlCommand(query, Program.communicationHandler.connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Password", password);


                object result = command.ExecuteScalar();
                if (result != null)
                {
                    // Jeżeli użytkownik istnieje, zaloguj go
                    LoggedUserID = Convert.ToInt32(result);
                    return true;
                }
                else
                {
                    // Jeżeli użytkownik nie istnieje, poinformuj o błędnych danych
                    Program.IncorrectDataInformation();
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                // Jeżeli wystąpi błąd, poinformuj o tym użytkownika
                Program.communicationHandler.ErrorOccured(ex.Message);
                return false;
            }
            finally
            {
                // Ręczne zwalnianie zasobów
                if (command != null)
                    command.Dispose();
            }
        }


        public bool IfDirector()
        {
            if (Program.communicationHandler.currentUserType == UserType.Kierownik)
                return true;
            else
                return false;
        }


        public bool RemoveWorker(int id)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "DELETE FROM Pracownik WHERE ID = @ID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error removing the employee: {ex.Message}");
                return false;
            }
        }


        public bool ChangeWorkerSalary(int id, float newSalary)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "UPDATE Pracownik SET Wyplata = @NewSalary WHERE ID = @WorkerID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@NewSalary", newSalary);
                command.Parameters.AddWithValue("@WorkerID", id);
                command.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error updating employee's salary: {ex.Message}");
                return false;
            }
        }

        public float GetWorkerSalary(int id)
        {
            try
            {
                string query = "SELECT Wyplata FROM Pracownik WHERE ID = @ID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ID", id);
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    return Convert.ToSingle(result);
                }
                else
                {
                    MessageBox.Show("No employee found with the provided ID");
                    return 0;
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error retrieving the employee's salary: {ex.Message}");
                return 0;
            }
        }

        public List<ComboBoxItem> GetPositions()
        {
            List<ComboBoxItem> positions = new List<ComboBoxItem>();

            try
            {
                string query = "SELECT * FROM Stanowisko";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                    while (reader.Read())
                        positions.Add(new ComboBoxItem { ID = reader.GetInt32("ID"), Text = reader.GetString("Nazwa_stanowiska") });

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error retrieving the employee's salary: {ex.Message}");
            }

            return positions;
        }

        public List<ComboBoxItem> GetAllWorkersData()
        {
            List<ComboBoxItem> managers = new List<ComboBoxItem>();

            try
            {
                string query = "SELECT ID, Imie, Nazwisko FROM Pracownik";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                    while (reader.Read())
                        managers.Add(new ComboBoxItem { ID = reader.GetInt32("ID"), Text = String.Concat(reader.GetString("Imie"), " ", 
                            reader.GetString("Nazwisko")) });

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error retrieving the employee's salary: {ex.Message}");
            }

            return managers;
        }
    }
}
