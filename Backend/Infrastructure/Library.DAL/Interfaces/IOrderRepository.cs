using Library.Domain.Entities;

namespace Library.DAL.Interfaces
{
    public interface IOrderRepository
    {
        Task<OrderEntity> SaveOrder(OrderEntity order);

        Task<IEnumerable<OrderEntity>> GetReaderOrders(string libraryCard);
    }
}
