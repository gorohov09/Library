using Library.Domain.Entities;

namespace Library.DAL.Interfaces
{
    public interface IAccountRepository
    {
        Task<ReaderEntity> Registrate(string libraryCard, string fullName,
            string studentCard, string mobilePhone, string password);

        Task<ReaderEntity> Login(string studentCard, string password);
    }
}
