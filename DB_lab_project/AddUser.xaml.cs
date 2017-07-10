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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Page
    {
        private SqlConnection conn;
        public AddUser(SqlConnection sqlConn)
        {
            conn = sqlConn;
            InitializeComponent();
        }

        private bool Validate()
        {
            if (txb_confirmPass.Text != txb_password.Text)
            {
                MessageBox.Show("کلمه عبور با تکرار آن برابر نیست");
                return false;
            }
            return Functions.Validate(txb_newUserName, txb_password, txb_confirmPass);
        }

        private void btn_addUser_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                SqlCommand cmd = new SqlCommand(@"EXEC sp_addlogin @username , @password;
                                                EXEC sp_grantdbaccess @username;", conn);
                cmd.Parameters.Add(new SqlParameter("username", txb_newUserName.Text));
                cmd.Parameters.Add(new SqlParameter("password", txb_password.Text));
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("کاربر جدید با موفقیت افزوده شد");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
