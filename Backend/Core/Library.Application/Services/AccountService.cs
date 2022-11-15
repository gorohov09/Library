using Library.Application.Interfaces;
using Library.Application.Requests;
using Library.Application.Response;
using Library.DAL.Interfaces;

namespace Library.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<ResponseRegistrate> Registrate(RequestRegistrate requestRegistrate)
        {
            if (requestRegistrate == null)
                return new ResponseRegistrate { IsSuccess = false, Error = "Неизвестная ошибка" };

            var fullName = GetFullName(requestRegistrate.LastName, requestRegistrate.Name, requestRegistrate.Patronymic);

            var libraryCard = GenerateUniqueLibraryCard();

            //Сделать проверку, что сгенерированный номер чит. билета уникальный

            //Сделать проеверку, что такой номер студ. билета еще не был зарегестрирован

            var resultReaderEntity = await _accountRepository.Registrate(libraryCard, fullName,
                requestRegistrate.StudentCard, requestRegistrate.MobilePhone, requestRegistrate.Password);

            if (resultReaderEntity == null)
                return new ResponseRegistrate { IsSuccess = false, Error = "Ошибка при регистрации" };

            return new ResponseRegistrate { IsSuccess = true, LibraryCard = resultReaderEntity.LibraryCard };
        }

        private string GetFullName(string lastName, string name, string patronymic)
        {
            return $"{lastName} {name} {patronymic}";
        }

        private string GenerateUniqueLibraryCard()
        {
            Random generator = new Random();
            return generator.Next(100000, 1000000).ToString();
        }
    }
}
