using Library.DAL.Context;
using Library.DAL.Interfaces;

namespace Library.DAL.Repository
{
    public class LibrarianRepository : ILibrarianRepository
    {
        private readonly LibraryContext _libraryContext;

        public LibrarianRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
    }
}
