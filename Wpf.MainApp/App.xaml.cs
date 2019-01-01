using Lib.System;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Wpf.GridView.Functions;
using Wpf.GridView.Core;
using Wpf.GridView.Forms;

namespace Wpf.GridView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void AppStartup(Object sender, StartupEventArgs e)
        {
            ErrorHandlingCore.Init();
            CommandLineCore.Init(e);
            CoreData.Init();

            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            LoginWindow loginWindow = new LoginWindow();
            if (loginWindow.ShowDialog() != true)
            {
                Current.Shutdown();

                return;
            }

            Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
