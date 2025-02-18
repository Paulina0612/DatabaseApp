using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DatabaseApp.SQLCommunicationHandler;

namespace DatabaseApp.Presenter
{
    public class WorkersHandler
    {
        public void AddWorker(string firstName, string lastName, string phoneNumber, string email, string PESEL, float salary, string managerData, string positionName, string password)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                int managerID = Program.communicationHandler.workersHandler.GetWorkerID(managerData);
                int positionID = Program.communicationHandler.GetPositionID(positionName);

                string query = "INSERT INTO Pracownik (Imie, Nazwisko, Numer_Telefonu, Adres_e_mail, PESEL, Wyplata, Kierownik_ID, StanowiskoID, Haslo)" +
                    "VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @PESEL, @Salary, @ManagerID, @PositionID, @Password)";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PESEL", PESEL);
                command.Parameters.AddWithValue("@Salary", salary);
                command.Parameters.AddWithValue("@ManagerID", managerID);
                command.Parameters.AddWithValue("@PositionID", 1);
                command.Parameters.AddWithValue("@Password", password);
                command.ExecuteNonQuery();

                MessageBox.Show("Pracownik zostal dodany");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad dodawania pracownika: {ex.Message}");
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


        public void RemoveWorker(string data)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "DELETE FROM Pracownik WHERE CONCAT(Imie, ' ', Nazwisko) = @Data";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@Data", data);
                command.ExecuteNonQuery();

                MessageBox.Show("Pracownik zostal usuniety.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad usuwania pracownika: {ex.Message}");
            }
        }


        public void ChangeWorkerSalary(string data, float newSalary)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                int workerID = Program.communicationHandler.workersHandler.GetWorkerID(data);
                string query = "UPDATE Pracownik SET Wyplata = @NewSalary WHERE ID = @WorkerID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@NewSalary", newSalary);
                command.Parameters.AddWithValue("@WorkerID", workerID);
                command.ExecuteNonQuery();

                MessageBox.Show("Wynagrodzenie pracownika zostało zaktualizowane.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad zmiany wynagrodzenia pracownika: {ex.Message}");
            }
        }

        public int GetWorkerID(string data)
        {
            try
            {
                //InitializeConnection();
                string query = "SELECT ID FROM Pracownik WHERE CONCAT(Imie, ' ', Nazwisko) = @Data";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@Data", data);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    MessageBox.Show("Nie znaleziono ID pracownika");
                    return 0;
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad pobierania ID pracownika {ex.Message}");
                return -1;
            }
        }


        public float GetWorkerSalary(string data)
        {
            try
            {
                //InitializeConnection();
                int ID = GetWorkerID(data);
                string query = "SELECT SALARY FROM Pracownik WHERE ID == @ID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ID", ID);
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    return Convert.ToSingle(result);
                }
                else
                {
                    MessageBox.Show("Nie znaleziono pracownika z podanym ID");
                    return 0;
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad pobierania wyplaty pracownika: {ex.Message}");
                return 0;
            }
        }
    }
}
