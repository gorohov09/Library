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

namespace LibraryStudentClient.ViewModel
{
    public class DataManagerAuthorizationVM : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FatherName { get; set; }
        public string PhoneNumber { get; set; }
        public string StudTicketNum 
        {
            get { return StudTicketNum; }
            set { StudTicketNum = value; NotifyPropertyChanged("StudTicketNum"); }
        }
        public string Password 
        { 
            get { return Password; } 
            set { Password = value; NotifyPropertyChanged("Password"); }
        }



        private void OpenRegistrationPage()
        {
            string num = StudTicketNum;
            string pasw = Password;
            StartWindow._viewPage.Content = new View.Authorization.Registration();
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

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
