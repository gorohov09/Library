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

        private List<Section> allSections = await MyHttpClient.MyHttpClient.GetAllSection();
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

        private List<Book>? books = MyHttpClient.MyHttpClient.GetBooks();
        public List<Book>? Books
        {
            get { return books; }
            set
            {
                books = value;
                NotifyPropertyChanged("Books");
            }
        }

        private Book? selectedBook;
        public Book? SelectedBook
        {
            get { return selectedBook; }
            set { selectedBook = value; }
        }

        private RelayCommand? viewSelectedBook;
        public RelayCommand ViewSelectedBook
        {
            get
            {
                return viewSelectedBook ??
                    (viewSelectedBook = new RelayCommand(obj =>
                    {
                        ViewBookOnNewPage();
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

        public void FindBooksBySection()
        {
            Books = null;
            //Books = MyHttpClient.MyHttpClient.GetBooks(SelectedSection.Name);
            Books = new List<Book>{
                new Book {Title = "Война и мир", Publisher="Альпина", Year="2005", Section= "Русская классика", Authors="Толстой Л.Н"},
                new Book { Title = "Евгений Онегин", Publisher = "Альпина", Section = "Русская классика", Authors = "Пушкин А.С." },
                new Book { Title = "Тестовая", Publisher = "ЧекЧекович", Section = "Русская тестировка", Authors = "Горохов А.С., Исхаков А.И., Калеев Д.А," },
                new Book { Title = "Тестовая", Publisher = "ЧекЧекович", Section = "Русская тестировка", Authors = "Горохов А.С., Исхаков А.И., Калеев Д.А," }
            };
            SelectedSection = null;
        }
        public void ViewBookOnNewPage()
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
