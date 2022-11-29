using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStudentClient.DTO
{
    public class ReaderDTO
    {
        public string LibraryCard { get; set; }
        public string FullName { get; set; }
        public DateTime? BirtYear { get; set; }
        public string StudentCard { get; set; }
        public bool IsHasDebt { get; set; }
        public string MobilePhone { get; set; }

        public List<HistoryDTO> History { get; set; } = new List<HistoryDTO>();

    }
}
