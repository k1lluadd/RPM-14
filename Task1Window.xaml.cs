using System;
using System.Windows;
using System.Windows.Controls;

namespace RPM_14
{
    public partial class Task1Window : Window
    {
        private string _currentOp = "+";

        public Task1Window()
        {
            InitializeComponent();
        }

        private void cboMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pnlCombo == null || pnlRadio == null || pnlList == null || pnlBtns == null)
                return;

            pnlCombo.Visibility = cboMode.SelectedIndex == 0 ? Visibility.Visible : Visibility.Collapsed;
            pnlRadio.Visibility = cboMode.SelectedIndex == 1 ? Visibility.Visible : Visibility.Collapsed;
            pnlList.Visibility = cboMode.SelectedIndex == 2 ? Visibility.Visible : Visibility.Collapsed;
            pnlBtns.Visibility = cboMode.SelectedIndex == 3 ? Visibility.Visible : Visibility.Collapsed;
        }

        private void OpBtn_Click(object sender, RoutedEventArgs e)
        {
            _currentOp = (sender as Button).Content.ToString();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(txtNum1.Text, out double n1) || !double.TryParse(txtNum2.Text, out double n2))
            {
                MessageBox.Show("Введите корректные числа!", "Ошибка ввода",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int mode = cboMode.SelectedIndex;
            string op = _currentOp;

            if (mode == 0)
                op = GetOpFromItem(cboOp.SelectedItem);
            else if (mode == 1)
            {
                if (rbAdd.IsChecked == true) op = "+";
                else if (rbSub.IsChecked == true) op = "-";
                else if (rbMul.IsChecked == true) op = "*";
                else if (rbDiv.IsChecked == true) op = "/";
                else if (rbPow.IsChecked == true) op = "^";
                else if (rbMod.IsChecked == true) op = "%";
            }
            else if (mode == 2)
                op = GetOpFromItem(lstOp.SelectedItem);

            try
            {
                double res = Calculate(n1, n2, op);
                txtResult.Text = string.Format("{0} {1} {2} = {3:F4}", n1, op, n2, res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка вычисления",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string GetOpFromItem(object item)
        {
            if (item == null) return "+";
            string text = item.ToString();
            int start = text.IndexOf('(') + 1;
            int end = text.IndexOf(')');
            return start > 0 && end > start ? text.Substring(start, end - start) : "+";
        }

        private double Calculate(double a, double b, string op)
        {
            switch (op)
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/":
                    if (b == 0) throw new Exception("Деление на ноль!");
                    return a / b;
                case "^": return Math.Pow(a, b);
                case "%":
                    if (b == 0) throw new Exception("Деление на ноль!");
                    return a % b;
                default: throw new Exception("Неизвестная операция");
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}