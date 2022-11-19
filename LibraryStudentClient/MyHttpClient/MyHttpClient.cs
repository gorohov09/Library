using LibraryStudentClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static List<Section> GetAllSection()
        {
            return new List<Section>{
                new Section { Name = "Физика" },
                new Section { Name = "Термодинамика" },
                new Section { Name = "Аэродинамика" },
                new Section { Name = "Математический анализ" },
                new Section { Name = "Программирование" },
            };
        }

        public static List<Book> GetBooks(string section = "all")
        {

            // делаем запрос к серверу
            // десерализуем данные

            return new List<Book>{
                new Book {Title = "Война и мир", Publisher="Альпина", Year="2005", Section= "Русская классика", Authors="Толстой Л.Н"},
                new Book { Title = "Евгений Онегин", Publisher = "Альпина", Section = "Русская классика", Authors = "Пушкин А.С." },
                new Book { Title = "Тестовая", Publisher = "ЧекЧекович", Section = "Русская тестировка", Authors = "Горохов А.С., Исхаков А.И., Калеев Д.А," }
            };
        }
    }
}
