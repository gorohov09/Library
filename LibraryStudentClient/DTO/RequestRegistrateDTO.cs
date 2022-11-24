using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStudentClient.DTO
{
    public class RequestRegistrateDTO
    {
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string MobilePhone { get; set; }
        public string StudentCard { get; set; }
        public string Password { get; set; }
    }
}
