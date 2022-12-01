using Library.Domain.Entities;

namespace Library.DAL.Interfaces
{
    public interface ILibrarianRepository
    {
        Task<LibrarianEntity> GetFirstLibrarian();

        Task<LibrarianEntity> GetLibrarianById(int librarianId);
    }
}
