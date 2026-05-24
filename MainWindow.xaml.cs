using System.Windows;

namespace RPM_14
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnExample1_Click(object sender, RoutedEventArgs e) => new Example1Window().ShowDialog();
        private void BtnExample2_Click(object sender, RoutedEventArgs e) => new Example2Window().ShowDialog();
        private void BtnExample3_Click(object sender, RoutedEventArgs e) => new Example3Window().ShowDialog();
        private void BtnExample4_Click(object sender, RoutedEventArgs e) => new Example4Window().ShowDialog();
        private void BtnExample5_Click(object sender, RoutedEventArgs e) => new Example5Window().ShowDialog();
        private void BtnTask1_Click(object sender, RoutedEventArgs e) => new Task1Window().ShowDialog();
    }
}