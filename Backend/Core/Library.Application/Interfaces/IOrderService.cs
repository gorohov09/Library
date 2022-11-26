using Library.Application.Requests;
using Library.Application.Response;

namespace Library.Application.Interfaces
{
    public interface IOrderService
    {
        Task<ResponseOrder> CreateOrder(RequestOrder requestOrder);

        Task<ResponseApproveOrder> ApproveOrder(RequestApproveOrder requestApproveOrder);
    }
}
