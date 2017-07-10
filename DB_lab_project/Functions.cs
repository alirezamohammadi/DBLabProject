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
        public static void clearTextBox(params TextBox[] textBoxes)
        {
            foreach(TextBox textBox in textBoxes)
            {
                textBox.Clear();
            }
        }
        public static void hideLabel(params Label[] labels)
        {
            foreach(Label label in labels)
            {
                label.Visibility = Visibility.Hidden;
            }
        }
        public static void hideTextBox(params TextBox[] textBoxes)
        {
            foreach(TextBox textBox in textBoxes)
            {
                textBox.Visibility = Visibility.Hidden;
            }
        }
        public static void visibleTextBox(params TextBox[] textBoxes)
        {
            foreach(TextBox textBox in textBoxes)
            {
                textBox.Visibility = Visibility.Visible;
            }
        }
        public static void visibleLabel(params Label[] labels)
        {
            foreach(Label label in labels)
            {
                label.Visibility = Visibility.Visible;
            }
        }
    }
}
