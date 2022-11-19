using LibraryStudentClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        private RelayCommand? viewSelectedBook;
        public RelayCommand ViewSelectedBook
        {
            get
            {
                return viewSelectedBook ??
                    (viewSelectedBook = new RelayCommand(obj =>
                    {
                        DataManagerMainVM.currentDM.ShowBook();
                    }));
            }
        }

    }
}
