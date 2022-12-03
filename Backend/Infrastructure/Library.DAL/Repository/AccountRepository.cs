using Library.DAL.Context;
using Library.DAL.Interfaces;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly LibraryContext _libraryContext;

        public AccountRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<ReaderEntity> Login(string studentCard, string password)
        {
            var readerEntity = await _libraryContext.Readers
                .FirstOrDefaultAsync(reader => reader.StudentCard == studentCard && reader.Password == password);

            return readerEntity;
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
                Password = password
            };

            _libraryContext.Readers.Add(readerEntity);

            return await _libraryContext.SaveChangesAsync() > 0 ? readerEntity : null;
        }
        
        public async Task<LibrarianEntity> LoginLibrarian(string login, string password)
        {
            var librarianEntity =
                await _libraryContext.Librarians.FirstOrDefaultAsync(lbr =>
                    lbr.Login == login && lbr.Password == password);

            return librarianEntity;
        }

        public async Task<LibrarianEntity> RegistrateLibrarian(string fullName, string mobilePhone,string login, string password)
        {
            var librarianEntity = new LibrarianEntity()
            {
                FullName = fullName,
                MobilePhone = mobilePhone,
                Login = login,
                Password = password
            };

            _libraryContext.Librarians.Add(librarianEntity);

            return await _libraryContext.SaveChangesAsync() > 0 ? librarianEntity : null;
        }
    }
}
