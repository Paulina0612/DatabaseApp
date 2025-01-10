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
        public void AddBook()
        {
            // TODO: Napisac kod xD
        }

        public void AddGenre()
        {
            // TODO: Napisac kod xD
        }

        public void AddWorker()
        {
            // TODO: Napisac kod xD
        }

        public void ClientRegistration()
        {
            // TODO: Napisac kod xD
        }

        public void LendBook()
        {
            // TODO: Napisac kod xD
        }




        // Logging in 
        public void ClientLogIn()
        {
            // TODO: Napisac kod xD
        }

        public void WorkerLogIn()
        {
            // TODO: Napisac kod xD
        }




        // Removing records
        public void RemoveBook()
        {
            // TODO: Napisac kod xD
        }

        public void RemoveGenre()
        {
            // TODO: Napisac kod xD
        }

        public void RemoveWorker()
        {
            // TODO: Napisac kod xD
        }




        // Other 
        public void ReturnBook()
        {
            // TODO: Napisac kod xD
        }

        public int SearchingClient()
        {
            int clientID=0;
            // TODO: Napisac kod, zeby zwracal id klienta xD
            return clientID;
        }

        public void ChangeWorkerSalary()
        {
            // TODO: Napisac kod xD
        }

        public void PenaltyPayment()
        {
            // TODO: Napisac kod xD
        }
    }
}
