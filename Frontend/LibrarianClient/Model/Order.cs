using LibrarianClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianClient.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string LibraryCard { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int RowNumber { get; set; }
        public string Year { get; set; }
        public string Publisher { get; set; }
        public string Authors { get; set; }


        private RelayCommand? approve;
        public RelayCommand Approve
        {
            get
            {
                return approve ??
                    (approve = new RelayCommand(obj =>
                    {
                        MainWindow._mng.Approve();
                    }));
            }
        }

        private RelayCommand? disApprove;
        public RelayCommand DisApprove
        {
            get
            {
                return disApprove ??
                    (disApprove = new RelayCommand(obj =>
                    {
                        MainWindow._mng.DisApprove();
                    }));
            }
        }
    }
}
