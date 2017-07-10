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
        private string customerID;
        private SqlConnection conn;
        private Frame mainFrame;
        public EditCustomer(SqlConnection sqlconn,Frame frame)
        {
            conn = sqlconn;
            mainFrame = frame;
            InitializeComponent();
        }

        private void btn_enterEditedCustomerID_Click(object sender, RoutedEventArgs e)
        {
            bool valid = Functions.Validate(txb_editCustID);
            if (valid)
            {
                
                SqlCommand selectCustomer = new SqlCommand(
                    "SELECT * FROM moshtari WHERE moshtariID = @custmID", conn);
                selectCustomer.Parameters.Add(new SqlParameter("@custmID", txb_editCustID.Text));
                using (SqlDataReader reader = selectCustomer.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        customerID = txb_editCustID.Text;
                        txb_newCustAddress.Text = reader["address"].ToString();
                        txb_newCustName.Text = reader["name"].ToString();
                        txb_newCustPhone.Text = reader["telephone"].ToString();
                        Functions.visibleLabel(label1, label2, label3);
                        Functions.visibleTextBox(txb_newCustPhone, txb_newCustName, txb_newCustAddress);
                        btn_editCustomer.Visibility = Visibility.Visible;
                        btn_delete.Visibility = Visibility.Visible;
                        label4.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("شناسه مورد نظر موجود نمی باشد");
                    }
                }
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Functions.hideTextBox(txb_newCustPhone, txb_newCustName, txb_newCustAddress);
            Functions.hideLabel(label1, label2, label3);
            btn_editCustomer.Visibility = Visibility.Hidden;
            btn_delete.Visibility = Visibility.Hidden;
            label4.Visibility = Visibility.Hidden;
        }


        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            
            SqlCommand deleteCommand = new SqlCommand(
                    "delete from Moshtari where moshtariID=@custmID;", conn);
            deleteCommand.Parameters.Add(new SqlParameter("@custmID", txb_editCustID.Text));
            try
            {
                deleteCommand.ExecuteNonQuery();
                MessageBox.Show("مشتری با موفقیت حذف شد");
                mainFrame.Navigate(new EditCustomer(conn, mainFrame));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_editCustomer_Click(object sender, RoutedEventArgs e)
        {
            bool valid = Functions.Validate(txb_newCustAddress, txb_newCustName, txb_newCustPhone);
            if (valid)
            {
                SqlCommand editCommand = new SqlCommand(
                    @"UPDATE moshtari SET name = @custName , telephone = @custTel , address = @custAddress
                WHERE moshtariID = @custID", conn);
                editCommand.Parameters.Add(new SqlParameter("@custID", txb_editCustID.Text));
                editCommand.Parameters.Add(new SqlParameter("@custName", txb_newCustName.Text));
                editCommand.Parameters.Add(new SqlParameter("@custTel", txb_newCustPhone.Text));
                editCommand.Parameters.Add(new SqlParameter("@custAddress", txb_newCustAddress.Text));
                try
                {
                    editCommand.ExecuteNonQuery();
                    MessageBox.Show("مشتری با موفقیت ویرایش شد");
                    mainFrame.Navigate(new EditCustomer(conn, mainFrame));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}