using LibraryStudentClient.Model;
using LibraryStudentClient.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.CompilerServices;
using LibraryStudentClient.MyHttpClient;

namespace LibraryStudentClient.ViewModel
{
    public class DataManagerAuthorizationVM : INotifyPropertyChanged
    {
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? FatherName { get; set; }
        public string? PhoneNumber { get; set; }

        private string? studTicketNum;
        public string StudTicketNum 
        {
            get { return studTicketNum; }
            set { studTicketNum = value; NotifyPropertyChanged("StudTicketNum"); }
        }
        private string? password;
        public string Password 
        { 
            get { return password; } 
            set { password = value; NotifyPropertyChanged("Password"); }
        }

        private void OpenMainWindow()
        {

            MainWindow mainWindow = new MainWindow();
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainWindow.Show();
            StartWindow._window.Close();

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
                    if (studTicketNum != null && password != null)
                    {
                        string? error = null;

                        if (MyHttpClient.MyHttpClient.Authorizate(studTicketNum, password, ref error))
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

        private RelayCommand registration;
        public RelayCommand Registration
        {
            get
            {
                return registration ?? new RelayCommand(obj =>
                {
                    if (studTicketNum == null || password == null || Name == null || SurName == null || FatherName == null || PhoneNumber == null)
                    {
                        Errorlog = "Вы не ввели все данные!";
                    }
                    else
                    {
                        string? error = null;

                        if (MyHttpClient.MyHttpClient.Registrate(studTicketNum, password, Name, SurName, FatherName, PhoneNumber,  ref error))
                        {
                            OpenMainWindow(); return;
                        }
                        else
                        {
                            Errorlog = error;
                        }
                    }
                    MessageBox.Show(Errorlog);

                }
                );
            }
        }




        #region Навигация, открытие окна регистрации, возврат на окно авторизации
        private void OpenRegistrationPage()
        {
            if (StartWindow._registrationPage == null)
            {
                StartWindow._registrationPage = new View.Authorization.Registration();
            }
            Errorlog = null;
            StartWindow._viewPage.Content = StartWindow._registrationPage;
        }
        private void OpenAuthorizationPage()
        {
            Errorlog = null;
            StartWindow._viewPage.Content = StartWindow._authorizationPage;
        }


        private RelayCommand openRegistration;
        public RelayCommand OpenRegistration
        {
            get
            {
                return openRegistration ?? new RelayCommand(obj =>
                {
                    OpenRegistrationPage();
                }
                );
            }
        }

        public RelayCommand backToAuthorization;
        public RelayCommand BackToAuthorization
        {
            get
            {
                return backToAuthorization ?? new RelayCommand(obj =>
                {
                    OpenAuthorizationPage();
                }
                );
            }
        }
        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
