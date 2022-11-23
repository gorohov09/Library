using Library.Domain.Entities;

namespace Library.DAL.Interfaces
{
    public interface ILibrarianRepository
    {
        Task<LibrarianEntity> GetFirstLibrarian();
    }
}
