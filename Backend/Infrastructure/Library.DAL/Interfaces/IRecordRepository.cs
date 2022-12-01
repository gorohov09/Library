using Library.Domain.Entities;

namespace Library.DAL.Interfaces
{
    public interface IRecordRepository
    {
        Task<IEnumerable<RecordEntity>> GetReadersHistory(string libraryCard);

        Task<bool> SaveRecord(RecordEntity record);

        Task<RecordEntity> GetFreeRecord(int bookInstanceId);
    }
}
