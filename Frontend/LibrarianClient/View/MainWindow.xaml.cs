﻿using LibrarianClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using LibrarianClient.View.Search;

namespace LibrarianClient.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow _window { get; set; }
        public static DataManagerMainVM _mng { get; set; }
        public static Frame _mainFrame { get; set; }
        public static OrderList orders { get; set; }
        public static SearchReader _searchReaderView { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Определяем контекст данных
            _mng = new DataManagerMainVM();
            _mng.SelectedType = _mng.SearchType[0];

            DataContext = _mng;

            _mainFrame = this.MainFrame;
            _window = this;

            // Создаем страницу отображения данных
            orders = new OrderList();
            _mainFrame.Content = orders;

            _searchReaderView = new SearchReader();
        }
    }
}
