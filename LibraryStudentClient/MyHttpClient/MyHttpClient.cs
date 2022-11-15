using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
