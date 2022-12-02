using LibrarianClient.Model;
using LibrarianClient.View;
using LibrarianClient.View.AddNewLibrarian;
using LibrarianClient.View.Authorization;
using LibrarianClient.View.InformationAboutReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibrarianClient.ViewModel
{
    public class DataManagerMainVM : INotifyPropertyChanged
    {
        #region Работа с читателем

        #region Поиск читателя


        private string searchTitle = "";
        public string SearchTitle
        {
            get { return searchTitle; }
            set { searchTitle = value; NotifyPropertyChanged("SearchTitle"); }
        }


        private List<string> searchType = new List<string> { "ФИО", "чит. билет"};
        public List<string> SearchType
        {
            get { return searchType; }
        }


        private string selectedType;
        public string SelectedType
        {
            get { return selectedType; }
            set { selectedType = value; NotifyPropertyChanged("SelectedType"); }
        }


        private SearchReaderClass selectedSearchReader;
        public SearchReaderClass SelectedSearchReader
        {
            get { return selectedSearchReader; }
            set { selectedSearchReader = value; NotifyPropertyChanged("SelectedSearchReader"); }
        }


        private List<SearchReaderClass> searchReaderlst;
        public List<SearchReaderClass> SearchReaderlst
        {
            get { return searchReaderlst; }
            set { searchReaderlst = value; NotifyPropertyChanged("SearchReaderlst"); }
        }


        private RelayCommand search;
        public RelayCommand Search
        {
            get
            {
                return search ?? new RelayCommand(obj =>
                {
                    if (SearchTitle != "" && SearchTitle.Replace(" ", "").Length != 0)
                    {

                        MainWindow._mainFrame.Content = MainWindow._searchReaderView;
                        SearchReaderlst = MyHttpClient.MyHttpClient.GetReadersList(SearchTitle, SelectedType);
                    }
                }
                );
            }
        }



        #endregion

        #region Подробная информация о читателе

        public string ReaderName
        {
            get { return Reader.Name; }
        }
        public string ReaderSurName
        {
            get { return Reader.SurName; }
        }
        public string ReaderPatronimic
        {
            get { return Reader.Patronimic; }
        }
        public string ReaderLibraryCard
        {
            get { return Reader.LibraryCard; }
        }
        public string ReaderMobilePhone
        {
            get { return Reader.MobilePhone; }
        }
        public string ReaderStudCard
        {
            get { return Reader.StudCard; }
        }
        public List<History> ReaderHistoryList
        {
            get { return Reader.Histories; }
            set { Reader.Histories = value; NotifyPropertyChanged("HistoryList"); }
        }

        private RelayCommand viewInformationAboutReader;
        public RelayCommand ViewInformationAboutReader
        {
            get
            {
                return viewInformationAboutReader ?? new RelayCommand(obj =>
                {
                    if (SelectedOrder != null)
                    {
                        //MyHttpClient.MyHttpClient.GetDetailUSerInrofmation(SelectedOrder.LibraryCard);
                        MyHttpClient.MyHttpClient.GetDetailUSerInrofmation("505405");
                        ViewReaderDetailInformation();
                    }
                }
                );
            }
        }

        public void ViewReaderDetailInformation()
        {
            MainWindow._mainFrame.Content = new InFormationAboutReader();
        }


        private RelayCommand? viewInformationAboutReaderFromSearch;
        public RelayCommand ViewInformationAboutReaderFromSearch
        {
            get
            {
                return viewInformationAboutReaderFromSearch ??
                    (viewInformationAboutReaderFromSearch = new RelayCommand(obj =>
                    {
                        if (selectedSearchReader != null)
                        {
                            MyHttpClient.MyHttpClient.GetDetailUSerInrofmation(selectedSearchReader.LibraryCard);
                            MainWindow._mainFrame.Content = new InFormationAboutReader();
                        }
                    }));
            }
        }

        #endregion


        #endregion

        #region Заявки

        #region Отображение заявок


        private TabItem? selectedTabItem;
        public TabItem SelectedTabItem
        { 
            get { return selectedTabItem; }
            set { selectedTabItem = value; RefreshLists(); SelectedOrder = null; }
        }


        private List<Order> allOrdersToGive;
        public List<Order> AllOrdersToGive
        {
            get { return allOrdersToGive; }
            set { allOrdersToGive = value; NotifyPropertyChanged("AllOrdersToGive"); }
        }


        private List<Order> allOrdersToReturn;
        public List<Order> AllOrdersToReturn
        {
            get { return allOrdersToReturn; }
            set { allOrdersToReturn = value; NotifyPropertyChanged("AllOrdersToReturn"); }
        }

        private Order? selectedOrder;
        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set { selectedOrder = value; NotifyPropertyChanged("SelectedOrder"); }
        }



        public void RefreshLists()
        {
            AllOrdersToGive = MyHttpClient.MyHttpClient.GetOrders("recieve");
            AllOrdersToReturn = MyHttpClient.MyHttpClient.GetOrders("return");
        }


        #endregion

        public void Approve()
        {

        }

        public void DisApprove()
        {

        }

        #endregion

        #region Окно добавления нового библиотекаря

        private AddNewLibrarianWnd? newLibrarianWindow;

        private RelayCommand? openNewLibrarianWnd;
        public RelayCommand OpenNewLibrarianWnd
        {
            get
            {
                return openNewLibrarianWnd ?? new RelayCommand(obj =>
                {
                    OpeNewLibrarianWndMethod();
                });
            }
        }

        private void OpeNewLibrarianWndMethod()
        {
            Name = "";
            SurName = "";
            Patronimyc = "";
            MobilePhone = "";
            Login = "";
            Password = "";

            newLibrarianWindow = new AddNewLibrarianWnd();
            newLibrarianWindow.Owner = MainWindow._window;
            newLibrarianWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newLibrarianWindow.ShowDialog();

        }

        #region Свойства нового библиотекаря

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged("Name"); }
        }

        private string surName;
        public string SurName
        {
            get { return surName; }
            set { surName = value; NotifyPropertyChanged("SurName"); }
        }

        private string patronimyc;
        public string Patronimyc
        {
            get { return patronimyc; }
            set { patronimyc = value; NotifyPropertyChanged("Patronimyc"); }
        }

        private string mobilePhone;
        public string MobilePhone
        {
            get { return mobilePhone; }
            set { mobilePhone = value; NotifyPropertyChanged("MobilePhone"); }
        }

        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; NotifyPropertyChanged("Login"); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; NotifyPropertyChanged("Password"); }
        }

        #endregion 

        private string? errorlogadd;
        public string ErrorlogAdd
        {
            get { return errorlogadd; }
            set { errorlogadd = value; NotifyPropertyChanged("ErrorlogAdd"); }
        }

        private RelayCommand addNewLibrarian;
        public RelayCommand AddNewLibrarian
        {
            get
            {
                return addNewLibrarian ?? new RelayCommand(obj =>
                {
                    bool CanAdd = true;
                    if (Name == null || Name.Replace(" ", "").Length == 0) { SetBlockControl("NameBlock", false); CanAdd = false; }
                    else { SetBlockControl("NameBlock", true); }

                    if (SurName == null || SurName.Replace(" ", "").Length == 0) { SetBlockControl("SurNameBlock", false); CanAdd = false; }
                    else { SetBlockControl("SurNameBlock", true); }

                    if (Patronimyc == null || Patronimyc.Replace(" ", "").Length == 0) { SetBlockControl("PatronimycBlock", false); CanAdd = false; }
                    else { SetBlockControl("PatronimycBlock", true); }

                    if (MobilePhone == null || MobilePhone.Replace(" ", "").Length == 0) { SetBlockControl("MobilePhoneBlock", false); CanAdd = false; }
                    else { SetBlockControl("MobilePhoneBlock", true); }

                    if (Login == null || Login.Replace(" ", "").Length == 0) { SetBlockControl("LoginBlock", false); CanAdd = false; }
                    else { SetBlockControl("LoginBlock", true); }

                    if (Password == null || Password.Replace(" ", "").Length == 0) { SetBlockControl("PasswordBlock", false); CanAdd = false; }
                    else { SetBlockControl("PasswordBlock", true); }

                    if (CanAdd)
                    {
                        string error = "";
                        if (MyHttpClient.MyHttpClient.AddNewLibrarian(Name, SurName, Patronimyc, MobilePhone, Login, Password, ref error))
                        {
                            MessageBox.Show("Библиотекарь успешно добавлен.");

                            Name = "";
                            SurName = "";
                            Patronimyc = "";
                            MobilePhone = "";
                            Login = "";
                            Password = "";
                            newLibrarianWindow.Close();
                        }
                        else
                        {
                            ErrorlogAdd = error;
                        }
                    }

                });
            }
        }

        private void SetBlockControl(string blockName, bool condition)
        {
            Control block = newLibrarianWindow.FindName(blockName) as Control;
            if (condition) { block.BorderBrush = Brushes.White; }
            else { block.BorderBrush = Brushes.Red; }

        }

        #endregion

        #region Кнопка "Выйти"
        void Exit()
        {
            AutorizationWindow authorizationWindow = new AutorizationWindow();
            authorizationWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            authorizationWindow.Show();
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

        #region Кнопка "Главная"

        private RelayCommand main;
        public RelayCommand Main
        {
            get
            {
                return main ?? new RelayCommand(obj =>
                {
                    RefreshLists();
                    MainWindow._mainFrame.Content = MainWindow.orders;
                }
                );
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
