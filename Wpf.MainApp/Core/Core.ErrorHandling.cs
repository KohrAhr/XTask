using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf.GridView.Core
{
    public static class ErrorHandlingCore
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Init()
        {
            // Set Error catching & handling
            AppDomain.CurrentDomain.UnhandledException += (s, eventArgs) =>
                {
                    // TODO: All data to File by NLog. 

                    // Final message to user
                    // In some cases (broken style message box cannot be displayed)
                    MessageBox.Show(
                        eventArgs.ExceptionObject.ToString(),
                        "Error Stack Trace",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );

                    // Possible
                    //Application.Current.Shutdown();
                };

            // ENABLE THIS CODE ONLY IF YOU NEED ADDITIONAL DEBUG INFORMATION!
            //// Set Error catching & handling
            //AppDomain.CurrentDomain.FirstChanceException += (s, eventArgs) =>
            //{
            //    // Log all exception. Only for debug purpose.
            //    Debug.WriteLine(
            //        String.Format("\n-=-[BEGIN]-=-\nError message: {0}\nHResult: {1}\nSource: {2}\n-=-[END]-=-\n",
            //            eventArgs.Exception.ToString(),
            //            eventArgs.Exception.HResult.ToString(),
            //            eventArgs.Exception.Source.ToString()
            //        )
            //    );
            //};
        }
    }
}
