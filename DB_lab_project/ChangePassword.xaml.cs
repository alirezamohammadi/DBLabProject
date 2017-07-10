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
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Page
    {
        private SqlConnection conn;
        public ChangePassword(SqlConnection sqlConn)
        {
            conn = sqlConn;
            InitializeComponent();
        }

        private bool Validate()
        {
            if (txb_currPass.Text == "")
            {
                MessageBox.Show("کلمه عبور فعلی را وارد کنید");
                txb_currPass.Focus();
                return false;
            }
            else if (psw_newPass.Password == "")
            {
                MessageBox.Show("کلمه عبور جدید را وارد کنید");
                psw_newPass.Focus();
                return false;
            }
            else if (psw_newPass.Password != psw_newPassConfirm.Password)
            {
                MessageBox.Show("کلمه عبور و تکرار آن مطابقت نمی‌کنند");
                return false;
            }
            return true;
            
        }

        private void btn_changePassword_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand(
                "sp_password @curr_pass, @new_pass, @user_name", conn);
            cmd.Parameters.Add(new SqlParameter("curr_pass", txb_currPass.Text));
            cmd.Parameters.Add(new SqlParameter("new_pass", psw_newPass.Password));
            cmd.Parameters.Add(new SqlParameter("user_name", txb_userName.Text));
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("کلمه عبور با موفقیت به روز رسانی شد");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
