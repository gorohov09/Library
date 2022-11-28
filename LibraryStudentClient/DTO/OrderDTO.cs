using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStudentClient.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExecutionDate { get; set; }
        public string Status { get; set; }
        public string BookPublisher { get; set; }
        public string Year { get; set; }
        public string Section { get; set; }
        public IEnumerable<AuthorDTO> Authors { get; set; } = new List<AuthorDTO>();
    }
}
