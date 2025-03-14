using System;
using System.Windows.Forms;
using DatabaseApp.Presenter;
using MySql.Data.MySqlClient;

namespace DatabaseApp
{
    public class SQLCommunicationHandler
    {
        public MySqlConnection connection;

        public static int LoggedUserID = 0; 

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
            Klient,
            Pracownik,
            Kierownik
        }

        public UserType currentUserType = UserType.Klient; 
        public UserType oldUserType = UserType.Klient;

       
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
                        connectionString = $"Server=localhost;Database=LIB;User Id=CLIENT;" +
                            $"Password=CLIENT_PASSWORD;";
                        break;
                    case UserType.Pracownik:
                        connectionString = $"Server=localhost;Database=LIB;User Id=WORKER;" +
                            $"Password=WORKERS_PASSWORD;";
                        break;
                    case UserType.Kierownik:
                        connectionString = $"Server=localhost;Database=LIB;User Id=DIRECTOR;" +
                            $"Password=DIRECTOR_PASSWORD;";
                        break;
                    default:
                        throw new InvalidOperationException("Invalid user type");
                }

                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (MySqlException ex)
            {
                ErrorOccured(ex.ToString());
            }
        }

       
        public int GetPositionID(string name)
        {
            try
            {
                if (connection == null || connection.State != System.Data.ConnectionState.Open)
                {
                    InitializeConnection();
                }
                string query = "SELECT ID FROM POSITION WHERE NAME = @Name";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@Name", name);
                    object result = command.ExecuteScalar();
                    if (result != null)
                        return Convert.ToInt32(result);
                    else
                    {
                        MessageBox.Show("The position's ID has not been found.");
                        return 0;
                    }
                
            }
            catch (MySqlException ex)
            {
                ErrorOccured(ex.ToString());
                return -1;
            }

        }

        public void ErrorOccured(string message)
        {
            MessageBox.Show($"Error occured: {message}");
        }
    }
}