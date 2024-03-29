﻿using Library.Application.Interfaces;
using Library.Application.Requests;
using Library.Application.Response;
using Library.DAL.Interfaces;

namespace Library.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        private readonly IReaderRepository _readerRepository;

        private readonly ILibrarianRepository _librarianRepository;

        public AccountService(IAccountRepository accountRepository, IReaderRepository readerRepository,
            ILibrarianRepository librarianRepository)
        {
            _accountRepository = accountRepository;
            _readerRepository = readerRepository;
            _librarianRepository = librarianRepository;
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
            if (await _readerRepository.IsStudentCard(requestRegistrate.StudentCard))
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

        public async Task<ResponseLogin> Login(RequestLogin requestLogin)
        {
            if (requestLogin == null)
                return new ResponseLogin { IsSuccess = false, Error = "Неизвестная ошибка" };

            var readerEntity = await _accountRepository.Login(requestLogin.StudentCard, requestLogin.Password);

            if (readerEntity == null)
                return new ResponseLogin { IsSuccess = false, Error = "Неправильный читательский билет или пароль" };

            return new ResponseLogin { IsSuccess = true, LibraryCard = readerEntity.LibraryCard };
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
        
        public async Task<LibrarianResponseRegistrate> RegistrateLibrarian(LibrarianRequestRegistrate requestRegistrate)
        {
            if (requestRegistrate == null)
                return new LibrarianResponseRegistrate { IsSuccess = false, Error = "Неизвестная ошибка" };

            if (requestRegistrate.MobilePhone.Length != 11)
                return new LibrarianResponseRegistrate { IsSuccess = false, Error = "Телефонный номер должен содержать 11 цифр" };

            if (await _librarianRepository.IsLibrarianExists(requestRegistrate.Login))
                return new LibrarianResponseRegistrate { IsSuccess = false, Error = "Библиотекарь с таким логином уже существует" };
            
            var fullName = GetFullName(requestRegistrate.LastName, requestRegistrate.Name, requestRegistrate.Patronymic);

            try
            {
                var resultLibrarianEntity = await _accountRepository.RegistrateLibrarian(fullName,
                    requestRegistrate.MobilePhone,  requestRegistrate.Login, requestRegistrate.Password);

                if (resultLibrarianEntity == null)
                    return new LibrarianResponseRegistrate { IsSuccess = false, Error = "Ошибка при регистрации" };

                return new LibrarianResponseRegistrate { IsSuccess = true, Id = resultLibrarianEntity.Id };
            }
            catch (Exception)
            {
                return new LibrarianResponseRegistrate { IsSuccess = false, Error = "Ошибка при сохранении данных" };
            }
        }

        public async Task<LibrarianResponseLogin> LoginLibrarian(LibrarianRequestLogin requestLogin)
        {
            if (requestLogin == null)
                return new LibrarianResponseLogin { IsSuccess = false, Error = "Неизвестная ошибка" };

            var librarianEntity = await _accountRepository.LoginLibrarian(requestLogin.Login, requestLogin.Password);

            if (librarianEntity == null)
                return new LibrarianResponseLogin { IsSuccess = false, Error = "Неверный логин или пароль" };

            return new LibrarianResponseLogin { IsSuccess = true, Id =  librarianEntity.Id};
        }
    }
}
