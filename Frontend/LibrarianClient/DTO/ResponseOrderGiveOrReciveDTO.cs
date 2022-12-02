using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianClient.DTO
{
    public class ResponseOrderGiveOrReciveDTO
    {
        public bool IsSuccess { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
