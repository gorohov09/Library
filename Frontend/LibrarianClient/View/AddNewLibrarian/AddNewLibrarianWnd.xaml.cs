using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibrarianClient.View.AddNewLibrarian
{
    /// <summary>
    /// Логика взаимодействия для AddNewLibrarianWnd.xaml
    /// </summary>
    public partial class AddNewLibrarianWnd : Window
    {
        public AddNewLibrarianWnd()
        {
            InitializeComponent();
            DataContext = MainWindow._mng;
        }

        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
