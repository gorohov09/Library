using LibraryStudentClient.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace LibraryStudentClient.ViewModel
{
    public class DataManagerMainVM : INotifyPropertyChanged
    {
        #region Работа с Секциями

        private List<Section> allSections = MyHttpClient.MyHttpClient.GetAllSection();
        public List<Section> AllSections 
        {
            get { return allSections; }
            set
            {
                allSections = value;
                NotifyPropertyChanged("AllSections");
            }

        }

        private Section? selectedSection;
        public Section? SelectedSection
        {
            get { return selectedSection; }
            set { selectedSection = value; NotifyPropertyChanged("SelectedSection"); }
        }

        #endregion

        #region Работа с книгами

        private List<Book> books = MyHttpClient.MyHttpClient.GetBooks();
        public List<Book> Books
        {
            get { return books; }
            set
            {
                books = value;
                //NotifyPropertyChanged("Books");
            }
        }

        private Book? selectedBook;
        public Book? SelectedBook
        {
            get { return selectedBook; }
            set { selectedBook = value; NotifyPropertyChanged("SelectedBook"); }
        }

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

        #endregion

        #region Конструктор класса

        public static DataManagerMainVM? currentDM;
        public DataManagerMainVM()
        {
            currentDM = this;
        }

        #endregion

        public void Show()
        {
            MessageBox.Show(SelectedSection.Name);
            SelectedSection = null;
        }
        public void ShowBook()
        {
            MessageBox.Show(SelectedBook.Title);
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
