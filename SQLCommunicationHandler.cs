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
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.X509;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DatabaseApp
{
    public class SQLCommunicationHandler
    {
        private MySqlConnection connection;

        private static int LoggedUserID = 0; // zmienna globalna ustawiana przez logującego się uzytkownika

        public SQLCommunicationHandler()
        {
             
        }

        public enum UserType
        {
            None,
            Klient,
            Pracownik,
            Kierownik
        }

        private UserType currentUserType = UserType.None; // flaga 
        private UserType oldUserType = UserType.None;

        // Metoda do inicjalizacji połączenia z określonym użytkownikiem
        private void InitializeConnection()
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
                        throw new InvalidOperationException("Nieprawidlowy typ uzytkownika");
                }

                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Connection to database failed.\n{ex.Message}");
            }
        }



        // Adding records  
        public void AddBook(string title, string authorData, string ISBN, string genreName)
        {
            try
            {
                InitializeConnection();
                int authorID = GetAuthorID(authorData);
                int genreID = GetGenreID(genreName);

                string query = "INSERT INTO Ksiazki (Tytul, AutorID, GatunekID, ISBN) VALUES (@Title, @AuthorID, @GenreID, @ISBN)";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@AuthorID", authorID);
                    command.Parameters.AddWithValue("@GenreID", genreID);
                    command.Parameters.AddWithValue("@ISBN", ISBN);
                    command.ExecuteNonQuery();
                
                MessageBox.Show("Book successfully added. ");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad dodania ksiazki. {ex.Message}");
            }
        }
        public void AddAuthor(string firstName, string lastName)
        {
            try
            {
                MessageBox.Show($"User type set to: {currentUserType}");// ---------------------
                InitializeConnection();
                string query = "INSERT INTO Autor (Imie, Nazwisko) VALUES (@FirstName, @LastName)";
                MySqlCommand command = new MySqlCommand(query, connection);
                
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
        public void AddGenre(string name)
        {
            try
            {
                InitializeConnection();
                string query = "INSERT INTO Gatunki (ID, Nazwa_gatunku) VALUES (0, @Name)"; //TODO: Ustawic automatyczne inkrementowanie ID
                MySqlCommand command = new MySqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@Name", name);
                    command.ExecuteNonQuery();
                
                MessageBox.Show("Gatunek zostal dodany.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad dodawania gatunku: {ex.Message}");
            }
        }

        public void AddWorker(string firstName, string lastName, string phoneNumber, string email, string PESEL, float salary, string managerData, string positionName, string password)
        {
            try
            {
                InitializeConnection();
                int managerID = GetWorkerID(managerData);
                int positionID = GetPositionID(positionName);

                string query = "INSERT INTO Pracownik (Imie, Nazwisko, Numer_Telefonu, Adres_e_mail, PESEL, Wyplata, Kierownik_ID, StanowiskoID, Haslo)" +
                    "VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @PESEL, @Salary, @ManagerID, @PositionID, @Password)";
                MySqlCommand command = new MySqlCommand(query, connection);
                
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

        public void ClientRegistration(string firstName, string lastName, string email)
        {
            InitializeConnection();
            float balance = 0;
            string cardNumber = string.Empty;  // Zmienna na numer karty, początkowo pusta
            try
            {
                string procedureName = "DodajKlienta";
                MySqlCommand command = new MySqlCommand(procedureName, connection);
                
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
                

                MessageBox.Show("Klient został pomyślnie dodany.");

                // Wyświetlenie zamaskowanego numeru karty
                string maskedCard = MaskCardNumber(cardNumber);
                MessageBox.Show($"Numer karty klienta: {maskedCard}");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad podczas dodawania klienta: {ex.Message}");
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
                InitializeConnection();
                string query = "SELECT IFNULL(MAX(CAST(Numer_karty AS UNSIGNED)), 0) FROM Klienci";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                    return Convert.ToInt32(command.ExecuteScalar());
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad pobierania ostatniego numeru karty {ex.Message}");
                return -1;
            }

        }

        // Metoda maskująca numer karty
        private string MaskCardNumber(string cardNumber)
        {
            // Zwracamy reprezentację w formie gwiazdek
            return new string('*', cardNumber.Length);
        }



        public void LendBook(string clientEmail, int bookID)
        {
            try
            {
                InitializeConnection();
                int clientID = GetClientID(clientEmail);
                string query = "CALL DodajWypozyczenie(@ClientID, @BookID, @WorkerID, CURDATE(), DATE_ADD(CURDATE(), INTERVAL 14 DAY))";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@ClientID", clientID);
                    command.Parameters.AddWithValue("@BookID", bookID);
                    command.Parameters.AddWithValue("@WorkerID", LoggedUserID);
                    command.ExecuteNonQuery();
                

                MessageBox.Show("Wypozyczenie zostalo dodane.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad wypozyczenia ksiazki: {ex.Message}");
            }
        }



        // Logging in 
        public bool ClientLogIn(string email, string cardNumber)
        {
            try
            {
                // Nowe połączenie jako 'Klient'
                currentUserType = UserType.Klient;
                InitializeConnection(); // Tworzymy nowe połączenie
                currentUserType = UserType.Klient;
                string query = "SELECT COUNT(*) FROM Klienci WHERE Adres_e_mail = @Email AND Numer_karty = @CardNumber";
                MySqlCommand command = new MySqlCommand(query, connection);
                
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

                        MessageBox.Show("Zalogowano jako Klient.");
                        LoggedUserID = GetClientID(email);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Błędny email lub numer karty.");
                        return false;
                    }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Błąd logowania klienta: {ex.Message}");
                return false;
            }
        }




        public bool WorkerLogIn(string firstName, string lastName, string password)
        {
            MySqlCommand command = null;

            try
            {
                // Inicjalizacja połączenia jako 'Pracownik'
                currentUserType = UserType.Pracownik;
                InitializeConnection();

                // Sprawdzanie, czy użytkownik istnieje i czy jest pracownikiem czy kierownikiem
                string getPositionID =
                   "SELECT StanowiskoID FROM Pracownik WHERE Imie = @FirstName AND Nazwisko = @LastName AND Haslo = @Password";

                command = new MySqlCommand(getPositionID, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Password", password);
                
                int positionID = Convert.ToInt32(command.ExecuteScalar());
                if (positionID == 1)
                    currentUserType = UserType.Kierownik;
                else
                    currentUserType = UserType.Pracownik;

                // Pobieranie ID zalogowanego użytkownika
                string query = 
                    "SELECT ID FROM Pracownik WHERE Imie = @FirstName AND Nazwisko = @LastName AND Haslo = @Password";

                command = new MySqlCommand(query, connection);
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
                ErrorOccured(ex.Message);
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
            if(currentUserType == UserType.Kierownik)
                return true;
            else 
                return false;
        }






        // Removing records
        public void RemoveBook(int bookID)
        {
            try
            {
                InitializeConnection();
                string query = "DELETE FROM Ksiazki WHERE ID = @KsiazkiID";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@KsiazkiID", bookID);
                    command.ExecuteNonQuery();
                

                MessageBox.Show("Ksiazka została usunieta.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad usuwania ksiazki: {ex.Message}");
            }

        }

        public void RemoveGenre(string name)
        {
            try
            {
                InitializeConnection();
                string query = "DELETE FROM Gatunki WHERE Nazwa_gatunku = @Nazwa_gatunku";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@Nazwa_gatunku", name);
                    command.ExecuteNonQuery();
                

                MessageBox.Show("Gatunek zostal usuniety.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad usuwania gatunku: {ex.Message}");
            }
        }

        public void RemoveAuthor(string data)
        {
            try
            {
                InitializeConnection();
                string query = "DELETE FROM Autor WHERE CONCAT(Imie, ' ', Nazwisko) = @Data";
                MySqlCommand command = new MySqlCommand(query, connection);
                
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

        public void RemoveWorker(string data)
        {
            try
            {
                InitializeConnection();
                string query = "DELETE FROM Pracownik WHERE CONCAT(Imie, ' ', Nazwisko) = @Data";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@Data", data);
                    command.ExecuteNonQuery();
                
                MessageBox.Show("Pracownik zostal usuniety.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad usuwania pracownika: {ex.Message}");
            }
        }




        // Other 
        public void ReturnBook(string email, int bookID, bool ifPenaltyPayed)
        {
            try
            {
                InitializeConnection();
                int clientID = GetClientID(email);
                string query = "CALL ZwrocKsiazke(@ClientID, @BookID, @IfPenaltyPayed)";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@ClientID", clientID);
                    command.Parameters.AddWithValue("@BookID", bookID);
                    command.Parameters.AddWithValue("@IfPenaltyPayed", ifPenaltyPayed);
                    command.ExecuteNonQuery();
                
                MessageBox.Show("Ksiazka została zwrocona.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad zwracania ksiazki: {ex.Message}");
            }

        }

        public void ChangeWorkerSalary(string data, float newSalary)
        {
            try
            {
                InitializeConnection();
                int workerID = GetWorkerID(data);
                string query = "UPDATE Pracownik SET Wyplata = @NewSalary WHERE ID = @WorkerID";
                MySqlCommand command = new MySqlCommand(query, connection);
                
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

        public void PenaltyPayment(string email)
        {
            try
            {
                InitializeConnection();
                int clientID = GetClientID(email);
                string query = "UPDATE Klienci SET Naleznosc = 0 WHERE ID = @ClientID";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@ClientID", clientID);
                    command.ExecuteNonQuery();
                
                MessageBox.Show("Platnosc za karę została zrealizowana.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad podczas realizacji platnosci za kare: {ex.Message}");
            }
        }




        // Returning data
        public List<BookData> GetHistory()
        {
            List<BookData> history = new List<BookData>();

            try
            {
                InitializeConnection();
                string query = @"
        SELECT k.ID, k.Tytul, a.Imie, a.Nazwisko, g.Nazwa_gatunku, k.ISBN, 
               CASE WHEN w.Data_spodziewanego_zwrotu IS NULL THEN false ELSE true END AS ifAvailable
        FROM Wypozyczenia w
        JOIN Klienci c ON w.KlientID = c.ID
        JOIN Ksiazki k ON w.Katalog_ksiazekID = k.ID
        JOIN Autor a ON k.AutorID = a.ID
        JOIN Gatunki g ON k.GatunekID = g.ID
        WHERE c.ID = @ClientId";

                MySqlCommand command = new MySqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@ClientId", LoggedUserID);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BookData book = new BookData
                            {
                                ID = reader.GetInt32("ID"),
                                title = reader.GetString("Tytul"),
                                authorFirstName = reader.GetString("Imie"),
                                authorLastName = reader.GetString("Nazwisko"),
                                genreName = reader.GetString("Nazwa_gatunku"),
                                ISBN = reader.GetString("ISBN"),
                                ifAvailable = reader.GetBoolean("ifAvailable")
                            };
                            history.Add(book);
                        }
                    }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad pobierania historii: {ex.Message}");
            }

            return history;
        }

        public List<BookData> GetBorrowedBooks()
        {
            List<BookData> borrowedBooks = new List<BookData>();

            try
            {
                InitializeConnection();
                string query = @"
                SELECT k.ID, k.Tytul, a.Imie, a.Nazwisko, g.Nazwa_gatunku, k.ISBN, false AS ifAvailable
                FROM Wypozyczenia w
                JOIN Ksiazki k ON w.Katalog_ksiazekID = k.ID
                JOIN Autor a ON k.AutorID = a.ID
                JOIN Gatunki g ON k.GatunekID = g.ID            
                JOIN Klienci kl ON w.KlientID = kl.ID
                WHERE w.KlientID = @KlientID AND w.ID NOT IN (SELECT Wypozyczenie_ID FROM Zwroty)";

                MySqlCommand command = new MySqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@KlientID", LoggedUserID);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BookData book = new BookData
                            {
                                ID = reader.GetInt32("ID"),
                                title = reader.GetString("Tytul"),
                                authorFirstName = reader.GetString("Imie"),
                                authorLastName = reader.GetString("Nazwisko"),
                                genreName = reader.GetString("Nazwa_gatunku"),
                                ISBN = reader.GetString("ISBN"),
                                ifAvailable = false // Wiemy, że książki są wypożyczone
                            };
                            borrowedBooks.Add(book);
                        }
                    }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad pobierania wypozyczonych ksiazek: {ex.Message}");
            }

            return borrowedBooks;
        }

        public List<BookData> GetBooksCatalog(string genre)
        {
            List<BookData> catalog = new List<BookData>();

            try
            {
                InitializeConnection();
                    string query = @"
                    SELECT kk.ID, k.Tytul, a.Imie, a.Nazwisko, g.Nazwa_gatunku, k.ISBN, kk.Stan_magazynowy_ksiazki,
                    CASE WHEN w.Katalog_ksiazekID IS NULL THEN 1 ELSE 0 END AS ifAvailable
                    FROM biblioteka.Katalog_ksiazek kk
                    JOIN biblioteka.Ksiazki k ON kk.KsiazkiID = k.ID 
                    LEFT JOIN biblioteka.Wypozyczenia w ON kk.ID = w.Katalog_ksiazekID AND w.Data_spodziewanego_zwrotu IS NULL
                    JOIN biblioteka.Autor a ON k.AutorID = a.ID
                    JOIN biblioteka.Gatunki g ON k.GatunekID = g.ID
                    WHERE (g.Nazwa_gatunku = @Genre)";

                MySqlCommand command = new MySqlCommand(query, connection);
                    
                        command.Parameters.AddWithValue("@Genre", genre ?? (object)DBNull.Value);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BookData book = new BookData
                                {
                                    ID = reader.GetInt32("ID"),
                                    title = reader.GetString("Tytul"),
                                    authorFirstName = reader.GetString("Imie"),
                                    authorLastName = reader.GetString("Nazwisko"),
                                    genreName = reader.GetString("Nazwa_gatunku"),
                                    ISBN = reader.GetString("ISBN"),
                                    ifAvailable = reader.GetBoolean("ifAvailable")
                                };
                                catalog.Add(book);
                            }
                        }
                    
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error fetching books catalog: {ex.Message}");
            }

            return catalog;
        }

        public List<String> GetGenres()
        {
            List<String> genres = new List<String>();

            try
            {
                //InitializeConnection();
                string query = @"
                    SELECT Nazwa_gatunku FROM gatunki";

                MySqlCommand command = new MySqlCommand(query, connection);
                
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            genres.Add(reader.GetString("Nazwa_gatunku"));
                    }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error fetching genres: {ex.Message}");
            }

            return genres;
        }


        public int GetGenreID(string genreName)
        {
            try
            {
                //InitializeConnection();
                string query = "SELECT ID FROM Gatunki WHERE Nazwa_gatunku = @GenreName";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@GenreName", genreName);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Nie znaleziono gatunku");
                        return 0;
                    }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad pobierania ID gatunku {ex.Message}");
                return -1;
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
                        MessageBox.Show("Nie znaleziono ID stanowiska");
                        return 0;
                    }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad pobierania ID stanowiska {ex.Message}");
                return -1;
            }

        }
        public int GetAuthorID(string data)
        {
            try
            {
                //InitializeConnection();
                string query = "SELECT ID FROM Autor WHERE CONCAT(Imie, ' ', Nazwisko) = @Data";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@Data", data);
                    object result = command.ExecuteScalar();
                    if(result != null)
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
        public int GetWorkerID(string data)
        {
            try
            {
                //InitializeConnection();
                string query = "SELECT ID FROM Pracownik WHERE CONCAT(Imie, ' ', Nazwisko) = @Data";
                MySqlCommand command = new MySqlCommand(query, connection);
                
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
        public int GetLendID(int clientID, int bookID)
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
                        MessageBox.Show("Nie znaleziono wypozyczenia dla podanych danych");
                        return -1;
                    }
                
            }
            catch(MySqlException ex)
            {
                MessageBox.Show($"Blad sprawdzania ID wypozyczenia {ex.Message}");
                return 0;
            }
        }
        public int GetClientID(string email)
        {
            try
            {
                string query = "SELECT ID FROM Klienci WHERE Adres_e_mail = @Email";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@Email", email);
                object result = command.ExecuteScalar();
                if (result != null)
                    return Convert.ToInt32(result);
                else
                    return -1;
                
            }
            catch(MySqlException ex)
            {
                ErrorOccured(ex.Message);
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
                MySqlCommand command = new MySqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@ID", ID);
                    object result = command.ExecuteScalar();
                    if(result != DBNull.Value)
                    {
                        return Convert.ToSingle(result);
                    }
                    else
                    {
                        MessageBox.Show("Nie znaleziono pracownika z podanym ID");
                        return 0;
                    }
                
            }
            catch(MySqlException ex)
            {
                MessageBox.Show($"Blad pobierania wyplaty pracownika: {ex.Message}");
                return 0;
            }
        }
        public bool IsBookAvailable(int ID)
        {
            try
            {
                //InitializeConnection();
                string query = "SELECT Stan_magazynowy_ksiazki FROM Katalog_ksiazek WHERE KsiazkiID = @KsiazkiID";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@KsiazkiID", ID);
                    object result = command.ExecuteScalar();
                    if (result != null && result.ToString() == "dostepna")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad sprawdzania dostepnosci ksiazki{ex.Message}");
                return false;
            }
        }
        public bool IsClientInDatabase(int ID)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Klienci WHERE ID = @ID";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@ID", ID);
                object result = command.ExecuteScalar();
                if(result != null && Convert.ToInt32(result) > 0)
                    return true;
                else
                    return false;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show($"Error occured: {ex.Message}");
                return false;
            }
        }
        public bool IsBookInDatabase(int ID)
        {
            try
            {
                //InitializeConnection();
                string query = "SELECT  COUNT(*) FROM Ksiazki WHERE ID = @ID";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@ID", ID);
                    object result = command.ExecuteScalar();
                    if(result != null && Convert.ToInt32(result) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad sprawdzania dostepnosci ksiazki {ex.Message}");
                return false;
            }
        }
        public bool IsBookBorrowedByClient(int clientID, int bookID)
        {
            try
            {
                //InitializeConnection();
                string query = "SELECT COUNT(*) FROM Wypozyczenia WHERE KlienciID = @KlientID AND Katalog_ksiazekID = @KsiazkaID ";
                MySqlCommand command = new MySqlCommand(@query, connection);
                
                    command.Parameters.AddWithValue("@KlientID", clientID);
                    command.Parameters.AddWithValue("@KsiazkaID", bookID);
                    object result = command.ExecuteScalar();
                    if (result != null && Convert.ToInt32(result) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad sprawdzania czy ksiazka jest wypozyczona {ex.Message}");
                return false;
            }
        }

        private void ErrorOccured(string message)
        {
            MessageBox.Show($"Error occured: {message}");
        }
    }
}