using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianClient.Model
{
    public static class Reader
    {

        public static string Name { get; set; }
        public static string SurName { get; set; }
        public static string Patronimic { get; set; }
        public static string MobilePhone { get; set; }
        public static string LibraryCard { get; set; }
        public static string StudCard { get; set; }
        public static List<History> Histories { get; set; }


    }
}
