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
        public bool AddBook(string title, string authorData, string ISBN, string genreName)
        {
            bool ifDataCorrect = false;
            int genreID = GetGenreID(genreName);
            // TODO: Napisac query

            if (ifDataCorrect) return true;
            else return false;
        }

        public void AddGenre(string name)
        {
            // TODO: Napisac query
        }

        public void AddWorker()
        {
            // TODO: Napisac query
        }

        public void ClientRegistration()
        {
            // TODO: Napisac query
        }

        public void LendBook()
        {
            // TODO: Napisac query
        }




        // Logging in 
        public bool ClientLogIn(string email, string cardNumber)
        {
            // TODO: Napisac query
            // TODO: Ma zwracac true jesli sie uda i fase jesli sie nie uda 

            return true;
        }

        public bool WorkerLogIn(bool ifDirector)
        {
            // TODO: Napisac query
            // TODO: Ma zwracac true jesli sie uda i fase jesli sie nie uda 

            if (ifDirector) return true;
            else return true;
        }




        // Removing records
        public void RemoveBook()
        {
            // TODO: Napisac query
        }

        public void RemoveGenre()
        {
            // TODO: Napisac query
        }

        public void RemoveWorker()
        {
            // TODO: Napisac query
        }




        // Other 
        public void ReturnBook()
        {
            // TODO: Napisac query
        }

        public int SearchingClient()
        {
            int clientID=0;
            // TODO: Napisac query, zeby zwracal id klienta 
            return clientID;
        }

        public void ChangeWorkerSalary()
        {
            // TODO: Napisac query
        }

        public void PenaltyPayment()
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
        public List<BookData> GetBooksCatalog()
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
    }
}
