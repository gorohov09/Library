using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStudentClient.Model
{
    public class Order
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Authors { get; set; }
        public string Publisher { get; set; }
        public string Year { get; set; }
        public DateTime DateOfCreate { get; set; }
        public string Status { get; set; }  

    }
}
