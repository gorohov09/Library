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
        public string LibraryCard { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string DateOfCreation { get; set; }
        public int RowNumber { get; set; }
        public string Year { get; set; }
        public string Publisher { get; set; }
        public string Authors { get; set; }

    }
}
