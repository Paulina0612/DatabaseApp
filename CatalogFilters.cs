using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp
{
    public class CatalogFilters
    {
        public string Genre { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string Title { get; set; }

        // Konstruktor, który pozwala na opcjonalne ustawienie filtrów
        public CatalogFilters(string genre = null, string authorFirstName = null, string authorLastName = null, string title = null)
        {
            Genre = genre;
            AuthorFirstName = authorFirstName;
            AuthorLastName = authorLastName;
            Title = title;
        }
    }
}
