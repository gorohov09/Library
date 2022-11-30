using LibrarianClient.Model;
using LibrarianClient.View;
using LibrarianClient.View.AddNewLibrarian;
using LibrarianClient.View.Authorization;
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
        #region Поиск читателя

        private List<string> searchType = new List<string> { "чит. билет", "ФИО",};
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

        #endregion



        #region Окно добавления нового библиотекаря

        private AddNewLibrarianWnd newLibrarianWindow;

        private RelayCommand openNewLibrarianWnd;
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
            newLibrarianWindow.Owner = Application.Current.MainWindow;
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

        public bool AddNewLibrarianMethod()
        {
            return false;
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

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
