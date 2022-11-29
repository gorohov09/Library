using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStudentClient.DTO
{
    public class ReaderListDTO
    {
        public IEnumerable<ReaderDTO> Reader { get; set; } = new List<ReaderDTO>();
    }
}
