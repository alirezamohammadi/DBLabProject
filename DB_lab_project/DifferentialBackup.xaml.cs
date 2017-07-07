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
    /// Interaction logic for DifferentialBackup.xaml
    /// </summary>
    public partial class DifferentialBackup : Page
    {
        private SqlConnection conn;
        private string path;
        public DifferentialBackup(SqlConnection sqlConn)
        {
            InitializeComponent();
            conn = sqlConn;
            btn_differentialBackup.Visibility = Visibility.Hidden;
            chb_agree.Visibility = Visibility.Hidden;
        }

        private void btn_loadFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "SQL SERVER Backup File (*.bak)|*.bak";
            DialogResult result = openFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                lbl_path.Content = path = openFile.FileName;
                btn_differentialBackup.Visibility = Visibility.Visible;
                chb_agree.Visibility = Visibility.Visible;
            }
        }

        private void btn_differentialBackup_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(chb_agree.IsChecked))
            {
                string diffBackupCmd = string.Format("USE master BACKUP DATABASE Amlaak TO DISK='{0}' WITH DIFFERENTIAL;", path);
                try
                {
                    SqlCommand cmd = new SqlCommand(diffBackupCmd, conn);
                    cmd.ExecuteNonQuery();
                    System.Windows.MessageBox.Show("فایل پشتیبان با موفقیت به روز رسانی شد");
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
    }
}
