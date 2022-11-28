using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStudentClient.DTO
{
    public class ResponseOrderDTO
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }
    }
}
