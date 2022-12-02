using Library.Domain.Entities;

namespace Library.DAL.Interfaces
{
    public interface IAccountRepository
    {
        Task<ReaderEntity> Registrate(string libraryCard, string fullName,
            string studentCard, string mobilePhone, string password);

        Task<ReaderEntity> Login(string studentCard, string password);
        
        Task<LibrarianEntity> LoginLibrarian(string login, string password);
        
        Task<LibrarianEntity> RegistrateLibrarian(string? fullName, string mobilePhone,string login, string password);
    }
}
