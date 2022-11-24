using LibraryStudentClient.Model;
using LibraryStudentClient.View;
using LibraryStudentClient.View.BookPages;
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

        public void FindBooksBySection()
        {
            SelectedBook = null;
            Books = null;

            if (MainWindow._mainFrame.Content != MainWindow._listOfBooks)
            {
                MainWindow._mainFrame.Content = MainWindow._listOfBooks;
            }

            Books = MyHttpClient.MyHttpClient.GetBooks(SelectedSection.Name);
            SelectedSection = null;
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
            set { selectedBook = value; NotifyPropertyChanged("SelectedBook"); }
        }

        private Book? tempbook;
        public Book? Tempbook
        {
            get { return tempbook; }
            set { tempbook = value; NotifyPropertyChanged("Tempbook"); }
        }


        private RelayCommand? viewSelectedBook;
        public RelayCommand ViewSelectedBook
        {
            get
            {
                return viewSelectedBook ??
                    (viewSelectedBook = new RelayCommand(obj =>
                    {
                        tempbook = MyHttpClient.MyHttpClient.GetBookByISBN(selectedBook.ISBN);
                        tempbook.Authors = selectedBook.Authors;
                        ViewBookOnNewPage();
                    }));
            }
        }

        public void ViewBookOnNewPage()
        {
            MainWindow._mainFrame.Content = new BookDetails();
        }


        public void GetBook()
        {
            string message = MyHttpClient.MyHttpClient.CreateOrder(tempbook.ISBN);
            MessageBox.Show(message);
        }


        #endregion


        #region Кнопка "Главная"

        void ShowMain()
        {
            SelectedBook = null;
            Books = MyHttpClient.MyHttpClient.GetBooks();

            if (MainWindow._mainFrame.Content != MainWindow._listOfBooks)          
            { 
                MainWindow._mainFrame.Content = MainWindow._listOfBooks;
            }

        }

        private RelayCommand main;
        public RelayCommand Main
        {
            get
            {
                return goOut ?? new RelayCommand(obj =>
                {
                    ShowMain();
                }
                );
            }
        }


        #endregion

        #region Кнопка "Выйти"

        void Exit()
        {

            StartWindow startWindow = new StartWindow();
            startWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            startWindow.Show();
            MainWindow._window.Close();
        }

        private RelayCommand goOut;
        public RelayCommand GoOut
        {
            get
            {
                return goOut ?? new RelayCommand(obj =>
                {
                    Exit();
                    MainWindow._window.Close();
                }
                );
            }
        }

        #endregion

        #region Кнопка "Назад" в странице книги

        private RelayCommand? back;
        public RelayCommand Back
        {
            get
            {
                return back ??
                    (back = new RelayCommand(obj =>
                    {
                        SelectedSection = null;
                        returnToMainPage();
                    }));
            }
        }

        public void returnToMainPage()
        {
            MainWindow._mainFrame.Content = MainWindow._listOfBooks;
        }

        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
