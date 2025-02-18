using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseApp.Presenter
{
    public class BooksHandler 
    {
        public void AddBook(string title, string authorData, string ISBN, string genreName)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                int authorID = Program.communicationHandler.authorsHandler.GetAuthorID(authorData);
                int genreID = Program.communicationHandler.genresHandler.GetGenreID(genreName);

                string query = "INSERT INTO Ksiazki (Tytul, AutorID, GatunekID, ISBN) VALUES (@Title, @AuthorID, @GenreID, @ISBN)";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

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

        public void LendBook(string clientEmail, int bookID)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                int clientID = Program.communicationHandler.clientsHandler.GetClientID(clientEmail);
                string query = "CALL DodajWypozyczenie(@ClientID, @BookID, @WorkerID, CURDATE(), DATE_ADD(CURDATE(), INTERVAL 14 DAY))";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ClientID", clientID);
                command.Parameters.AddWithValue("@BookID", bookID);
                command.Parameters.AddWithValue("@WorkerID", SQLCommunicationHandler.LoggedUserID);
                command.ExecuteNonQuery();


                MessageBox.Show("Wypozyczenie zostalo dodane.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad wypozyczenia ksiazki: {ex.Message}");
            }
        }


        // Removing records
        public void RemoveBook(int bookID)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "DELETE FROM Ksiazki WHERE ID = @KsiazkiID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@KsiazkiID", bookID);
                command.ExecuteNonQuery();


                MessageBox.Show("Ksiazka została usunieta.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Blad usuwania ksiazki: {ex.Message}");
            }

        }


        public void ReturnBook(string email, int bookID, bool ifPenaltyPayed)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                int clientID = Program.communicationHandler.clientsHandler.GetClientID(email);
                string query = "CALL ZwrocKsiazke(@ClientID, @BookID, @IfPenaltyPayed)";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

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


        // Returning data
        public List<BookData> GetHistory()
        {
            List<BookData> history = new List<BookData>();

            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = @"
        SELECT k.ID, k.Tytul, a.Imie, a.Nazwisko, g.Nazwa_gatunku, k.ISBN, 
               CASE WHEN w.Data_spodziewanego_zwrotu IS NULL THEN false ELSE true END AS ifAvailable
        FROM Wypozyczenia w
        JOIN Klienci c ON w.KlientID = c.ID
        JOIN Ksiazki k ON w.Katalog_ksiazekID = k.ID
        JOIN Autor a ON k.AutorID = a.ID
        JOIN Gatunki g ON k.GatunekID = g.ID
        WHERE c.ID = @ClientId";

                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ClientId", SQLCommunicationHandler.LoggedUserID);

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
                Program.communicationHandler.InitializeConnection();
                string query = @"
                SELECT k.ID, k.Tytul, a.Imie, a.Nazwisko, g.Nazwa_gatunku, k.ISBN, false AS ifAvailable
                FROM Wypozyczenia w
                JOIN Ksiazki k ON w.Katalog_ksiazekID = k.ID
                JOIN Autor a ON k.AutorID = a.ID
                JOIN Gatunki g ON k.GatunekID = g.ID            
                JOIN Klienci kl ON w.KlientID = kl.ID
                WHERE w.KlientID = @KlientID AND w.ID NOT IN (SELECT Wypozyczenie_ID FROM Zwroty)";

                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@KlientID", SQLCommunicationHandler.LoggedUserID);
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
                Program.communicationHandler.InitializeConnection();
                string query = @"
                    SELECT kk.ID, k.Tytul, a.Imie, a.Nazwisko, g.Nazwa_gatunku, k.ISBN, kk.Stan_magazynowy_ksiazki,
                    CASE WHEN w.Katalog_ksiazekID IS NULL THEN 1 ELSE 0 END AS ifAvailable
                    FROM biblioteka.Katalog_ksiazek kk
                    JOIN biblioteka.Ksiazki k ON kk.KsiazkiID = k.ID 
                    LEFT JOIN biblioteka.Wypozyczenia w ON kk.ID = w.Katalog_ksiazekID AND w.Data_spodziewanego_zwrotu IS NULL
                    JOIN biblioteka.Autor a ON k.AutorID = a.ID
                    JOIN biblioteka.Gatunki g ON k.GatunekID = g.ID
                    WHERE (g.Nazwa_gatunku = @Genre)";

                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

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
                //MessageBox.Show($"Error fetching books catalog: {ex.Message}");
            }

            return catalog;
        }


        public bool IsBookAvailable(int ID)
        {
            try
            {
                //InitializeConnection();
                string query = "SELECT Stan_magazynowy_ksiazki FROM Katalog_ksiazek WHERE KsiazkiID = @KsiazkiID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

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


        public bool IsBookInDatabase(int ID)
        {
            try
            {
                //InitializeConnection();
                string query = "SELECT  COUNT(*) FROM Ksiazki WHERE ID = @ID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ID", ID);
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
                MySqlCommand command = new MySqlCommand(@query, Program.communicationHandler.connection);

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
    }
}
