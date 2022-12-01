using Library.DAL.Context;
using Library.DAL.Interfaces;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
            return await _libraryContext.Librarians.FirstOrDefaultAsync();
        }

        public async Task<LibrarianEntity> GetLibrarianById(int librarianId)
        {
            return await _libraryContext.Librarians.FirstOrDefaultAsync(l => l.Id == librarianId);
        }
    }
}
