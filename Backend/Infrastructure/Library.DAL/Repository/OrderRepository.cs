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

        public async Task<IEnumerable<OrderEntity>> GetLibrarianOrders(TypeOrder typeOrders)
        {
            var orders = await _libraryContext.Orders
                .Where(x => x.Type == typeOrders && x.Status == StatusOrder.WAIT)
                .OrderBy(x => x.CreationDate)
                .Include(x => x.Reader)
                .Include(x => x.BookInsatnce)
                    .ThenInclude(x => x.BookInfo)
                        .ThenInclude(x => x.Authors)
                .ToListAsync();

            return orders;
        }

        public async Task<OrderEntity> GetOrderById(int orderId)
        {
            return await _libraryContext.Orders
                .Include(o => o.Reader)
                .Include(o => o.BookInsatnce)
                    .ThenInclude(bi => bi.BookInfo)
                        .ThenInclude(b => b.Authors)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<IEnumerable<OrderEntity>> GetReaderOrders(string libraryCard)
        {
            var orders = await _libraryContext.Orders
                .Where(x => x.ReaderId == libraryCard && x.Type == TypeOrder.ISSUE)
                .OrderBy(x => x.CreationDate)
                .Include(x => x.BookInsatnce)
                    .ThenInclude(x => x.BookInfo)
                        .ThenInclude(x => x.Authors)
                .ToListAsync();

            return orders;
        }

        public async Task<OrderEntity> SaveOrder(OrderEntity order)
        {
            _libraryContext.Orders.Add(order);
            await _libraryContext.SaveChangesAsync();
            return order;
        }

        public async Task<bool> UpdateOrder(OrderEntity order)
        {
            _libraryContext.Update(order);
            return (await _libraryContext.SaveChangesAsync()) > 0;
        }
    }
}
