using Library.Domain.Entities;

namespace Library.DAL.Interfaces
{
    public interface IAccountRepository
    {
        Task<ReaderEntity> Registrate(string libraryCard, string fullName, string birthYear,
            string studentCard, string mobilePhone, string password);
    }
}
