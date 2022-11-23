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
                Authors = GetAuthors(result.Authors),
                Count = result.Count.ToString()               
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
    }
}
