using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Wpftutorial
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Window appBar;
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow();
            MainWindow.Show();
            initAppBar();
        }


        private void initAppBar()
        {
            appBar = new ControlBar();
            appBar.Show();
        }
    }
}
