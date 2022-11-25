using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Vm
{
    public class RecordDetailsForReaderVm
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string BookName { get; set; }
        public string BookPublisher { get; set; }
        public string BookYear { get; set; }
        public IEnumerable<AuthorVm> BookAuthors { get; set; }
    }
}
