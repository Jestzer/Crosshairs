using Crosshairs.Properties;
using System.Windows;
using System.Windows.Input;


namespace Crosshairs
{
    public partial class InterfaceWindow : Window
    {
        public InterfaceWindow()
        {
            InitializeComponent();

            // For printing the version number.
            DataContext = this;
        }
        public string PackageVersion
        {
            get
            {
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                if (assembly != null)
                {
                    var version = assembly.GetName().Version;
                    if (version != null)
                    {
                        return version.ToString();
                    }
                }
                return "Error getting version number";
            }
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.yCord--;
        }
        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.yCord++;
        }
        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.xCord--;
        }
        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.xCord++;
        }
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.yCord = 500;
            Properties.Settings.Default.xCord = 0;
        }        
    }
}
