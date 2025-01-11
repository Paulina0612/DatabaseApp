using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp
{
    public class SQLCommunicationHandler 
    {
        private SqlConnection connection;

        public SQLCommunicationHandler() 
        {
            // TODO: Poloczyc sie z baza
        }


        // Adding records  
        public void AddBook(string title, string authorData, string ISBN, string genreName)
        {
            int genreID = GetGenreID(genreName);
            // TODO: Napisac query
        }
        public void AddAuthor(string firstName, string lastName)
        {
            // TODO: Napisac query
        }
        public void AddGenre(string name)
        {
            // TODO: Napisac query
        }

        public void AddWorker(string firstName, string lastName, string phoneNumber, string email, string PESEL, float salary, string managerData, string positionName)
        {
            // TODO: Napisac query
        }

        public void ClientRegistration(string firstName, string lastName, string email)
        {
            // TODO: Napisac query
            // TODO: Ogarnac ten numer karty 
        }

        public void LendBook(string clientEmail, int bookID)
        {
            // TODO: Napisac query
            //TODO: Tu jeszcze trzeba wymyslic jak pobrac, ktory to pracownik dodaje plus te daty
        }




        // Logging in 
        public bool ClientLogIn(string email, string cardNumber)
        {
            // TODO: Napisac query
            // TODO: Ma zwracac true jesli sie uda i fase jesli sie nie uda 

            return true;
        }

        public bool WorkerLogIn(bool ifDirector, string firstName, string lastName, string password)
        {
            // TODO: Napisac query
            // TODO: Ma zwracac true jesli sie uda i fase jesli sie nie uda 

            return true;
        }




        // Removing records
        public void RemoveBook(int bookID)
        {
            // TODO: Napisac query
        }

        public void RemoveGenre(string name)
        {
            // TODO: Napisac query
        }

        public void RemoveAuthor(string data)
        {
            // TODO: Napisac query
        }

        public void RemoveWorker(string data)
        {
            // TODO: Napisac query
        }




        // Other 
        public void ReturnBook(string email, int bookID, bool ifPenaltyPayed)
        {
            int clientID = GetClientID(email);
            // TODO: Napisac query
        }

        public void ChangeWorkerSalary(string data, float newSalary)
        {
            int workerID = GetWorkerID(data);
            // TODO: Napisac query
        }

        public void PenaltyPayment(string email)
        {
            // TODO: Napisac query
        }




        // Returning data
        public List<BookData> GetHistory()
        {
            List<BookData> history = new List<BookData>();

            //TODO: Wypelnic liste

            return history;
        }
        public List<BookData> GetBorrowedBooks()
        {
            List<BookData> borrowedBooks = new List<BookData>();

            //TODO: Wypelnic liste

            return borrowedBooks;
        }
        public List<BookData> GetBooksCatalog(CatalogFilters filter)
        {
            List<BookData> catalog = new List<BookData>();

            //TODO: Wypelnic liste
            //TODO: Plus tu bedzie trzeba dodac jakies parametry, zeby filtrowac katalog

            return catalog;
        }
        public int GetGenreID(string name)
        {
            int ID = 0;
            //TODO: Pobrac id po name

            return ID;
        }
        public int GetPositionID(string name)
        {
            int ID = 0;
            //TODO: Pobrac id po name

            return ID;
        }
        public int GetAuthorID(string data)
        {
            int ID = 0;
            //TODO: Pobrac id po name

            return ID;
        }
        public int GetWorkerID(string data)
        {
            int ID = 0;
            //TODO: Pobrac id po name

            return ID;
        }
        public int GetLendID(int clientID, int bookID)
        {
            int ID = 0;
            //TODO: Pobrac id po name

            return ID;
        }
        public int GetClientID(string email)
        {
            int ID = 0;
            //TODO: Pobrac id po name

            return ID;
        }
        public float GetWorkerSalary(string data)
        {
            int ID = GetWorkerID(data);
            //TODO: Pobrac wyplate po name

            return ID;
        }
        public bool IsBookAvailable(int ID)
        {
            //TODO: Sprawdzic, czy ksiazka jest dostepna

            return true;

        }
        public bool IsClientInDatabase(int ID)
        {
            //TODO: Sprawdzic, czy klient jest w bazie

            return true;
        }
        public bool IsBookInDatabase(int id)
        {
            //TODO: Sprawdzic, czy klient jest w bazie

            return true;
        }
        public bool IsBookBorrowedByClient(int clientID, int bookID)
        {
            bool ifBookInDatabase = IsBookInDatabase(bookID);
            bool ifBookBorrowedByClient = true;
            //TODO: Sprawdzic, czy klient wypozyczyl ksiazke

            if (ifBookInDatabase && ifBookBorrowedByClient) return true;
            else return false;
        }
    }
}
