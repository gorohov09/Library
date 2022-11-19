using LibraryStudentClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryStudentClient.Model
{
    public class Section
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private RelayCommand? viewBooksFromSelectedSection;
        public RelayCommand ViewBooksFromSelectedSection
        {
            get
            {
                return viewBooksFromSelectedSection ??
                    (viewBooksFromSelectedSection = new RelayCommand(obj =>
                    {
                        DataManagerMainVM.currentDM.Show();
                    }));
            }
        }

    }
}
