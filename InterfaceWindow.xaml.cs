using Crosshairs.Properties;
using System.Text.RegularExpressions;
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

        private void CoordinatesTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Use regular expression to check if input is numeric. This pattern allows numbers and a hyphen.
            // The setting currently is not setup to accept decimal points.
            Regex regex = new Regex("[^0-9-]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void CoordinatesTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                string text = (string)e.DataObject.GetData(typeof(String));
                Regex regex = new Regex("[^0-9-]+");
                if (regex.IsMatch(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
