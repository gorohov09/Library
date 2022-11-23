using Library.DAL.Context;
using Library.DAL.Interfaces;
using Library.Domain.Entities;

namespace Library.DAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LibraryContext _libraryContext;

        public OrderRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<OrderEntity> SaveOrder(OrderEntity order)
        {
            _libraryContext.Orders.Add(order);
            await _libraryContext.SaveChangesAsync();
            return order;
        }
    }
}
