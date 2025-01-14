using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.X509;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DatabaseApp
{
    public class SQLCommunicationHandler 
    {
        private MySqlConnection connection;
        public static int LoggedWorkerID = 0; // zmienna globalna ustawiana przez logującego się pracownika

        public SQLCommunicationHandler() 
        {
            try
            {
                // Wstaw tu swoje dane testując, generalnie jest to niebezpieczne by się logować jako root ale to projekt studencki
                string connectionString = "Server=localhost;Database=Biblioteka;User Id=root;Password=root_password;";
                connection = new MySqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Polaczenie z baza danych zostało otwarte.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad polaczenia z baza danych: {ex.Message}");
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Polaczenie z baza danych zostało zamkniete.");
                }
            }
        }


        // Adding records  
        public void AddBook(string title, string authorData, string ISBN, string genreName)
        {
            try
            {
                int authorID = GetAuthorID(authorData);
                int genreID = GetGenreID(genreName);

                string query = "INSERT INTO Ksiazki (Tytul, AutorID, GatunekID, ISBN) VALUES (@Title, @AuthorID, @GenreID, @ISBN)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@AuthorID", authorID);
                    command.Parameters.AddWithValue("@GenreID", genreID);
                    command.Parameters.AddWithValue("@ISBN", ISBN);
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Ksiazka została dodana.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad dodawania ksiązki: {ex.Message}");
            }
        }
        public void AddAuthor(string firstName, string lastName)
        {
            try
            {
                string query = "INSERT INTO Autor (Imie, Nazwisko) VALUES (@FirstName, @LastName)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Autor został dodany.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad dodawania autora: {ex.Message}");
            }
        }
        public void AddGenre(string name)
        {
            try
            {
                string query = "INSERT INTO Gatunki (Nazwa_garunku) VALUES (@Name)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Gatunek zostal dodany.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad dodawania gatunku: {ex.Message}");
            }
        }

        public void AddWorker(string firstName, string lastName, string phoneNumber, string email, string PESEL, float salary, string managerData, string positionName, string haslo)
        {
            try
            {
                int managerID = GetWorkerID(managerData);
                int positionID = GetPositionID(positionName);

                string query = "INSERT INTO Pracownik (Imie, Nazwisko, Numer_Telefonu, Adres_e_mail, PESEL, Wyplata, Kierownik_ID, StanowiskoID, Haslo)" +
                    "VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @PESEL, @Salary, @ManagerID, @PositionID, @Password";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PESEL", PESEL);
                    command.Parameters.AddWithValue("@Salary", salary);
                    command.Parameters.AddWithValue("@ManagerID", managerID);
                    command.Parameters.AddWithValue("@PositionID", positionID);
                    command.Parameters.AddWithValue("@Password", haslo);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Pracownik zostal dodany");
            }
            catch (MySqlException ex)
            {
                    Console.WriteLine($"Blad dodawania pracownika: {ex.Message}");
            }
        }

        public void ClientRegistration(string firstName, string lastName, string email)
        {
            float balance = 0;
            string cardNumber = string.Empty;  // Zmienna na numer karty, początkowo pusta
            try
            {
                string procedureName = "DodajKlienta";
                using (MySqlCommand command = new MySqlCommand(procedureName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Generowanie prostego numeru karty (po prostu inkrementujemy liczbę)
                    cardNumber = GenerateSimpleCardNumber();

                    // Dodanie parametrów procedury
                    command.Parameters.AddWithValue("@p_Imie", firstName);
                    command.Parameters.AddWithValue("@p_Nazwisko", lastName);
                    command.Parameters.AddWithValue("@p_AdresEmail", email);
                    command.Parameters.AddWithValue("@p_Naleznosc", balance);
                    command.Parameters.AddWithValue("@p_NumerKarty", cardNumber);

                    // Wykonanie procedury
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Klient został pomyślnie dodany.");

                // Wyświetlenie zamaskowanego numeru karty
                string maskedCard = MaskCardNumber(cardNumber);
                Console.WriteLine($"Numer karty klienta: {maskedCard}");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad podczas dodawania klienta: {ex.Message}");
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
                string query = "SELECT IFNULL(MAX(CAST(Numer_karty AS UNSIGNED)), 0) FROM Klienci";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad pobierania ostatniego numeru karty {ex.Message}");
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
                int clientID = GetClientID(clientEmail);
                string query = "CALL DodajWypozyczenie(@ClientID, @BookID, @WorkerID, CURDATE(), DATE_ADD(CURDATE(), INTERVAL 14 DAY))";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", clientID);
                    command.Parameters.AddWithValue("@BookID", bookID);
                    command.Parameters.AddWithValue("@WorkerID", LoggedWorkerID);
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Wypozyczenie zostalo dodane.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad wypozyczenia ksiazki: {ex.Message}");
            }
        }



        // Logging in 
        public bool ClientLogIn(string email, string cardNumber)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Klienci WHERE Adres_e_mail = @Email AND Numer_karty = @CardNumber";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@CardNumber", cardNumber);
                    if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    {
                        string clientConnectionString = "Server=localhost;Database=Biblioteka;Uid=Klient;Pwd=klient_password;";
                        connection = new MySqlConnection(clientConnectionString);
                        connection.Open();

                        Console.WriteLine("Zalogowano jako Klient.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Bledny email lub numer karty.");
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad logowania klienta: {ex.Message}");
                return false;
            }
        }

        public bool WorkerLogIn(bool ifDirector, string firstName, string lastName, string password)
        {
            try
            {
                string query = ifDirector ?
                    "SELECT ID FROM Pracownik WHERE Imie = @FirstName AND Nazwisko = @LastName AND Haslo = @Password AND Kierownik_ID IS NULL" :
                    "SELECT ID FROM Pracownik WHERE Imie = @FirstName AND Nazwisko = @LastName AND Haslo = @Password";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Password", password);
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        LoggedWorkerID = Convert.ToInt32(result);
                        if (ifDirector)
                        {
                            string directorConnectionString = "Server=localhost;Database=Biblioteka;Uid=Kierownik;Pwd=kierownik_password;";
                            connection = new MySqlConnection(directorConnectionString);
                        }
                        else
                        {
                            string workerConnectionString = "Server=localhost;Database=Biblioteka;Uid=Pracownik;Pwd=pracownik_password;";
                            connection = new MySqlConnection(workerConnectionString);
                        }

                        connection.Open();
                        Console.WriteLine(ifDirector ? "Zalogowano jako Kierownik." : "Zalogowano jako Pracownik.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Bledne dane logowania.");
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad logowania pracownika: {ex.Message}");
                return false;
            }
        }




        // Removing records
        public void RemoveBook(int bookID)
        {
            try
            {
                string query = "DELETE FROM Ksiazki WHERE ID = @KsiazkiID";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KsiazkiID", bookID);
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Ksiazka została usunieta.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad usuwania ksiazki: {ex.Message}");
            }

        }

        public void RemoveGenre(string name)
        {
            try
            {
                string query = "DELETE FROM Gatunki WHERE Nazwa_gatunku = @Nazwa_gatunku";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nazwa_gatunku", name);
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Gatunek zostal usuniety.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad usuwania gatunku: {ex.Message}");
            }
        }

        public void RemoveAuthor(string data)
        {
            try
            {
                string query = "DELETE FROM Autor WHERE CONCAT(Imie, ' ', Nazwisko) = @Data";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Data", data);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Autor zostal usuniety.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad usuwania autora: {ex.Message}");
            }
        }

        public void RemoveWorker(string data)
        {
            try
            {
                string query = "DELETE FROM Pracownik WHERE CONCAT(Imie, ' ', Nazwisko) = @Data";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Data", data);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Pracownik zostal usuniety.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad usuwania pracownika: {ex.Message}");
            }
        }




        // Other 
        public void ReturnBook(string email, int bookID, bool ifPenaltyPayed)
        {
            try
            {
                int clientID = GetClientID(email);
                string query = "CALL ZwrocKsiazke(@ClientID, @BookID, @IfPenaltyPayed)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", clientID);
                    command.Parameters.AddWithValue("@BookID", bookID);
                    command.Parameters.AddWithValue("@IfPenaltyPayed", ifPenaltyPayed);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Ksiazka została zwrocona.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad zwracania ksiazki: {ex.Message}");
            }

        }

        public void ChangeWorkerSalary(string data, float newSalary)
        {
            try
            {
                int workerID = GetWorkerID(data);
                string query = "UPDATE Pracownik SET Wyplata = @NewSalary WHERE ID = @WorkerID";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewSalary", newSalary);
                    command.Parameters.AddWithValue("@WorkerID", workerID);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Wynagrodzenie pracownika zostało zaktualizowane.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad zmiany wynagrodzenia pracownika: {ex.Message}");
            }
        }

        public void PenaltyPayment(string email)
        {
            try
            {
                int clientID = GetClientID(email);
                string query = "UPDATE Klienci SET Naleznosc = 0 WHERE ID = @ClientID";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", clientID);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Platnosc za karę została zrealizowana.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad podczas realizacji platnosci za kare: {ex.Message}");
            }
        }




        // Returning data
        public List<BookData> GetHistory()
        {
            List<BookData> history = new List<BookData>();

            try
            {
                string query = @"
            SELECT k.ID, k.Tytul, a.Imie, a.Nazwisko, g.Nazwa_gatunku, k.ISBN, 
                   CASE WHEN w.Data_zwrotu IS NULL THEN false ELSE true END AS ifAvailable
            FROM Wypozyczenia w
            JOIN Klienci c ON w.KlientID = c.ID
            JOIN Ksiazki k ON w.KsiazkiID = k.ID
            JOIN Autor a ON k.AutorID = a.ID
            JOIN Gatunki g ON k.GatunekID = g.ID";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
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
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad pobierania historii: {ex.Message}");
            }

            return history;
        }

        public List<BookData> GetBorrowedBooks()
        {
            List<BookData> borrowedBooks = new List<BookData>();

            try
            {
                string query = @"
            SELECT k.ID, k.Tytul, a.Imie, a.Nazwisko, g.Nazwa_gatunku, k.ISBN, false AS ifAvailable
            FROM Wypozyczenia w
            JOIN Ksiazki k ON w.KsiazkiID = k.ID
            JOIN Autor a ON k.AutorID = a.ID
            JOIN Gatunki g ON k.GatunekID = g.ID
            WHERE w.Data_zwrotu IS NULL";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
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
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad pobierania wypozyczonych ksiazek: {ex.Message}");
            }

            return borrowedBooks;
        }

        public List<BookData> GetBooksCatalog(CatalogFilters filter)
        {
            List<BookData> catalog = new List<BookData>();

            try
            {
                string query = @"
        SELECT k.ID, k.Tytul, a.Imie, a.Nazwisko, g.Nazwa_gatunku, k.ISBN,
               CASE WHEN w.Data_zwrotu IS NULL THEN false ELSE true END AS ifAvailable
        FROM Ksiazki k
        LEFT JOIN Wypozyczenia w ON k.ID = w.KsiazkiID AND w.Data_zwrotu IS NULL
        JOIN Autor a ON k.AutorID = a.ID
        JOIN Gatunki g ON k.GatunekID = g.ID
        WHERE (@Genre IS NULL OR g.Nazwa_gatunku = @Genre)
        AND (@AuthorFirstName IS NULL OR a.Imie = @AuthorFirstName)
        AND (@AuthorLastName IS NULL OR a.Nazwisko = @AuthorLastName)
        AND (@Title IS NULL OR k.Tytul LIKE @Title)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Genre", filter.Genre ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@AuthorFirstName", filter.AuthorFirstName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@AuthorLastName", filter.AuthorLastName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Title", filter.Title != null ? $"%{filter.Title}%" : (object)DBNull.Value);

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
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad pobierania katalogu ksiazek: {ex.Message}");
            }

            return catalog;
        }

        public int GetGenreID(string genreName)
        {
            try
            {
                string query = "SELECT ID FROM Gatunki WHERE Nazwa_gatunku = @GenreName";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GenreName", genreName);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono gatunku");
                        return 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad pobierania ID gatunku {ex.Message}");
                return -1;
            }
        }
        public int GetPositionID(string name)
        {
            try
            {
                string query = "SELECT ID FROM Stanowisko WHERE Nazwa_stanowiska = @Name";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono ID stanowiska");
                        return 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad pobierania ID stanowiska {ex.Message}");
                return -1;
            }

        }
        public int GetAuthorID(string data)
        {
            try
            {
                string query = "SELECT ID FROM Autor WHERE CONCAT(Imie, ' ', Nazwisko) = @Data";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Data", data);
                    object result = command.ExecuteScalar();
                    if(result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono ID autora");
                        return 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad pobierania ID autora {ex.Message}");
                return -1;
            }

        }
        public int GetWorkerID(string data)
        {
            try
            {
                string query = "SELECT ID FROM Pracownik WHERE CONCAT(Imie, ' ', Nazwisko) = @Data";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Data", data);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                            return Convert.ToInt32(result);
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono ID pracownika");
                        return 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad pobierania ID pracownika {ex.Message}");
                return -1;
            }
        }
        public int GetLendID(int clientID, int bookID)
        {
            try
            {
                string query = "SELECT ID FROM Wypozyczenia WHERE KlienciID = @KlientID AND Katalog_ksiazekID = @KsiazkaID";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KlientID", clientID);
                    command.Parameters.AddWithValue("@KsiazkaID", bookID);
                    object result = command.ExecuteScalar();
                    if(result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono wypozyczenia dla podanych danych");
                        return -1;
                    }
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"Blad sprawdzania ID wypozyczenia {ex.Message}");
                return 0;
            }
        }
        public int GetClientID(string email)
        {
            try
            {
                string query = "SELECT ID FROM Klienci WHERE Adres_e_mail = @Email";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono ID klienta");
                        return 0;
                    }
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"Blad pobierania ID klienta {ex.Message}");
                return -1;
            }
        }
        public float GetWorkerSalary(string data)
        {
            try
            {
                int ID = GetWorkerID(data);
                string query = "SELECT SALARY FROM Pracownik WHERE ID == @ID";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    object result = command.ExecuteScalar();
                    if(result != DBNull.Value)
                    {
                        return Convert.ToSingle(result);
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono pracownika z podanym ID");
                        return 0;
                    }
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"Blad pobierania wyplaty pracownika: {ex.Message}");
                return 0;
            }
        }
        public bool IsBookAvailable(int ID)
        {
            try
            {
                string query = "SELECT Stan_magazynowy_ksiazki FROM Katalog_ksiazek WHERE KsiazkiID = @KsiazkiID";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
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
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad sprawdzania dostepnosci ksiazki{ex.Message}");
                return false;
            }
        }
        public bool IsClientInDatabase(int ID)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Klienci WHERE ID = @ID";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
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
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"Blad sprawdzania czy klient jest w bazie {ex.Message}");
                return false;
            }
        }
        public bool IsBookInDatabase(int ID)
        {
            try
            {
                string query = "SELECT  COUNT(*) FROM Ksiazki WHERE ID = @ID";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
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
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad sprawdzania dostepnosci ksiazki {ex.Message}");
                return false;
            }
        }
        public bool IsBookBorrowedByClient(int clientID, int bookID)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Wypozyczenia WHERE KlienciID = @KlientID AND Katalog_ksiazekID = @KsiazkaID ";
                using (MySqlCommand command = new MySqlCommand(@query, connection))
                {
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
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Blad sprawdzania czy ksiazka jest wypozyczona {ex.Message}");
                return false;
            }
        }
    }
}