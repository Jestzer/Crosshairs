using System.Windows;

namespace Crosshairs
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            InterfaceWindow interfaceWindow = new InterfaceWindow();
            interfaceWindow.Show();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

        }
    }
}
