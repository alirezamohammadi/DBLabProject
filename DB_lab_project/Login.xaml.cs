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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private SqlConnection conn;
        private Menu navMenu;
        private Frame mainFrame;
        private string user_name;

        public Login(SqlConnection passedConn, Menu nav, Frame frame)
        {
            conn = passedConn;
            navMenu = nav;
            mainFrame = frame;
            InitializeComponent();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            user_name = txb_userName.Text;
            string password = pwd_password.Password;
            string connectionString = string.Format(@"Server=.\SQLEXPRESS;initial catalog='DB_Lab_Project';
                User Id={0};Password ={1};", user_name, password);
            conn.ConnectionString = connectionString;
            try
            {
                conn.Open();
                navMenu.Visibility = Visibility.Visible;
                mainFrame.Navigate(new About());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
