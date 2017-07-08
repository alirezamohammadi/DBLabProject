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

        private void mi_fullBackup_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new FullBackup(conn));
        }

        private void mi_differentialBackup_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new DifferentialBackup(conn));
        }

        private void mi_restoreBackup_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new RestoreBackup(conn));
        }

        private void mi_about_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new About());
        }

        private void mi_addCustomer_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new AddCustomer(conn));
        }

        private void mi_editCustomer_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new EditCustomer(conn));
        }

        private void mi_deleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new DeleteCustomer());
        }
    }
}
