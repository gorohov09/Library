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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibrarianClient.View.Search
{
    /// <summary>
    /// Логика взаимодействия для SearchReader.xaml
    /// </summary>
    public partial class SearchReader : Page
    {
        public SearchReader()
        {
            InitializeComponent();
            DataContext = MainWindow._mng;
        }
    }
}
