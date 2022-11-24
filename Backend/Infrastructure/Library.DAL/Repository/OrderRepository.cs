using Library.DAL.Context;
using Library.DAL.Interfaces;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LibraryContext _libraryContext;

        public OrderRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<IEnumerable<OrderEntity>> GetLibrarianOrders(int librarianId)
        {
            var orders = await _libraryContext.Orders
                .Where(x => x.LibrarianId == librarianId)
                .OrderBy(x => x.CreationDate)
                .Include(x => x.BookInsatnce)
                    .ThenInclude(x => x.BookInfo)
                .ToListAsync();

            return orders;
        }

        public async Task<IEnumerable<OrderEntity>> GetReaderOrders(string libraryCard)
        {
            var orders = await _libraryContext.Orders
                .Where(x => x.ReaderId == libraryCard)
                .OrderBy(x => x.CreationDate)
                .Include(x => x.BookInsatnce)
                    .ThenInclude(x => x.BookInfo)
                .ToListAsync();

            return orders;
        }

        public async Task<OrderEntity> SaveOrder(OrderEntity order)
        {
            _libraryContext.Orders.Add(order);
            await _libraryContext.SaveChangesAsync();
            return order;
        }
    }
}
