using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//-----------------------------------------------------------------------------------------------

// TODO: Nie działa wypożyczanie książek: BooksCatalog pokazuje już nie pustą tabelę, ale dziwnie ją wyświetla, a przy próbie wypożyczenia książki wyrzuca incorrect data

//-----------------------------------------------------------------------------------------------

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
                MessageBox.Show($"Error adding the book: {ex.Message}");
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


                MessageBox.Show("Loan has been added.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error lending the book: {ex.Message}");
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


                MessageBox.Show("Book has been removed.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error removing the book: {ex.Message}");
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

                MessageBox.Show("Book has been returned.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error returning the book: {ex.Message}");
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
                MessageBox.Show($"Error retrieving history: {ex.Message}");
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
                SELECT k.ID, k.Tytul, a.Imie, a.Nazwisko, g.Nazwa_gatunku, k.ISBN,
                CASE 
                     WHEN w.ID IN (SELECT Wypozyczenie_ID FROM Zwroty) THEN true 
                        ELSE false 
                    END AS ifAvailable
                FROM Ksiazki k
                JOIN Autor a ON k.AutorID = a.ID
                JOIN Gatunki g ON k.GatunekID = g.ID
                LEFT JOIN Wypozyczenia w ON k.ID = w.Katalog_ksiazekID
                WHERE w.KlientID = @KlientID OR w.ID IS NULL";

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
                MessageBox.Show($"Error retrieving borrowed books: {ex.Message}");
            }

            return borrowedBooks;
        }


        public List<BookData> GetBooksCatalog(string genreFilter)
        {
            string query = @"
        SELECT k.ID, k.Tytul, a.Imie, a.Nazwisko, g.Nazwa_gatunku, k.ISBN,
               CASE 
                   WHEN w.ID IS NULL THEN true 
                   WHEN w.ID IN (SELECT Wypozyczenie_ID FROM Zwroty) THEN true 
                   ELSE false 
               END AS ifAvailable
        FROM Ksiazki k
        JOIN Autor a ON k.AutorID = a.ID
        JOIN Gatunki g ON k.GatunekID = g.ID
        LEFT JOIN Wypozyczenia w ON k.ID = w.Katalog_ksiazekID
        WHERE (@GenreFilter IS NULL OR g.Nazwa_gatunku LIKE @GenreFilter)";

            try
            {
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);
                command.Parameters.AddWithValue("@GenreFilter", $"%{genreFilter}%");

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    List<BookData> books = new List<BookData>();

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

                        books.Add(book);
                    }

                    return books;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Błąd podczas pobierania katalogu książek: {ex.Message}", ex);
            }
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
                MessageBox.Show($"Error checking book's avaibility. {ex.Message}");
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
                MessageBox.Show($"Error checking book's avaibility in the database. {ex.Message}");
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
                MessageBox.Show($"Error checking book's borrowed status. {ex.Message}");
                return false;
            }
        }
    }
}
