using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseApp.Presenter;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.X509;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DatabaseApp
{
    public class SQLCommunicationHandler
    {
        public MySqlConnection connection;

        public static int LoggedUserID = 0; // zmienna globalna ustawiana przez logującego się uzytkownika

        public BooksHandler booksHandler;
        public GenresHandler genresHandler;
        public AuthorsHandler authorsHandler;
        public WorkersHandler workersHandler;
        public ClientsHandler clientsHandler;

        public SQLCommunicationHandler()
        {
            booksHandler = new BooksHandler();
            genresHandler = new GenresHandler();
            authorsHandler = new AuthorsHandler();
            workersHandler = new WorkersHandler();
            clientsHandler = new ClientsHandler();
        }

        public enum UserType
        {
            None,
            Klient,
            Pracownik,
            Kierownik
        }

        public UserType currentUserType = UserType.None; // flaga 
        public UserType oldUserType = UserType.None;

        // Metoda do inicjalizacji połączenia z określonym użytkownikiem
        public void InitializeConnection()
        {
            try
            {
                // Zamknięcie starego połączenia, jeżeli istnieje i użytkownik się zmienił
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    if (oldUserType != currentUserType)
                    {
                        connection.Close(); // Zamykamy stare połączenie
                        oldUserType = currentUserType; // Aktualizujemy typ użytkownika
                    }
                    else
                    {
                        // Jeżeli użytkownik się nie zmienił, używamy istniejącego połączenia
                        return;
                    }
                }

                // Tworzymy nowe połączenie w zależności od typu użytkownika
                string connectionString;

                switch (currentUserType)
                {
                    case UserType.Klient:
                        connectionString = $"Server=localhost;Database=Biblioteka;User Id=Klient;Password=klient_password;";
                        break;
                    case UserType.Pracownik:
                        connectionString = $"Server=localhost;Database=Biblioteka;User Id=Pracownik;Password=pracownik_password;";
                        break;
                    case UserType.Kierownik:
                        connectionString = $"Server=localhost;Database=Biblioteka;User Id=Kierownik;Password=kierownik_password;";
                        break;
                    default:
                        throw new InvalidOperationException("Invalid user type");
                }

                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Connection to database failed.\n{ex.Message}");
            }
        }

       
        public int GetPositionID(string name)
        {
            try
            {
                //InitializeConnection();
                if (connection == null || connection.State != System.Data.ConnectionState.Open)
                {
                    InitializeConnection();
                }
                string query = "SELECT ID FROM Stanowisko WHERE Nazwa_stanowiska = @Name";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@Name", name);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("The position's ID has not been found.");
                        return 0;
                    }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error retrieving the position's ID {ex.Message}");
                return -1;
            }

        }
        
        public int GetLendID(int clientID, int bookID) // --------------------------------------------- Nie wywołujemy tego nigdzie
        {
            try
            {
                //InitializeConnection();
                string query = "SELECT ID FROM Wypozyczenia WHERE KlienciID = @KlientID AND Katalog_ksiazekID = @KsiazkaID";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@KlientID", clientID);
                    command.Parameters.AddWithValue("@KsiazkaID", bookID);
                    object result = command.ExecuteScalar();
                    if(result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("No borrowing found for the provided data.");
                        return -1;
                    }
                
            }
            catch(MySqlException ex)
            {
                MessageBox.Show($"Error checking the borrowing ID: {ex.Message}");
                return 0;
            }
        }

        public void ErrorOccured(string message)
        {
            MessageBox.Show($"Error occured: {message}");
        }
    }
}