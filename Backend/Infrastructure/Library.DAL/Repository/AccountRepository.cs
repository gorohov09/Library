using Library.DAL.Context;
using Library.DAL.Interfaces;
using Library.Domain.Entities;

namespace Library.DAL.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly LibraryContext _libraryContext;

        public AccountRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<ReaderEntity> Registrate(string libraryCard, string fullName, 
            string studentCard, string mobilePhone, string password)
        {
            var readerEntity = new ReaderEntity
            {
                LibraryCard = libraryCard,
                FullName = fullName,
                StudentCard = studentCard,
                MobilePhone = mobilePhone,
                IsHasDebt = false,
                Password = password
            };

            _libraryContext.Readers.Add(readerEntity);

            return await _libraryContext.SaveChangesAsync() > 0 ? readerEntity : null;
        }
    }
}
