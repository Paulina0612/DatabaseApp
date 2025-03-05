﻿using MySql.Data.MySqlClient;
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


        public void RemoveWorker(string data)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "DELETE FROM Pracownik WHERE CONCAT(Imie, ' ', Nazwisko) = @Data";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@Data", data);
                command.ExecuteNonQuery();

                MessageBox.Show("Employee has been removed.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error removing the employee: {ex.Message}");
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

                MessageBox.Show("Employee's salary has been updated.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error updating employee's salary: {ex.Message}");
            }
        }

        //public int GetWorkerID(string data)
        //{
        //    try
        //    {
        //        //InitializeConnection();
        //        string query = "SELECT ID FROM Pracownik WHERE CONCAT(Imie, ' ', Nazwisko) = @Data";
        //        MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

        //        command.Parameters.AddWithValue("@Data", data);
        //        object result = command.ExecuteScalar();
        //        if (result != null)
        //        {
        //            return Convert.ToInt32(result);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Employee's ID has not been found.");
        //            return 0;
        //        }

        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show($"Error retrieving employee's ID: {ex.Message}");
        //        return -1;
        //    }
        //}

        public int GetWorkerID(string managerData)
        {
            int workerID = -1;
            // Zakładamy, że managerData ma format "Imię Nazwisko"
            string[] parts = managerData.Split(' ');
            if (parts.Length < 2)
            {
                MessageBox.Show("Niepoprawny format danych managera.");
                return workerID;
            }
            string firstName = parts[0];
            string lastName = parts[1];

            string query = "SELECT PracownikID FROM Pracownik WHERE Imie = @FirstName AND Nazwisko = @LastName";
            MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    workerID = reader.GetInt32("PracownikID");
                }
            }
            return workerID;
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

        public List<ComboBoxItem> GetManagers()
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
