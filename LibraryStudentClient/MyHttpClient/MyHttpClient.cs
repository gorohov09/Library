using LibraryStudentClient.DTO;
using LibraryStudentClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Xml.Linq;

namespace LibraryStudentClient.MyHttpClient
{
    public static class MyHttpClient
    {
        private static string? currentLibraryCard;

        #region АВТОРИЗАЦИЯ

        public static bool Authorizate(string studTicketNum, string password, ref string error)
        {
            // делаем запрос к серверу
            // десерализуем данные

            // в случае успеха 
            // сохраняем номер читательского билета

            // иначе заносим в error строку ошибки
            // и возвращаем false

            HttpClient Client = new HttpClient();

            var request = new RequestLoginDTO
            {
                Password = password,
                StudentCard = studTicketNum
            };

            var response = Client.PostAsJsonAsync("http://localhost:5162/api/account/logIn", request)
                .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<ResponseLoginDTO>().Result;

            if (response.IsSuccess)
            {
                currentLibraryCard = response.LibraryCard;
                return true;
            }


            error = response.Error;
            return false;
        }

        public static bool Registrate(string studTicketNum, string password, string name, string surname, string fatherName, string phoneNumber,  ref string error)
        {
            // делаем запрос к серверу
            // десерализуем данные

            // в случае успеха 
            // сохраняем номер читательского билета

            // иначе заносим в error строку ошибки
            // и возвращаем false
            

            HttpClient Client = new HttpClient();

            var request = new RequestRegistrateDTO
            {
                LastName = surname,
                Name = name,
                Patronymic = fatherName,
                MobilePhone = phoneNumber,
                StudentCard = studTicketNum,
                Password = password
            };

            try
            {
                var response = Client.PostAsJsonAsync("http://localhost:5162/api/account/registrate", request)
                .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<ResponseLoginDTO>().Result;

                if (response.IsSuccess)
                {
                    currentLibraryCard = response.LibraryCard;
                    return true;
                }
                error = response.Error;
                return false;
            }
            catch (Exception)
            {

                error = "Ошибка при запросе - неполадка с сетью(";
                return false;
            }
        }

        #endregion

        #region Работа с книгами
        static public List<Section> GetAllSection()
        {
            HttpClient Client = new HttpClient();

            //Отправляем запрос
            var response = Client.GetAsync("http://localhost:5162/api/books/sections/all");

            //Десериализуем в DTO-модель(смотри папку DTO)
            //DTO - Data Transfer Object, служит для передачи или приема данных с бэка
            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<SectionsDTO>().Result;

            //Приводим к нужному нам типу
            var sections = result.Sections.Select(x => new Section
            {
                Name = x
            }).ToList();

            //Возвращаем результат
            return sections;
        }

        public static Book GetBookByISBN(string ISBN)
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5162/api/books/{ISBN}");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<BookDetailDTO>().Result;

            var book = new Book()
            {
                ISBN = result.ISBN,
                Title = result.Title,
                Description = result.Description,
                Publisher = result.Publisher,
                Year = result.Year,
                Section = result.Section,
                Count = result.Count.ToString(),
                Authors = GetAuthors(result.Authors)
            };

            return book;
        }

        public static List<Book> GetBooks(string section = "all")
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5162/api/books?section={section}");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<BookDTO>>().Result;

            var books = result.Select(x => new Book
            {
                ISBN = x.ISBN,
                Title = x.Title,
                Publisher = x.Publisher,
                Year = x.Year,
                Section = x.Section,    
                Authors = GetAuthors(x.Authors)

            }).ToList();

            return books;
        }

        private static string GetAuthors(IEnumerable<AuthorDTO> authors)
        {
            var result = new StringBuilder();
            foreach (var author in authors)
            {
                result.Append($"{author.FullName} ");
            }

            return result.ToString();
        }

        #endregion

        #region Работа с заявками

        public static string CreateOrder(string ISBN, string typeOrder, int bookInstanceId = -1)
        {
            HttpClient Client = new HttpClient();

            var request = new RequestOrderDTO()
            {
                LibraryCard = currentLibraryCard,
                BookISBN = ISBN,
                TypeOrder = typeOrder,
                BookInstanceId = bookInstanceId,
            };

            var response = Client.PostAsJsonAsync("http://localhost:5162/api/orders/create", request)
            .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<ResponseOrderDTO>().Result;

            if (response.IsSuccess)
            {
                return "Заяка успешно создана";
            }
            return response.ErrorMessage;
        }

        public static List<Order> GetOrders()
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5162/api/Reader/{currentLibraryCard}/orders");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<OrderListDTO>().Result;

            var orders = result.orders.Select(x => new Order
            {
                Title = x.BookName,
                Authors = x.Authors,
                Publisher = x.BookPublisher,
                Year = x.BookYear,
                DateOfCreate = x.CreationDate,
                Status = x.Status,

            }).ToList();



            return orders;
        }

        #endregion

        #region Личный кабинет

        public static void GetDetailUSerInrofmation()
        {

            //HttpClient Client = new HttpClient();

            //var response = Client.GetAsync($"http://localhost:5162/api/Reader/{currentLibraryCard}");

            //var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<ReaderListDTO>().Result;

            //var orders = result.ReaderDTO.Select(x => new ReaderDTO
            //{
            //    LibraryCard = x.LibraryCard,
            //    FullName = x.FullName,
            //    StudentCard = x.StudentCard,
            //    IsHasDebt = x.IsHasDebt,
            //    MobilePhone = x.MobilePhone,
            //    History = x.History,

            //}).ToList();

            //Reader.LibraryCard = orders[0]. ;
            //Reader.StudCard = x.StudentCard;
            //Reader.MobilePhone = x.MobilePhone;


            Reader.LibraryCard = currentLibraryCard;
            Reader.SurName = "Калеев";
            Reader.Name = "Данил";
            Reader.Patronimic = "Андреевич";
            Reader.StudCard = "141418";
            Reader.MobilePhone = "89520406725";
            Reader.Histories = new List<History> {
                new History { ID = "8", BookName = "Тестировка",                IssueDate = "31.10.2022", ReturnDate = null  },
                new History { ID = "7", BookName = "Физика",                    IssueDate = "31.10.2022", ReturnDate = null  },
                new History { ID = "6", BookName = "Программирование на C#",    IssueDate = "25.09.2022", ReturnDate = null },
                new History { ID = "5", BookName = "Капитанская дочка",         IssueDate = "15.09.2022", ReturnDate = null  },
                new History { ID = "3", BookName = "Есть ли смысл",             IssueDate = "8.10.2022",  ReturnDate = null  },
                new History { ID = "2", BookName = "В осмысленности?",          IssueDate = "5.09.2022",  ReturnDate = null  },
                new History { ID = "4", BookName = "Граф Монте-Кристо",         IssueDate = "15.10.2022", ReturnDate = "25.10.2022"  },
                new History { ID = "1", BookName = "Война и мир",               IssueDate = "15.10.2022", ReturnDate = "25.10.2022"  },
                new History { ID = "4", BookName = "Фантазия кончилась",        IssueDate = "5.10.2022",  ReturnDate = "18.10.2022"  },
                new History { ID = "1", BookName = "Но главное даты",           IssueDate = "24.09.2022", ReturnDate = "18.10.2022"  },
                new History { ID = "1", BookName = "Смотрите на них",           IssueDate = "22.09.2022", ReturnDate = "25.10.2022"  }
                };
            
        }

        #endregion

    }
}
