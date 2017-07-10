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
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Page
    {
        private SqlConnection conn;
        public AddCustomer(SqlConnection sqlconn)
        {
            conn = sqlconn;
            InitializeComponent();
            
        }
        private void btn_addCustomer_Click(object sender, RoutedEventArgs e)
        {
            bool valid=Functions.Validate(txb_custID, txb_custName, txb_custPhone, txb_custAddress);
            if (valid)
            {
                SqlCommand insertCommand = new SqlCommand(
                "insert into moshtari values(@customerID,@customerName,@customerPhone,@customerAddress);", conn);
                insertCommand.Parameters.Add(new SqlParameter("customerID", txb_custID.Text));
                insertCommand.Parameters.Add(new SqlParameter("customerName", txb_custName.Text));
                insertCommand.Parameters.Add(new SqlParameter("customerPhone", txb_custPhone.Text));
                insertCommand.Parameters.Add(new SqlParameter("customerAddress", txb_custAddress.Text));
                try
                {
                    insertCommand.ExecuteNonQuery();
                    MessageBox.Show("مشتری با موفقیت ثبت شد");
                    txb_custAddress.Clear();
                    txb_custID.Clear();
                    txb_custName.Clear();
                    txb_custPhone.Clear();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("شناسه کاربری وارد شده قبلا ثبت شده است");
                }
            }
            
        }
    }
}
