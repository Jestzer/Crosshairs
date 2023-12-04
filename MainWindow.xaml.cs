using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Data;

namespace Crosshairs
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Topmost = true;

        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            
            // Set the window style to allow click-through.
            var hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            WindowsServices.SetWindowExTransparent(hwnd);
        }
    }
    public static class WindowsServices
    {
        private const int WS_EX_TRANSPARENT = 0x20;

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        public static void SetWindowExTransparent(IntPtr hwnd)
        {
            var extendedStyle = GetWindowLong(hwnd, -20);
            SetWindowLong(hwnd, -20, extendedStyle | WS_EX_TRANSPARENT);
        }
    }
    public class MarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2 && values[0] is double x && values[1] is double y)
            {
                return new Thickness(x, y, 0, 0);
            }
            return new Thickness(0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}