using Library.Application.Interfaces;
using Library.Application.Requests;
using Library.Application.Response;
using Library.DAL.Interfaces;

namespace Library.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        private readonly IReaderRepository _readerRepository;

        public AccountService(IAccountRepository accountRepository, IReaderRepository readerRepository)
        {
            _accountRepository = accountRepository;
            _readerRepository = readerRepository;
        }

        public async Task<ResponseRegistrate> Registrate(RequestRegistrate requestRegistrate)
        {
            if (requestRegistrate == null)
                return new ResponseRegistrate { IsSuccess = false, Error = "Неизвестная ошибка" };

            if (requestRegistrate.MobilePhone.Length != 11)
                return new ResponseRegistrate { IsSuccess = false, Error = "Телефонный номер должен содержать 11 цифр" };

            if (requestRegistrate.StudentCard.Length != 6)
                return new ResponseRegistrate { IsSuccess = false, Error = "Студенческий билет должен содержать 6 символов" };

            //Сделать проеверку, что такой номер студ. билета еще не был зарегестрирован
            if (!(await _readerRepository.IsStudentCard(requestRegistrate.StudentCard)))
                return new ResponseRegistrate { IsSuccess = false, Error = "Пользователь с данным студ. билетом уже зарегестрирован" };
            
            var fullName = GetFullName(requestRegistrate.LastName, requestRegistrate.Name, requestRegistrate.Patronymic);
            var libraryCard = GenerateUniqueLibraryCard();

            //Проверка, что сгенерированный номер чит. билета уникальный
            while (await _readerRepository.IsLibraryCard(libraryCard))
                libraryCard = GenerateUniqueLibraryCard();

            try
            {
                var resultReaderEntity = await _accountRepository.Registrate(libraryCard, fullName,
                    requestRegistrate.StudentCard, requestRegistrate.MobilePhone, requestRegistrate.Password);

                if (resultReaderEntity == null)
                    return new ResponseRegistrate { IsSuccess = false, Error = "Ошибка при регистрации" };

                return new ResponseRegistrate { IsSuccess = true, LibraryCard = resultReaderEntity.LibraryCard };
            }
            catch (Exception)
            {
                return new ResponseRegistrate { IsSuccess = false, Error = "Ошибка при сохранении данных" };
            }
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
