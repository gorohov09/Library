using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianClient.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string LibraryCard { get; set; }
        public DateTime CreationDate { get; set; }
        public string BookPublisher { get; set; }
        public string BookYear { get; set; }
        public int RowNumber { get; set; }
        public string ReaderFullName { get; set; }
        public string BookAuthors { get; set; }

    }
}
