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
using System.Data;

namespace DB_lab_project
{
    /// <summary>
    /// Interaction logic for ShowCustomers.xaml
    /// </summary>
    public partial class ShowCustomers : Page
    {
        private SqlConnection conn;
        public ShowCustomers(SqlConnection sqlConn)
        {
            conn = sqlConn;
            InitializeComponent();
            dataGrid.IsReadOnly = true;
            SqlCommand cmd = new SqlCommand("select * from moshtari", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
        }
    }
}
