using System.Windows;

namespace MedicamentGUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MedicamentPage());
        }

        private void BtnMedicaments_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MedicamentPage());
        }

        private void BtnPatients_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PatientPage());
        }
    }
}