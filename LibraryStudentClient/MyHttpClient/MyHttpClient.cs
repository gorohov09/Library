using LibraryStudentClient.DTO;
using LibraryStudentClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace LibraryStudentClient.MyHttpClient
{
    public static class MyHttpClient
    {
        private static string? currentLibraryCard;

        public static bool Authorizate(string studTicketNum, string password, ref string error)
        {
            // делаем запрос к серверу
            // десерализуем данные

            // в случае успеха 
            // сохраняем номер читательского билета

            // иначе заносим в error строку ошибки
            // и возвращаем false

            if (studTicketNum == "Check" && password == "777")
            {
                return true;
            }


            error = "ошибка - такого пользователя не существует! Перейдите в раздел \"регистрация\"";
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

            if (studTicketNum == "Check" && password == "777")
            {
                return true;
            }

            error = "ошибка - пользователь с таким студенческим билетом уже существует!\nСоветуем перейти в раздел \"авторизация\"";
            return false;
        }

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

            //return new List<Section>{
            //    new Section { Name = "Физика" },
            //    new Section { Name = "Термодинамика" },
            //    new Section { Name = "Аэродинамика" },
            //    new Section { Name = "Математический анализ" },
            //    new Section { Name = "Программирование" },

        }

        public static List<Book> GetBooks(string section = "all")
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5162/api/books?section={section}");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<BookDTO>>().Result;

            var books = result.Select(x => new Book
            {
                Title = x.Title,
                Publisher = x.Publisher,
                Year = x.Year,
                Section = x.Section,    
                Authors = GetAuthors(x.Authors)

            }).ToList();

            return books;


            // делаем запрос к серверу
            // десерализуем данные

            //return new List<Book>{
            //    new Book {Title = "Война и мир", Publisher="Альпина", Year="2005", Section= "Русская классика", Authors="Толстой Л.Н"},
            //    new Book { Title = "Евгений Онегин", Publisher = "Альпина", Section = "Русская классика", Authors = "Пушкин А.С." },
            //    new Book { Title = "Тестовая", Publisher = "ЧекЧекович", Section = "Русская тестировка", Authors = "Горохов А.С., Исхаков А.И., Калеев Д.А," }
            //};
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
    }
}
