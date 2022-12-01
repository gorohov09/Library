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
        private static string? currentLibrarianID;

        #region АВТОРИЗАЦИЯ
        public static bool Authorizate(string login, string password, ref string error)
        {
            // делаем запрос к серверу
            // десерализуем данные

            // в случае успеха 
            // сохраняем номер читательского билета

            // иначе заносим в error строку ошибки
            // и возвращаем false

            //try
            //{
            //    HttpClient Client = new HttpClient();

            //    var request = new RequestLoginDTO
            //    {
            //        Login = login,
            //        Password = password
            //    };

            //    var response = Client.PostAsJsonAsync("http://localhost:5162/api/account/logIn", request)
            //        .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<ResponseLoginDTO>().Result;

            //    if (response.IsSuccess)
            //    {
            //        currentLibrarianID = response.LibrarianID;
            //        return true;
            //    }


            //    error = response.Error;
            //    return false;

            //}
            //catch (Exception)
            //{
            //    error = "Ошибка при запросе - неполадка с сетью(";
            //    return false;
            //}


            if (login == "admin" && password == "admin")
            {
                currentLibrarianID = "1";
                return true;
            }
            else
            {
                error = "Неверный логин или пароль";
                return false;
            }

        }

        #endregion

        #region Работа с Заявками
        public static List<Order> GetOrders(string type)
        {
            //HttpClient Client = new HttpClient();

            //var response = Client.GetAsync($"http://localhost:5162/api/Reader/{currentLibraryCard}/orders");

            //var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<OrderListDTO>().Result;

            //var orders = result.orders.Select(x => new Order
            //{
            //    Title = x.BookName,
            //    Authors = x.Authors,
            //    Publisher = x.BookPublisher,
            //    Year = x.BookYear,
            //    DateOfCreate = x.CreationDate,
            //    Status = x.Status,

            //}).ToList();

            List<Order> orders = new List<Order>();

            orders = new List<Order>
            {
                new Order
                {
                    Id = 0,
                    LibraryCard = "505405",
                    FullName = "Check Checkovich Checkk",
                    Title = "Евгений Онегин",
                    DateOfCreation = "30.11.2022",
                    RowNumber = 15,
                    Year = "2005",
                    Publisher = "Альпина",
                    Authors = "А.С. Пушкин"
                },
                new Order
                {
                    Id = 0,
                    LibraryCard = "505405",
                    FullName = "Check Checkovich Checkk",
                    Title = "Война и мир",
                    DateOfCreation = "30.11.2022",
                    RowNumber = 15,
                    Year = "2005",
                    Publisher = "Альпина",
                    Authors = "А.С. Пушкин"
                },
                new Order
                {
                    Id = 0,
                    LibraryCard = "505405",
                    FullName = "Check Checkovich Checkk",
                    Title = "Война и мир",
                    DateOfCreation = "30.11.2022",
                    RowNumber = 15,
                    Year = "2005",
                    Publisher = "Альпина",
                    Authors = "А.С. Пушкин"
                },
                new Order
                {
                    Id = 0,
                    LibraryCard = "505405",
                    FullName = "Check Checkovich Checkk",
                    Title = "Война и мир",
                    DateOfCreation = "30.11.2022",
                    RowNumber = 15,
                    Year = "2005",
                    Publisher = "Альпина",
                    Authors = "А.С. Пушкин"
                },
                new Order
                {
                    Id = 0,
                    LibraryCard = "505405",
                    FullName = "Check Checkovich Checkk",
                    Title = "Евгений Онегин",
                    DateOfCreation = "30.11.2022",
                    RowNumber = 15,
                    Year = "2005",
                    Publisher = "Альпина",
                    Authors = "А.С. Пушкин"
                }
            };




            return orders;
        }

        #endregion

        #region Добавление нового читателя
    
        public static bool AddNewLibrarian(string name, string surname, string patronymic, string mobilephone, string login, string password, ref string error)
        {
            return true;
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


        #region Личный кабинет



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
                }
                history.Add(temp);
            }
            return history;
        }

        #endregion
    }
}
