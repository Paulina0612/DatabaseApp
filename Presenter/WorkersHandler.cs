using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static DatabaseApp.SQLCommunicationHandler;

namespace DatabaseApp.Presenter
{
    public class WorkersHandler
    {
        public bool AddWorker(string firstName, string lastName, string phoneNumber, string email, string PESEL, float salary, int managerID, int positionID, string password)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();

                string query = "INSERT INTO WORKERS " +
                    "(ID, FIRST_NAME, LAST_NAME, PHONE_NUMBER, E_MAIL, PESEL, SALARY, MANAGER_ID, " +
                    "POSITION_ID, PASSWORD)" +
                    "VALUES (@ID, @FirstName, @LastName, @PhoneNumber, @Email, @PESEL, @Salary, @ManagerID, " +
                    "@PositionID, @Password)";
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
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return false;
            }
        }

        private int GetNextWorkerID()
        {
            try
            {
                string query = "SELECT MAX(ID) FROM WORKERS";
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
                    return -1;

                return Convert.ToInt32(result) + 1;
            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString() );
                return 0;
            }
        }

        public bool WorkerLogIn(string firstName, string lastName, string password)
        {
            MySqlCommand command = null;

            try
            {
                Program.communicationHandler.currentUserType = UserType.Pracownik;
                Program.communicationHandler.InitializeConnection();

                string getPositionID =
                   "SELECT POSITION_ID FROM WORKERS " +
                   "WHERE FIRST_NAME = @FirstName AND LAST_NAME = @LastName AND PASSWORD = @Password";

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
                    "SELECT ID FROM WORKERS " +
                    "WHERE FIRST_NAME = @FirstName AND LAST_NAME = @LastName AND PASSWORD = @Password";

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

        public bool ChangeWorkersManager(int workerID, int managerID)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "update WORKERS set MANAGER-ID=@ManagerID where ID=@WorkerID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@WorkerID", workerID);
                command.Parameters.AddWithValue("@ManagerID", managerID);
                command.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return false;
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
                string query = "DELETE FROM WORKERS WHERE ID = @ID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return false;
            }
        }


        public bool ChangeWorkerSalary(int id, float newSalary)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "UPDATE WORKERS SET SALARY = @NewSalary WHERE ID = @WorkerID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@NewSalary", newSalary);
                command.Parameters.AddWithValue("@WorkerID", id);
                command.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return false;
            }
        }

        public float GetWorkerSalary(int id)
        {
            try
            {
                string query = "SELECT SALARY FROM WORKERS WHERE ID = @ID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ID", id);
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                    return Convert.ToSingle(result);
                else
                {
                    MessageBox.Show("No employee found with the provided ID");
                    return 0;
                }

            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return 0;
            }
        }

        public List<ComboBoxItem> GetPositions()
        {
            List<ComboBoxItem> positions = new List<ComboBoxItem>();

            try
            {
                string query = "SELECT * FROM POSITIONS";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                    while (reader.Read())
                        positions.Add(new ComboBoxItem { ID = reader.GetInt32("ID"), Text = reader.GetString("Nazwa_stanowiska") });

            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
            }

            return positions;
        }

        public List<ComboBoxItem> GetAllWorkersData()
        {
            List<ComboBoxItem> managers = new List<ComboBoxItem>();

            try
            {
                string query = "SELECT ID, FIRST_NAME, LAST_NAME FROM WORKERS";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                    while (reader.Read())
                        managers.Add(new ComboBoxItem { 
                            ID = reader.GetInt32("ID"), 
                            Text = String.Concat(reader.GetString("FIRST_NAME"), " ",  
                                reader.GetString("LAST_NAME")) });

            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
            }

            return managers;
        }
    }
}
