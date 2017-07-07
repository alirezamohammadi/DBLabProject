﻿using System;
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
using System.Data.SqlClient;

namespace DB_lab_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection conn = new SqlConnection();
        public MainWindow()
        {
            InitializeComponent();
            navMenu.Visibility = Visibility.Hidden;
            mainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            mainFrame.Navigate(new Login(conn,navMenu, mainFrame));
        }

    }
}