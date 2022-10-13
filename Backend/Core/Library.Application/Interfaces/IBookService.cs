using Library.Application.Vm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookVm>> GetAllBooks();
    }
}
