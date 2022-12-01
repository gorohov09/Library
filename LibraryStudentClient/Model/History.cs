using LibraryStudentClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryStudentClient.Model
{
    public class History
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public string BookPublisher { get; set; }
        public string BookYear { get; set; }
        public string Authors { get; set; }
        public string IssueDate { get; set; }
        public string ReturnDate { get; set; }

        public bool HasOrderToReturn { get; set; } = false;

        private RelayCommand? returnbook;
        public RelayCommand Returnbook
        {
            get
            {
                return returnbook ??
                    (returnbook = new RelayCommand(obj =>
                    {
                        string message = MyHttpClient.MyHttpClient.CreateOrder(null, this.ID);
                        if (message == "Заяка успешно создана")
                        {
                            HasOrderToReturn = true;
                        }
                        MessageBox.Show(message);
                    },
                    (obj) => (ReturnDate is null && !HasOrderToReturn)
                    ));
            }
        }


    }
}
