using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using static DatabaseApp.SQLCommunicationHandler;

namespace DatabaseApp.Presenter
{
    public class ClientsHandler
    {
        public bool ClientRegistration(string firstName, string lastName, string email, string cardNumber)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();

                string query = "INSERT INTO CLIENTS (ID, FIRST_NAME, LAST_NAME, E_MAIL, PENALTY, CARD_NUMBER)" +
                    "VALUES (@ID, @FirstName, @LastName, @Email, 0, @CardNumber)";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                int id = GetNextClientID();
                command.Parameters.AddWithValue("@ID", GetNextClientID());
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@CardNumber", cardNumber);
                command.ExecuteNonQuery();

                return true;

            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return false;
            }
        }

        private int GetNextClientID()
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "SELECT MAX(ID) FROM CLIENTS";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                try
                {
                    return Convert.ToInt32(command.ExecuteScalar()) + 1;
                }
                catch (InvalidCastException)
                {
                    return 1;
                }
            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return -1;
            }
        }

        // Logging in 
        public bool ClientLogIn(string email, string cardNumber)
        {
            try
            {
                Program.communicationHandler.currentUserType = UserType.Klient;
                Program.communicationHandler.InitializeConnection();
                Program.communicationHandler.currentUserType = UserType.Klient;
                string query = @"SELECT COUNT(*) 
                    FROM CLIENTS 
                    WHERE E_MAIL = @Email AND CARD_NUMBER = @CardNumber";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@CardNumber", cardNumber);

                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                {
                    SQLCommunicationHandler.LoggedUserID = 
                        Program.communicationHandler.clientsHandler.GetClientID(email);
                    return true;
                }
                else
                    return false;

            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return false;
            }
        }


        public bool PenaltyPayment(string email)
        {
            bool ifSuccess = false;
            try
            {
                Program.communicationHandler.InitializeConnection();
                int clientID = Program.communicationHandler.clientsHandler.GetClientID(email);

                if (clientID == -1) return ifSuccess;

                string query = "UPDATE CLIENTS SET PENALTY = 0 WHERE ID = @ClientID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ClientID", clientID);
                command.ExecuteNonQuery();

                ifSuccess = true;
            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                ifSuccess = false;
            }

            return ifSuccess;
        }

        public int GetClientID(string email)
        {
            try
            {
                string query = "SELECT ID FROM CLIENTS WHERE E_MAIL = @Email";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@Email", email);
                object result = command.ExecuteScalar();
                if (result != null)
                    return Convert.ToInt32(result);
                else
                    return -1;

            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.Message);
                return -1;
            }
        }


        public ClientData GetClientData(int ID)
        {
            ClientData client = new ClientData();
            try
            {
                string query = "SELECT * FROM CLIENTS WHERE ID = @ID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ID", ID);


                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        client = new ClientData
                        {
                            ID = reader.GetInt32("ID"),
                            firstName = reader.GetString("FIRST_NAME"),
                            lastName = reader.GetString("LAST_NAME"),
                            email = reader.GetString("E_MAIL"),
                            penalty = reader.GetFloat("PENALTY")
                        };
                        
                    }
                }
            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
            }
            return client;

        }

    }
}
