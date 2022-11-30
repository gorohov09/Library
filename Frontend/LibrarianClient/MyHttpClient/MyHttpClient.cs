using LibrarianClient.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianClient.MyHttpClient
{
    public class MyHttpClient
    {
        private static string? currentLibrarianID;

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

                var response = Client.PostAsJsonAsync("http://localhost:5162/api/account/logIn", request)
                    .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<ResponseLoginDTO>().Result;

                if (response.IsSuccess)
                {
                    currentLibrarianID = response.LibrarianID;
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
    }
}
