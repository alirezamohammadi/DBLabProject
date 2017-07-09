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
    /// Interaction logic for DeleteCustomer.xaml
    /// </summary>
    public partial class DeleteCustomer : Page
    {
        private SqlConnection conn;
        public DeleteCustomer(SqlConnection sqlconn)
        {
            conn = sqlconn;
            InitializeComponent();
        }

        private void btn_enterEditedCustomerID_Click(object sender, RoutedEventArgs e)
        {
            bool valid = Functions.Validate(txb_editCustID);
            if (valid)
            {
                SqlCommand deleteCommand = new SqlCommand(
                    "delete from Moshtari where moshtariID=@custmID;", conn);
                deleteCommand.Parameters.Add(new SqlParameter("@custmID", txb_editCustID.Text));
                deleteCommand.ExecuteNonQuery();
                MessageBox.Show("مشتری با موفقیت حذف شد");
                txb_editCustID.Clear();
            }
        }
    }
}
