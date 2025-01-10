using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp
{
    public struct BookData
    {
        public int ID;
        public string title;
        public string authorFirstName;
        public string authorLastName;
        public string genreName;
        public string ISBN;
        public bool ifAvailable;
    }
}
