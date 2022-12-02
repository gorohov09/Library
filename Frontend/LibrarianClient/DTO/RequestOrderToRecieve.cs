using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianClient.DTO
{
    public class RequestOrderToRecieve
    {
        public int OrderId { get; set; }
        public bool IsApproved { get; set; }
        public int LibrarianId { get; set; }
    }
}
