using Library.Application.Requests;
using Library.Application.Response;

namespace Library.Application.Interfaces
{
    public interface IAccountService
    {
        Task<ResponseRegistrate> Registrate(RequestRegistrate requestRegistrate);

        Task<ResponseLogin> Login(RequestLogin requestLogin);
    }
}
