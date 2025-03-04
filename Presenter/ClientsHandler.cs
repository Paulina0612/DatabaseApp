using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DatabaseApp.SQLCommunicationHandler;

namespace DatabaseApp.Presenter
{
    public class ClientsHandler
    {
        public void ClientRegistration(string firstName, string lastName, string email)
        {
            Program.communicationHandler.InitializeConnection();
            float balance = 0;
            string cardNumber = string.Empty;  // Zmienna na numer karty, początkowo pusta
            try
            {
                string procedureName = "DodajKlienta";
                MySqlCommand command = new MySqlCommand(procedureName, Program.communicationHandler.connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Generowanie prostego numeru karty (po prostu inkrementujemy liczbę)
                cardNumber = GenerateSimpleCardNumber().Trim();

                // Dodanie parametrów procedury
                command.Parameters.AddWithValue("@p_Imie", firstName);
                command.Parameters.AddWithValue("@p_Nazwisko", lastName);
                command.Parameters.AddWithValue("@p_AdresEmail", email);
                command.Parameters.AddWithValue("@p_Naleznosc", balance);
                command.Parameters.AddWithValue("@p_NumerKarty", cardNumber);

                // Dodanie ustawienia typu dla parametru NumerKarty
                command.Parameters["@p_NumerKarty"].MySqlDbType = MySqlDbType.VarChar;

                // Wykonanie procedury
                command.ExecuteNonQuery();


                MessageBox.Show("Client hsa been succesfully added.");

                // Wyświetlenie zamaskowanego numeru karty
                string maskedCard = MaskCardNumber(cardNumber);
                MessageBox.Show($"Client's card number: {maskedCard}");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error adding the client: {ex.Message}");
            }
        }

        // Metoda generująca prosty numer karty (inkrementowana liczba)
        private string GenerateSimpleCardNumber()
        {
            // Pobieramy ostatni numer karty z bazy, aby inkrementować
            int lastCardNumber = GetLastCardNumber();

            // Inkrementujemy numer karty
            int newCardNumber = lastCardNumber + 1;

            // Zamieniamy liczbę na string, zapewniając, że ma 7 cyfr (np. 0000001)
            return newCardNumber.ToString("D7");
        }

        // Metoda pobierająca ostatni numer karty z bazy danych (do inkrementacji)
        private int GetLastCardNumber()
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "SELECT IFNULL(MAX(CAST(Numer_karty AS UNSIGNED)), 0) FROM Klienci";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                return Convert.ToInt32(command.ExecuteScalar());

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error retrieving the card's last number. {ex.Message}");
                return -1;
            }

        }


        // Metoda maskująca numer karty
        public string MaskCardNumber(string cardNumber)
        {
            // Zwracamy reprezentację w formie gwiazdek
            return new string('*', cardNumber.Length);
        }


        // Logging in 
        public bool ClientLogIn(string email, string cardNumber)
        {
            try
            {
                // Nowe połączenie jako 'Klient'
                Program.communicationHandler.currentUserType = UserType.Klient;
                Program.communicationHandler.InitializeConnection(); // Tworzymy nowe połączenie
                Program.communicationHandler.currentUserType = UserType.Klient;
                string query = "SELECT COUNT(*) FROM Klienci WHERE Adres_e_mail = @Email AND Numer_karty = @CardNumber";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@CardNumber", cardNumber);

                // Sprawdzamy, czy użytkownik istnieje
                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                {
                    //// Zamykanie poprzedniego połączenia, jeśli jesteśmy już połączeni jako Kierownik
                    //if (connection.State == System.Data.ConnectionState.Open)
                    //{
                    //    connection.Close(); // Zamykamy połączenie 'Kierownik'
                    //}

                    //MessageBox.Show("Zalogowano jako Klient.");
                    LoggedUserID = Program.communicationHandler.clientsHandler.GetClientID(email);
                    return true;
                }
                else
                {
                    MessageBox.Show("Wrong e-mail or card number.");
                    return false;
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error logging in the customer: {ex.Message}");
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

                // TODO: Sprawdzenie, czy klient ma jakąś należność

                string query = "UPDATE Klienci SET Naleznosc = 0 WHERE ID = @ClientID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ClientID", clientID);
                command.ExecuteNonQuery();

                ifSuccess = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error processing the payment for the fine: {ex.Message}");
                ifSuccess = false;
            }

            return ifSuccess;
        }

        public int GetClientID(string email)
        {
            try
            {
                string query = "SELECT ID FROM Klienci WHERE Adres_e_mail = @Email";
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
            bool clientExists = false;
            ClientData client = new ClientData();
            try
            {
                string query = "SELECT * FROM Klienci WHERE ID = @ID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ID", ID);


                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        client = new ClientData
                        {
                            ID = reader.GetInt32("ID"),
                            firstName = reader.GetString("Imie"),
                            lastName = reader.GetString("Nazwisko"),
                            email = reader.GetString("Adres_e_mail"),
                            penalty = reader.GetFloat("Naleznosc")
                        };
                        
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error checking client's presence in the database: {ex.Message}");
                clientExists = false;
                
            }
            return client;

        }

    }
}
