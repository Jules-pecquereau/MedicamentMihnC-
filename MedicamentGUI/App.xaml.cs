using System.Windows;

namespace MedicamentGUI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MedicamentVM vm = new MedicamentVM();
            MainWindow mainWindow = new MainWindow(vm);

            mainWindow.Show();
        }
    }
}
