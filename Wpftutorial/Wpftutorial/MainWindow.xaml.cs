using System;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Automation;
using Wpftutorial.methods;
using System.Runtime.InteropServices;
using System.Windows.Data;
using System.Windows.Controls;

namespace Wpftutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void btnUpdateSource_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression binding = txtWindowTitle.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }
    }
}
