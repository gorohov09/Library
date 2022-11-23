﻿using Library.Application.Interfaces;
using Library.Application.Requests;
using Library.Application.Response;
using Library.DAL.Interfaces;

namespace Library.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IReaderRepository _readerRepository;

        private readonly IBookRepository _bookRepository;

        private readonly ILibrarianRepository _librarianRepository;

        public OrderService(IReaderRepository readerRepository, IBookRepository bookRepository, ILibrarianRepository librarianRepository)
        {
            _readerRepository = readerRepository;
            _bookRepository = bookRepository;
            _librarianRepository = librarianRepository;
        }
        public async Task<ResponseOrder> CreateOrder(RequestOrder requestOrder)
        {
            if (requestOrder == null)
                return new ResponseOrder { IsSuccess = false, ErrorMessage = "Неизвестная ошибка" };

            var readerEntity = await _readerRepository.GetReaderByLibraryCard(requestOrder.LibraryCard);

            //Если читатель не найден, то заявка не может быть оформлена
            if (readerEntity == null)
                return new ResponseOrder 
                { 
                    IsSuccess = false, 
                    ErrorMessage = $"Пользователь с номером чит. билета {requestOrder.LibraryCard} не найден" 
                };

            var bookInstanceEnity = await _bookRepository.GetFirstInsatnceBook(requestOrder.BookISBN);

            //Если экземпляра книги не существует в библиотеке, то заявка не может быть оформлена
            if (bookInstanceEnity == null)
                return new ResponseOrder
                {
                    IsSuccess = false,
                    ErrorMessage = $"Экземпляр книги с ISBN {requestOrder.BookISBN} не найден"
                };


            //Ищем первого библиотекаря(Реализовать репозиторий для библиотекаря)
            //Если библиотекаря нет - заявка не может быть сформирована
            var librarianEntity = await _librarianRepository.GetFirstLibrarian();
            if (librarianEntity == null)
                return new ResponseOrder
                {
                    IsSuccess = false,
                    ErrorMessage = "Библиотекарей нет"
                };

            // заглушка для избегания ошибок
            return null;
         
        }
    }
}
