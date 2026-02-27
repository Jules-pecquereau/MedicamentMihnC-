using System.Windows;

namespace MedicamentGUI
{
    public partial class MainWindow : Window
    {
        public MainWindow(MedicamentVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}