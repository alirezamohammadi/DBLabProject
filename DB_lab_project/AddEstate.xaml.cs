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
    /// Interaction logic for AddEstate.xaml
    /// </summary>
    public partial class AddEstate : Page
    {
        private SqlConnection conn;
        public AddEstate(SqlConnection sqlConn)
        {
            conn = sqlConn;
            InitializeComponent();
        }

        

        private void btn_addEstate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
