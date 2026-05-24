using System.Windows;
using System.Windows.Controls;

namespace RPM_14
{
    public partial class Example5Window : Window
    {
        public Example5Window()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            MessageBox.Show("Button is clicked");
                            
        }
    }
}