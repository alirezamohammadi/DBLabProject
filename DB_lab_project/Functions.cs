using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;


namespace DB_lab_project
{
    class Functions
    {
        public static bool Validate(params TextBox[] textBoxes)
        {
            foreach(TextBox textBox in textBoxes)
            {
                if (textBox.Text == "")
                {
                    MessageBox.Show("لطفا برای این فیلد مقدار وارد کنید");
                    textBox.Focus();
                    textBox.SelectAll();
                    return false;
                }
            }
            return true;
        }
    }
}
