using LibrarianClient.Model;
using LibrarianClient.View.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianClient.DTO
{
    public class SearchReaderDTO
    {
        public List<SearchReaderClass> Readers { get; set; } = new List<SearchReaderClass>();
    }
}
