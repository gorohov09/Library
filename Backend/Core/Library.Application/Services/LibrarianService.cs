using Library.Application.Interfaces;
using Library.Application.Vm;
using Library.DAL.Interfaces;
using Library.Domain.Entities;
using AutoMapper;

namespace Library.Application.Services
{
    public class LibrarianService : ILibrarianService
    {
        public Task<IEnumerable<OrderDetailsForReaderVm>> GetReaderOrders(string libraryCard)
        {
            throw new NotImplementedException();
        }
    }
}
