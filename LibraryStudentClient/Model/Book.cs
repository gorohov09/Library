using LibraryStudentClient.View;
using LibraryStudentClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibraryStudentClient.Model
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string Year { get; set; }
        public string Section { get; set; }
        public string Authors { get; set; }
        public string Count { get; set; }

        private RelayCommand? getBook;
        public RelayCommand GetBook
        {
            get
            {
                return getBook ??
                    (getBook = new RelayCommand(obj =>
                    {
                        MainWindow._mng.GetBook();
                    },
                    (obj) => (MainWindow._mng.Tempbook?.Count != "0")
                    ));
            }
        }
    }
}
