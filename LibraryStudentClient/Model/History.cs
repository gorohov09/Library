using LibraryStudentClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStudentClient.Model
{
    public class History
    {
        public string ID { get; set; }
        public string BookName { get; set; }
        public string IssueDate { get; set; }
        public string? ReturnDate { get; set; }

        private RelayCommand? returnbook;
        public RelayCommand Returnbook
        {
            get
            {
                return returnbook ??
                    (returnbook = new RelayCommand(obj =>
                    {
                        MainWindow._reader.SelectedRecord = this;
                        MainWindow._reader.ReturnBook();
                    },
                    (obj) => (ReturnDate is null)
                    ));
            }
        }


    }
}
