using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStudentClient.DTO
{
    public class RequestOrderDTO
    {
        public string LibraryCard { get; set; }
        public string BookISBN { get; set; }
    }
}
