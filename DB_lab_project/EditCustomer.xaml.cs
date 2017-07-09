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
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Page
    {
        private SqlConnection conn;
        public EditCustomer(SqlConnection sqlconn)
        {
            conn = sqlconn;
            InitializeComponent();
        }

        private void btn_enterEditedCustomerID_Click(object sender, RoutedEventArgs e)
        {
            bool valid = Functions.Validate(txb_editCustID);
            if (valid)
            {
                label1.Visibility = System.Windows.Visibility.Visible;
                label2.Visibility = System.Windows.Visibility.Visible;
                label3.Visibility = System.Windows.Visibility.Visible;
                txb_newCustAddress.Visibility = System.Windows.Visibility.Visible;
                txb_newCustName.Visibility = System.Windows.Visibility.Visible;
                txb_newCustPhone.Visibility = System.Windows.Visibility.Visible;
                btn_editCustomer.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
