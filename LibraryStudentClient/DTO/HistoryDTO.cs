using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStudentClient.DTO
{
    public class HistoryDTO
    {
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string BookName { get; set; }
        public string BookPublisher { get; set; }
        public string bookYear { get; set; }

        public IEnumerable<AuthorDTO> Authors { get; set; } = new List<AuthorDTO>();
    }
}
