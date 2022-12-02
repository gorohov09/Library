using LibrarianClient.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Windows;
using System.Xml.Linq;
using LibrarianClient.Model;

namespace LibrarianClient.MyHttpClient
{
    public static class MyHttpClient
    {
        private static int currentLibrarianID;

        #region АВТОРИЗАЦИЯ
        public static bool Authorizate(string login, string password, ref string error)
        {
            // делаем запрос к серверу
            // десерализуем данные

            // в случае успеха 
            // сохраняем номер читательского билета

            // иначе заносим в error строку ошибки
            // и возвращаем false

            try
            {
                HttpClient Client = new HttpClient();

                var request = new RequestLoginDTO
                {
                    Login = login,
                    Password = password
                };

                var response = Client.PostAsJsonAsync("http://localhost:5162/api/account/logIn/librarian", request)
                    .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<ResponseLoginDTO>().Result;

                if (response.IsSuccess)
                {
                    currentLibrarianID = response.Id;
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

        #region Работа с Заявками
        
        /// <summary>
        /// Получение всех заявок по заданному типу
        /// </summary>
        /// <param name="type">Либо recieve - выдача книг. Либо return - возврат книг</param>
        /// <returns></returns>
        public static List<Order> GetOrders(string type)
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5162/api/Librarian/orders?typeOrders={type}");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<OrderListDTO>().Result;

            var orders = result.orders.Select(x => new Order
            {
                Id = x.Id,
                LibraryCard = x.ReaderId,
                FullName = x.ReaderFullName,
                Title = x.BookName,
                DateOfCreation = x.CreationDate,
                RowNumber = x.RowNumber,
                Year = x.BookYear,
                Publisher = x.BookPublisher,
                Authors = x.BookAuthors
            }).ToList();

            return orders;
        }

        public static bool OrderToRecieve(int orderID, bool isapproved, ref string error)
        {
            HttpClient Client = new HttpClient();

            var request = new RequestOrderToRecieve
            {
                OrderId = orderID,
                IsApproved = isapproved,
                LibrarianId = currentLibrarianID
            };

            var response = Client.PostAsJsonAsync("http://localhost:5162/api/orders/approve", request)
                .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<ResponseOrderGiveOrReciveDTO>().Result;

            if (response.IsSuccess)
            {
                return true;
            }

            error = response.ErrorMessage;
            return response.IsSuccess;
        }

        public static bool OrderToReturn(int orderID, ref string error)
        {
            HttpClient Client = new HttpClient();

            var request = new RequestOrderToRecieve
            {
                OrderId = orderID,
                IsApproved = true,
                LibrarianId = currentLibrarianID
            };

            var response = Client.PostAsJsonAsync("http://localhost:5162/api/orders/return", request)
                .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<ResponseOrderGiveOrReciveDTO>().Result;

            if (response.IsSuccess)
            {
                return true;
            }

            error = response.ErrorMessage;
            return response.IsSuccess;
        }

        #endregion

        #region Добавление нового библиотекаря

        public static bool AddNewLibrarian(string lastName, string name, string patronymic, string mobilephone, string login, string password, ref string error)
        {
            HttpClient Client = new HttpClient();

            var request = new RequestRegistrateDTO
            {
                LastName = lastName
                ,
                Name = name
                ,
                Patronymic = patronymic
                ,
                MobilePhone = mobilephone
                ,
                Login = login
                ,
                Password = password
            };

            var response = Client.PostAsJsonAsync("http://localhost:5162/api/account/registrate/librarian", request)
                .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<ResponseLoginDTO>().Result;

            if (response.IsSuccess)
            {
                return true;
            }


            error = response.Error;
            return false;
        }

        #endregion

        #region Немного методов работы с книгами
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

        #region Поиск читателя

        public static List<SearchReaderClass> GetReadersList(string searchstr, string howSearch)
        {
            HttpClient Client = new HttpClient();
            Task<HttpResponseMessage>? response = null;

            if (howSearch == "ФИО")
            {
                response = Client.GetAsync($"http://localhost:5162/api/Reader/search/byname?template={searchstr}");
            }
            else
            {
                response = Client.GetAsync($"http://localhost:5162/api/Reader/search/bycard?template={searchstr}");
            }

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<SearchReaderDTO>().Result;

            return result.Readers;

        }

        #endregion

        #region Подробная информация о читателе

        public static void GetDetailUSerInrofmation(string LibraryCard)
        {

            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5162/api/Reader/{LibraryCard}");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<ReaderListDTO>().Result;

            var answer = result.Reader;

            Reader.LibraryCard = answer.LibraryCard;
            Reader.StudCard = answer.StudentCard;
            Reader.SurName = answer.FullName.Split()[0];
            Reader.Name = answer.FullName.Split()[1];
            Reader.Patronimic = answer.FullName.Split()[2];
            Reader.MobilePhone = answer.MobilePhone;
            Reader.Histories = GetHistory(answer.History);

        }

        private static List<History> GetHistory(List<HistoryDTO> histories)
        {
            List<History> history = new List<History>();
            foreach (var record in histories)
            {
                History temp = new History();
                temp.ID = record.Id;
                temp.BookName = record.BookName;
                temp.BookPublisher = record.BookPublisher;
                temp.BookYear = record.BookYear;
                temp.Authors = GetAuthors(record.BookAuthors);
                temp.IssueDate = DateTime.Parse(record.IssueDate).ToShortDateString();
                if (record.ReturnDate != null)
                {
                    temp.ReturnDate = DateTime.Parse(record.ReturnDate).ToShortDateString();
                    if (temp.ReturnDate == "01.01.1970")
                    {
                        temp.ReturnDate = "";
                    }
                }
                history.Add(temp);
            }
            return history;
        }

        #endregion
    }
}
