using LibrarianClient.Model;
using LibrarianClient.View;
using LibrarianClient.View.Authorization;
using System.ComponentModel;
using System.Windows;

namespace LibrarianClient.ViewModel
{
    public class DataManagerAuthorizationVM : INotifyPropertyChanged
    {
        private string? login;
        public string Login
        {
            get { return login; }
            set { login = value; NotifyPropertyChanged("Login"); }
        }

        private string? password;
        public string Password
        {
            get { return password; }
            set { password = value; NotifyPropertyChanged("Password"); }
        }

        private string? errorlog;
        public string Errorlog
        {
            get { return errorlog; }
            set { errorlog = value; NotifyPropertyChanged("Errorlog"); }
        }

        private RelayCommand authorization;
        public RelayCommand Authorization
        {
            get
            {
                return authorization ?? new RelayCommand(obj =>
                {
                    if (login != null && password != null)
                    {
                        string? error = null;

                        if (MyHttpClient.MyHttpClient.Authorizate(login, password, ref error))
                        {
                            OpenMainWindow(); return;
                        }
                        else
                        {
                            Errorlog = error;
                        }
                    }
                }
                );
            }
        }

        private void OpenMainWindow()
        {

            MainWindow mainWindow = new MainWindow();
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainWindow.Show();
            AutorizationWindow._window.Close();

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
