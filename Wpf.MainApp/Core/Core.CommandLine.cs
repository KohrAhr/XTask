using Lib.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf.GridView.Core
{
    public static class CommandLineCore
    {
        public static void Init(StartupEventArgs startupEventArgs)
        {
            KeyValuePair<string, string> item;

            Dictionary<string, string> commandLineParameters = new Dictionary<string, string>();

            //
            commandLineParameters = CommandLineFunctions.GetCommandLineParameters(startupEventArgs);

            // Locale
            item = commandLineParameters.Where(x => x.Key == "locale").FirstOrDefault();
            if (item.Key != null && item.Value != null)
            {
                CoreData.RequestedLocale = item.Value;
            }
        }
    }
}
