using LibraryStudentClient.ViewModel;
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

namespace LibraryStudentClient.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame _mainFrame { get; set; }
        public static BookPages.ListOfBooks _listOfBooks { get; set; }
        public static DataManagerMainVM _mng { get; set; }
        public static DataManagerReaderVM _reader { get; set; }
        public static MainWindow _window { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Определяем контекст данных
            _mng = new DataManagerMainVM();
            _reader = new DataManagerReaderVM();
            DataContext = _mng;

            _mainFrame = this.MainFrame;
            _window = this;

            // Создаем страницу отображения данных
            _listOfBooks = new BookPages.ListOfBooks();
            _mainFrame.Content = _listOfBooks;
        }
    }
}
