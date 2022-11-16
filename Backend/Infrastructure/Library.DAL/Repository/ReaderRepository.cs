using Library.DAL.Context;
using Library.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repository
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly LibraryContext _libraryContext;

        public ReaderRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<bool> IsLibraryCard(string libraryCard)
        {
            return await _libraryContext.Readers.AnyAsync(reader => reader.LibraryCard == libraryCard);
        }

        public async Task<bool> IsStudentCard(string studentCard)
        {
            return await _libraryContext.Readers.AnyAsync(reader => reader.StudentCard == studentCard);
        }
    }
}
