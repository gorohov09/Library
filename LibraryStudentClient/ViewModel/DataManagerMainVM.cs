using LibraryStudentClient.Model;
using LibraryStudentClient.View;
using LibraryStudentClient.View.BookPages;
using LibraryStudentClient.View.User;
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

        private string searchTitle;
        public string SearchTitle
        {
            get { return searchTitle; }
            set { searchTitle = value; NotifyPropertyChanged("SearchTitle"); }
        }


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
            RefreshDataAndAlertAboutIt();
        }

        #endregion

        #region Поиск книги

        private RelayCommand? search;
        public RelayCommand Search
        {
            get
            {
                return search ??
                    (search = new RelayCommand(obj =>
                    {
                        RefreshDataAndAlertAboutIt();
                        selectedBook = null; tempbook = null;
                        if (searchTitle != null)
                        {
                            if (MainWindow._mainFrame.Content != MainWindow._listOfBooks)
                            {
                                MainWindow._mainFrame.Content = MainWindow._listOfBooks;
                            }
                            Books = MyHttpClient.MyHttpClient.GetBooksByName(searchTitle);
                        }

                    }));
            }
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
                        if (selectedBook != null)
                        {
                            tempbook = MyHttpClient.MyHttpClient.GetBookByISBN(selectedBook.ISBN);
                            ViewBookOnNewPage();
                        }
                        RefreshDataAndAlertAboutIt();
                    }));
            }
        }

        public void ViewBookOnNewPage()
        {
            MainWindow._mainFrame.Content = new BookDetails();
        }


        public void GetBook()
        {
            string message = MyHttpClient.MyHttpClient.CreateOrder(tempbook.ISBN, "ПОЛУЧЕНИЕ");
            if (message == "Заяка успешно создана")
            {
                tempbook.Count = (int.Parse(tempbook.Count) - 1).ToString();
                ViewBookOnNewPage();
            }
            MessageBox.Show(message);
        }

        private RelayCommand? getBookCommand;
        public RelayCommand GetBookCommand
        {
            get
            {
                return getBookCommand ??
                    (getBookCommand = new RelayCommand(obj =>
                    {
                        if (selectedBook != null)
                        {
                            string message = MyHttpClient.MyHttpClient.CreateOrder(selectedBook.ISBN);
                            MessageBox.Show(message);
                        }
                        RefreshDataAndAlertAboutIt();

                    }));
            }
        }
        #endregion

        #region Мои заявки

        private List<Order> orderList;
        public List<Order> OrderList
        {
            get { return orderList; }
            set { orderList = value; NotifyPropertyChanged("OrderList"); }
        }



        private RelayCommand? openOrdersView;
        public RelayCommand OpenOrdersView
        {
            get
            {
                return openOrdersView ??
                    (openOrdersView = new RelayCommand(obj =>
                    {
                        RefreshDataAndAlertAboutIt();
                        ViewOrdersView();
                    }));
            }
        }


        public void ViewOrdersView()
        {
            MainWindow._mainFrame.Content = new Orders();
        }

        #endregion

        #region Личный кабинет

        private RelayCommand? openUserCabinet;
        public RelayCommand OpenUserCabinet
        {
            get
            {
                return openUserCabinet ??
                    (openUserCabinet = new RelayCommand(obj =>
                    {
                        RefreshDataAndAlertAboutIt();
                        MyHttpClient.MyHttpClient.GetDetailUSerInrofmation();
                        ViewUserCabinet();
                    }));
            }
        }


        public void ViewUserCabinet()
        {
            MainWindow._mainFrame.Content = new UserCabinet();
        }



        #endregion

        #region Кнопка "Главная"

        void ShowMain()
        {
            SelectedBook = null;
            SearchTitle = null;
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
                    RefreshDataAndAlertAboutIt();
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
                        RefreshDataAndAlertAboutIt();
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

        #region Самое сложное - оповещение читателя об изменении статуса заявки

        void RefreshDataAndAlertAboutIt()
        {
            var oldList = OrderList;
            OrderList = MyHttpClient.MyHttpClient.GetOrders();
            
            int iterator = 0;
            while (iterator != oldList.Count)
            {
                var item = oldList[iterator];
                var temp = OrderList.Find(p => p.Id == item.Id);
                if (temp.Status == item.Status && temp != null)
                {
                    oldList.Remove(item);
                }
                else
                {
                    iterator++;
                }
            }
            if (iterator != 0)
            {
                for (int i = 0; i < iterator; i++)
                {
                    var temp = OrderList.Find(p => p.Id == oldList[i].Id);
                    if (temp != null)
                    {
                        string resultString = $"Внимание ваша заявка #{temp.Id} на книгу {temp.Title}\nАвторов: {temp.Authors}\nИздателя: {temp.Publisher}\nГода: {temp.Year}\nот {temp.DateOfCreate}\nизменила свой статус на ";
                        if (temp.Status == "Выполнено")
                        {
                            resultString += "Выполнено\nПодойдите, пожалуйста, к библиотекарю, чтобы получить книгу.";
                        }
                        else if (temp.Status == "Отказано")
                        {
                            resultString += "Отказано\nБиблиотекарь отказал в выдаче Вам этой книги, вероятнее всего у вас есть долги.";
                        }
                        MessageBox.Show(resultString);
                    }
                }
            }
        }

        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
