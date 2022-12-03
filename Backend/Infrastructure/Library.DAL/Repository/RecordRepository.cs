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

        /// <summary>
        /// Метод используется, для поиска истории, которая была создана другим библиотекарем
        /// </summary>
        /// <param name="bookInstanceId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<RecordEntity> GetCreatedRecord(int bookInstanceId)
        {
            return await _libraryContext.Records
                .FirstOrDefaultAsync(x => x.BookInsatnce.Id == bookInstanceId && x.ReturnDate == null);
        }

        public Task<RecordEntity> GetFreeRecord(int bookInstanceId)
        {
            var freeHistory = _libraryContext.Records
                .Where(r => r.BookId == bookInstanceId && r.ReturnDate != null)
                .FirstOrDefaultAsync(r => r.ReturnDate.Value.Year == 1970);

            return freeHistory;
        }

        public async Task<IEnumerable<RecordEntity>> GetReadersHistory(string libraryCard)
        {
            var history = _libraryContext.Records
                .Where(x => x.ReaderID == libraryCard)
                .OrderBy(x => x.IssueDate)
                .Include(x => x.BookInsatnce)
                    .ThenInclude(x => x.BookInfo)
                        .ThenInclude(x => x.Authors)
                .ToList();

            return history;
        }

        public Task<RecordEntity> GetRecordById(int recordId)
        {
            return _libraryContext.Records
                .FirstOrDefaultAsync(r => r.Id == recordId);
        }

        public async Task<bool> SaveRecord(RecordEntity record)
        {
            _libraryContext.Records.Add(record);
            await _libraryContext.SaveChangesAsync();
            return record.Id > 0;
        }
    }
}
