using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp
{
    public struct ClientData 
    {
        public int ID;
        public string firstName;
        public string lastName;
        public string email;
        public float penalty;

        public int getID()  {  return ID;  }
        public string getFirstName() {  return firstName;  }
        public string getLastName() {  return lastName;  }
        public string getEmail()  {  return email;  }
        public float getPenalty() { return penalty; }
    }
}
