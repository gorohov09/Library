using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Vm
{
    public class ReaderVm
    {
        public string LibraryCard { get; set; }
        public string FullName { get; set; }
        public string? BirthYear { get; set; }
        public string StudentCard { get; set; }
        public string MobilePhone { get; set; }
        public IEnumerable<RecordDetailsForReaderVm> History { get; set; }

    }
}
