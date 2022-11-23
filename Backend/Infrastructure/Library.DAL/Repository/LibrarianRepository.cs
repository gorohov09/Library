using Library.DAL.Context;
using Library.DAL.Interfaces;
using Library.Domain.Entities;

namespace Library.DAL.Repository
{
    public class LibrarianRepository : ILibrarianRepository
    {
        private readonly LibraryContext _libraryContext;

        public LibrarianRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<LibrarianEntity> GetFirstLibrarian()
        {
            return _libraryContext.Librarians.Count() == 0 ? null : _libraryContext.Librarians.ElementAt(0);
        }
    }
}
