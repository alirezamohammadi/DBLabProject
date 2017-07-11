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
            Cultures.InitializePersianCulture();
            InitializeComponent();
            mi_date.Header = DateTime.Now.ToString();
            navMenu.Visibility = Visibility.Hidden;
            mainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            mainFrame.Navigate(new Login(conn, navMenu, mainFrame));
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

        private void mi_editDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new EditCustomer(conn,mainFrame));
        }

        private void mi_addEstate_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new AddEstate(conn));
        }

        private void mi_addUser_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new AddUser(conn));
        }

        private void mi_changePassword_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new ChangePassword(conn));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("آیا مطمئن هستید می خواهید خارج شوید؟", "خروج", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                conn.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void mi_logout_Click(object sender, RoutedEventArgs e)
        {
            conn.Close();
            navMenu.Visibility = Visibility.Hidden;
            mainFrame.Navigate(new Login(conn, navMenu, mainFrame));
        }

        private void mi_showCustomers_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new ShowCustomers(conn));
        }
    }
}
