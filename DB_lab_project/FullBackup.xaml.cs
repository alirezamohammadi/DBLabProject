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
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DB_lab_project
{
    /// <summary>
    /// Interaction logic for FullBackup.xaml
    /// </summary>
    public partial class FullBackup : Page
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private string path;
        public FullBackup(SqlConnection sqlConn)
        {
            InitializeComponent();
            conn = sqlConn;
            btn_createBackup.Visibility = Visibility.Hidden;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveBackup = new SaveFileDialog();
            saveBackup.Filter = "SQL SERVER Backup File (*.bak)|*.bak";
            DialogResult result = saveBackup.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = saveBackup.FileName;
                lbl_path.Content = path;
                btn_createBackup.Visibility = Visibility.Visible;

            }
        }

        private void btn_createBackup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cmdStr = string.Format("BACKUP DATABASE DB_lab_project TO DISK = '{0}'", path);
                cmd = new SqlCommand(cmdStr, conn);
                cmd.ExecuteNonQuery();
                System.Windows.MessageBox.Show("پشتیبان با موفقیت ایجاد شد");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
    }
}
