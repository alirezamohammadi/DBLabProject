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
using System.Windows.Forms;

namespace DB_lab_project
{
    /// <summary>
    /// Interaction logic for RestoreBackup.xaml
    /// </summary>
    public partial class RestoreBackup : Page
    {
        private string path;
        private SqlConnection conn;
        public RestoreBackup(SqlConnection sqlConn)
        {
            InitializeComponent();
            conn = sqlConn;
            btn_restoreBackup.Visibility = Visibility.Hidden;
            chb_agree.Visibility = Visibility.Hidden;
        }


        private void btn_restoreBackup_Click(object sender, RoutedEventArgs e)
        {

            if (Convert.ToBoolean(chb_agree.IsChecked))
            {
                string restoreCmd = string.Format("USE master RESTORE DATABASE DB_lab_project FROM DISK='{0}' WITH REPLACE;", path);
                try
                {
                    SqlCommand cmd = new SqlCommand(restoreCmd, conn);
                    cmd.ExecuteNonQuery();
                    System.Windows.MessageBox.Show("فایل پشتیبان با موفقیت بازنشانی شد");
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
                finally
                {
                    //empty
                }
            }
            else
                System.Windows.MessageBox.Show("لطفا گزینه متن بالا را مطالعه کردم را انتخاب کنید");

        }

        private void btn_loadFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "SQL SERVER Backup File (*.bak)|*.bak";
            DialogResult result = openFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                lbl_path.Content = path = openFile.FileName;
                btn_restoreBackup.Visibility = Visibility.Visible;
                chb_agree.Visibility = Visibility.Visible;
            }
        }
    }
}
