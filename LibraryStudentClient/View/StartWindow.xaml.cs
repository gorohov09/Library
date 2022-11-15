using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LibraryStudentClient.View.Authorization;
using LibraryStudentClient.ViewModel;

namespace LibraryStudentClient.View
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public static Frame _viewPage { get; set; }
        public static Authorization.Authorization _authorizationPage { get; set; }
        public static Authorization.Registration? _registrationPage { get; set; }

        public static StartWindow _window { get; set; }

        public static DataManagerAuthorizationVM _mng { get; set; }

        public StartWindow()
        {

            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            _mng = new DataManagerAuthorizationVM();
            _window = this;
            _registrationPage = null;
            _viewPage = this.MainFrame;
            _authorizationPage = new View.Authorization.Authorization();
            MainFrame.Content = _authorizationPage;


        }

    }
}
