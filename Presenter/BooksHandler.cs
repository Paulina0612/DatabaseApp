using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DatabaseApp.Presenter
{
    public class BooksHandler 
    {
        public bool AddNewTitle(string title, int authorID, string ISBN, int genreID)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();

                string query = @"INSERT INTO BOOKS (ID, TITLE, AUTHOR_ID, GENRE_ID, ISBN) 
                                    VALUES (@ID, @Title, @AuthorID, @GenreID, @ISBN)";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ID", GetNextBookTitleId());
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@AuthorID", authorID);
                command.Parameters.AddWithValue("@GenreID", genreID);
                command.Parameters.AddWithValue("@ISBN", ISBN);
                command.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return false;
            }
        }

        private int GetNextBookTitleId()
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "SELECT MAX(ID) FROM BOOKS";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    try
                    {
                        return Convert.ToInt32(result) + 1;
                    }
                    catch (Exception)
                    {
                        return 1;
                    }
                }
                else
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

        public bool AddNewCopy(int id)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();

                string query = @"INSERT INTO BOOKS_CATALOG (ID, BOOK_ID, BOOK_STATE) 
                                    VALUES (@ID, @BookID, @State)";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                string state = "AVAILABLE";
                command.Parameters.AddWithValue("@ID", GetNextCopyId());
                command.Parameters.AddWithValue("@BookID", id);
                command.Parameters.AddWithValue("@State", state);
                command.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return false;
            }
        }

        private int GetNextCopyId()
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "SELECT MAX(ID) FROM BOOKS_CATALOG";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    int id;

                    try { id = Convert.ToInt32(result) + 1; }
                    catch (Exception) { id = 1; }

                    return id;
                }
                else
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

        public bool LendBook(string clientEmail, int bookID)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();

                if(GetBorrowedBooks().Count == 5)
                {
                    MessageBox.Show("Client has borrowed 5 books.");
                    return false;
                }

                int clientID = Program.communicationHandler.clientsHandler.GetClientID(clientEmail);
                string query = @"
                    insert into BORROWS 
                        (ID, CLIENT_ID, BOOKS_CATALOG_ID, BORROW_DATE, DATE_DUE, IF_FINISHED)
                    values 
                        (@ID, @ClientID, @BookID, CURRENT_DATE(), DATE_ADD(CURRENT_DATE(), 
                        INTERVAL 30 DAY), false);";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                int id = GetNextLoanId();
                if(id == -1)
                {
                    return false;
                }
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@ClientID", clientID);
                command.Parameters.AddWithValue("@BookID", bookID);
                command.Parameters.AddWithValue("@WorkerID", SQLCommunicationHandler.LoggedUserID);
                command.ExecuteNonQuery();

                string updateQuery = "update BOOKS_CATALOG set BOOK_STATE=@State where ID=@BookID";
                MySqlCommand updateCommand = new MySqlCommand(updateQuery, 
                    Program.communicationHandler.connection);

                updateCommand.Parameters.AddWithValue("@BookID", bookID);
                updateCommand.Parameters.AddWithValue("@State", "UNAVAILABLE");
                updateCommand.ExecuteNonQuery();

                return true;
            }
            catch 
            {
                return false;
            }
        }


        private int GetNextLoanId()
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "SELECT MAX(ID) FROM BORROWS";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    int id;

                    try { id = Convert.ToInt32(result) + 1; }
                    catch (Exception) { id = 1; }

                    return id;
                }
                else
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

        public bool RemoveBook(int bookID)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "update BOOKS_CATALOG set BOOK_STATE=@State where ID=@BookID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@BookID", bookID);
                command.Parameters.AddWithValue("@State", "REMOVED");
                command.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return false;
            }

        }


        public bool ReturnBook(int bookID)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                int lendID = GetLendID(bookID);

                if (lendID == -1)
                {
                    return false;
                }

                string query = @"
                    insert into returns (ID, BORROW_ID, RETURN_DATE, PENALTY)
                    values (@ID, @BorrowID, CURRENT_DATE(), @Penalty);";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ID", GetNextReturnId());
                command.Parameters.AddWithValue("@BorrowID", lendID);
                command.Parameters.AddWithValue("@Penalty", CalculatePenalty(lendID));
                command.Parameters.AddWithValue("@WorkerID", SQLCommunicationHandler.LoggedUserID);
                command.ExecuteNonQuery();

                string updateQuery = "update BOOKS_CATALOG set BOOK_STATE=@State where ID=@BookID";
                MySqlCommand updateCommand = new MySqlCommand(updateQuery, Program.communicationHandler.connection);

                updateCommand.Parameters.AddWithValue("@BookID", bookID);
                updateCommand.Parameters.AddWithValue("@State", "AVAILABLE");
                updateCommand.ExecuteNonQuery();

                string upQuery = "update borrows set if_finished=true where ID=@BorrowID";
                MySqlCommand upCommand = new MySqlCommand(upQuery, Program.communicationHandler.connection);

                upCommand.Parameters.AddWithValue("@BorrowID", lendID);
                upCommand.ExecuteNonQuery();

                return true;
            }
            catch 
            {
                return false;
            }

        }

        private float CalculatePenalty(int lendID)
        {
            float penalty = 0;

            try
            {
                Program.communicationHandler.InitializeConnection();
                string datediffQuery = "SELECT DATEDIFF((SELECT BORROW_DATE from borrows where ID=@BorrowID), " +
                    "CURRENT_DATE()) as diff";
                MySqlCommand command = new MySqlCommand(datediffQuery, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@BorrowID", lendID);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        penalty = reader.GetInt32("diff");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
            }

            return penalty;
        }

        private int GetNextReturnId()
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "SELECT MAX(ID) FROM RETURNS";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    int id;

                    try { id = Convert.ToInt32(result) + 1; }
                    catch (Exception) { id = 1; }

                    return id;
                }
                else
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

        private int GetLendID(int bookID)
        {
            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = "SELECT ID FROM BORROWS WHERE BOOKS_CATALOG_ID = @BookID and IF_FINISHED=false";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@BookID", bookID);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return -1;
                }
            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return -1;
            }
        }

        public List<BookData> GetHistory()
        {
            List<BookData> history = new List<BookData>();

            try
            {
                Program.communicationHandler.InitializeConnection();
                string query = @"
                    SELECT k.ID, k.TITLE, a.FIRST_NAME, a.LAST_NAME, g.NAME, k.ISBN
                    FROM BORROWS w
                    JOIN CLIENTS c ON w.CLIENT_ID = c.ID
                    JOIN BOOKS_CATALOG kk ON w.BOOKS_CATALOG_ID = kk.ID
                    JOIN BOOKS k ON kk.BOOK_ID  = k.ID
                    JOIN AUTHORS a ON k.AUTHOR_ID = a.ID
                    JOIN GENRES g ON k.GENRE_ID = g.ID
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
                            title = reader.GetString("TITLE"),
                            authorFirstName = reader.GetString("FIRST_NAME"),
                            authorLastName = reader.GetString("LAST_NAME"),
                            genreName = reader.GetString("NAME"),
                            ISBN = reader.GetString("ISBN"),
                            ifAvailable = true
                        };
                        history.Add(book);
                    }
                }

            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
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
                SELECT k.ID, k.TITLE, a.FIRST_NAME, a.LAST_NAME, g.NAME, k.ISBN
                FROM BORROWS w
                JOIN CLIENTS c ON w.CLIENT_ID = c.ID
                JOIN BOOKS_CATALOG kk ON w.BOOKS_CATALOG_ID = kk.ID
                JOIN BOOKS k ON kk.BOOK_ID  = k.ID
                JOIN AUTHORS a ON k.AUTHOR_ID = a.ID
                JOIN GENRES g ON k.GENRE_ID = g.ID
                WHERE c.ID = @ClientId and w.IF_FINISHED=false";

                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ClientId", SQLCommunicationHandler.LoggedUserID);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BookData book = new BookData
                        {
                            ID = reader.GetInt32("ID"),
                            title = reader.GetString("TITLE"),
                            authorFirstName = reader.GetString("FIRST_NAME"),
                            authorLastName = reader.GetString("LAST_NAME"),
                            genreName = reader.GetString("NAME"),
                            ISBN = reader.GetString("ISBN"),
                            ifAvailable = false 
                        };
                        borrowedBooks.Add(book);
                    }
                }

            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
            }

            return borrowedBooks;
        }


        public List<BookData> GetBooksCatalog(int genreFilter)
        {
            string query = @"
                SELECT kk.ID, k.TITLE, a.FIRST_NAME, a.LAST_NAME, g.NAME, k.ISBN, kk.BOOK_STATE
                FROM BOOKS_CATALOG kk 
                join BOOKS k on kk.BOOK_ID = k.ID 
                JOIN AUTHORS a ON k.AUTHOR_ID = a.ID
                JOIN GENRES g ON k.GENRE_ID = g.ID
                WHERE (@GenreFilter IS NULL OR g.ID = @GenreFilter)";

            try
            {
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);
                if (genreFilter == -1)
                {
                    command.Parameters.AddWithValue("@GenreFilter", null);
                }
                else
                {
                    command.Parameters.AddWithValue("@GenreFilter", genreFilter);
                }

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    List<BookData> books = new List<BookData>();

                    while (reader.Read())
                    {
                        if(reader.GetString("BOOK_STATE") == "REMOVED")
                        {
                            continue;
                        }
                        BookData book = new BookData
                        {
                            ID = reader.GetInt32("ID"),
                            title = reader.GetString("TITLE"),
                            authorFirstName = reader.GetString("FIRST_NAME"),
                            authorLastName = reader.GetString("LAST_NAME"),
                            genreName = reader.GetString("NAME"),
                            ISBN = reader.GetString("ISBN"),
                            ifAvailable = reader.GetString("BOOK_STATE") == "AVAILABLE" ? true : false
                        };

                        books.Add(book);
                    }

                    return books;
                }
            }
            catch (Exception ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return null;
            }
        }


        public List<BookData> GetTitlesCatalog(int genreFilter)
        {
            string query = @"
                SELECT k.ID, k.TITLE, a.FIRST_NAME, a.LAST_NAME, g.NAME, k.ISBN
                FROM BOOKS k 
                JOIN AUTHORS a ON k.AUTHOR_ID = a.ID
                JOIN GENRES g ON k.GENRE_ID = g.ID
                WHERE (@GenreFilter IS NULL OR g.ID = @GenreFilter)";

            try
            {
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);
                if (genreFilter == -1)
                {
                    command.Parameters.AddWithValue("@GenreFilter", null);
                }
                else
                {
                    command.Parameters.AddWithValue("@GenreFilter", genreFilter);
                }

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    List<BookData> books = new List<BookData>();

                    while (reader.Read())
                    {
                        BookData book = new BookData
                        {
                            ID = reader.GetInt32("ID"),
                            title = reader.GetString("TITLE"),
                            authorFirstName = reader.GetString("FIRST_NAME"),
                            authorLastName = reader.GetString("LAST_NAME"),
                            genreName = reader.GetString("NAME"),
                            ISBN = reader.GetString("ISBN")
                        };

                        books.Add(book);
                    }

                    return books;
                }
            }
            catch (Exception ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return null;
            }
        }


        public bool IsBookAvailable(int ID)
        {
            try
            {
                string query = "SELECT BOOK_STATE FROM BOOKS_CATALOG WHERE ID = @BookID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@BookID", ID);
                object result = command.ExecuteScalar();
                if (result != null && result.ToString() == "AVAILABLE")
                    return true;
                else
                    return false;

            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return false;
            }
        }


        public bool IsBookInDatabase(int ID)
        {
            try
            {
                string query = "SELECT  COUNT(*) FROM BOOKS WHERE ID = @ID";
                MySqlCommand command = new MySqlCommand(query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ID", ID);
                object result = command.ExecuteScalar();
                if (result != null && Convert.ToInt32(result) > 0)
                    return true;
                else
                    return false;

            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return false;
            }
        }


        public bool IsBookBorrowedByClient(int clientID, int bookID)
        {
            try
            {
                string query = @"SELECT COUNT(*) 
                    FROM BORROWS 
                    WHERE CLIENT_ID = @ClientID AND BOOKS_CATALOG_ID = @BookID";
                MySqlCommand command = new MySqlCommand(@query, Program.communicationHandler.connection);

                command.Parameters.AddWithValue("@ClientID", clientID);
                command.Parameters.AddWithValue("@BookID", bookID);
                object result = command.ExecuteScalar();
                if (result != null && Convert.ToInt32(result) > 0)
                    return true;
                else
                    return false;

            }
            catch (MySqlException ex)
            {
                Program.communicationHandler.ErrorOccured(ex.ToString());
                return false;
            }
        }
    }
}
