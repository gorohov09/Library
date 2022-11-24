using Library.Domain.Entities;

namespace Library.DAL.Interfaces
{
    public interface IRecordRepository
    {
        Task<IEnumerable<RecordEntity>> GetReadersHistory(string libraryCard);

        Task<IEnumerable<RecordEntity>> GetLibrarianHistory(int librarianId);
    }
}
