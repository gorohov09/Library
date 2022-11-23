using Library.Domain.Entities;

namespace Library.DAL.Interfaces
{
    public interface ILibrarianRepository
    {
        public async Task<LibrarianEntity> GetFirstLibrarian();
    }
}
