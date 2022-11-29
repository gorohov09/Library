using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStudentClient.DTO
{
    public class BookListDTO
    {
        public IEnumerable<BookDTO> BookDTO { get; set; } = new List<BookDTO>();
    }
}
