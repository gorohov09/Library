using Library.DAL.Context;
using Library.DAL.Interfaces;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repository
{
    public class RecordRepository : IRecordRepository
    {
        private readonly LibraryContext _libraryContext;
        public RecordRepository(LibraryContext context)
        {
            _libraryContext = context;
        }

        public async Task<IEnumerable<RecordEntity>> GetReadersHistory(string libraryCard)
        {
            var history = _libraryContext.Records
                .Where(x => x.ReaderID == libraryCard)
                .OrderBy(x => x.IssueDate)
                .Include(x => x.BookInsatnce)
                    .ThenInclude(x => x.BookInfo)
                .ToList();

            return history;
        }
    }
}
