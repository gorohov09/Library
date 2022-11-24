using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Vm
{
    public class BookDetailsVm
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string Year { get; set; }
        public string Section { get; set; }
        public int Count { get; set; }

        public IEnumerable<AuthorVm> Authors { get; set; }
    }
}
