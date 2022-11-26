﻿using Library.DAL.Context;
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
                        .ThenInclude(x => x.Authors)
                .ToList();

            return history;
        }

        public async Task<bool> SaveRecord(RecordEntity record)
        {
            _libraryContext.Records.Add(record);
            await _libraryContext.SaveChangesAsync();
            return record.Id > 0;
        }
    }
}
