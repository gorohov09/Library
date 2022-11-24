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
        public bool IsHasDebt { get; set; }
        public string MobilePhone { get; set; }
        public string Password { get; set; }
        public IEnumerable<OrderEntity> Orders { get; set; }
        public IEnumerable<RecordEntity> History { get; set; }

    }
}
