using Library.Application.Requests;
using Library.Application.Response;
using Library.Application.Vm;

namespace Library.Application.Interfaces
{
    public interface IOrderService
    {
        Task<ResponseOrder> CreateOrder(RequestOrder requestOrder);
        
        Task<OrderDetailsForLibrarianVm> GetOrderDetails(int orderId);

        Task<ResponseApproveOrder> ApproveOrder(RequestApproveOrder requestApproveOrder);
    }
}
