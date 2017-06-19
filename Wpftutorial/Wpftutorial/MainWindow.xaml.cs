using System;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Automation;
using Wpftutorial.methods;
using System.Runtime.InteropServices;

namespace Wpftutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "taylor demo";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private Automation​Focus​Changed​Event autofocus = new Automation​Focus​Changed​Event();

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Title = e.GetPosition(this).ToString();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            autofocus.SubscribeToFocusChange(this);
        }

        private void rmvButton_Click(object sender, RoutedEventArgs e)
        {
            autofocus.UnsubscribeFocusChange(this);
        }



        /// <summary>
        /// Handle the event.
        /// </summary>
        /// <param name="src">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        public void OnFocusChange(object src, AutomationFocusChangedEventArgs e)
        {
            // TODO Add event handling code.
            // The arguments tell you which elements have lost and received focus.
            this.Dispatcher.Invoke(() =>
            {
                //focushistory.Text += autofocus.getprocessinfo();
                string name = gettitle(GetForegroundWindow());
                focushistory.Text = name;
            });
        }

        private string gettitle(IntPtr prt)
        {
            const int count = 512;
            var text = new StringBuilder(count);

            if (GetWindowText(prt, text, count) > 0)
            {
                return text.ToString();
            }
            return "NULL";
        }
    }
}
