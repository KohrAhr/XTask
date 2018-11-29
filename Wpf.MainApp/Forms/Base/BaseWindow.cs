using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf.GridView.Base
{
    public class BaseWindow : Window
    {
        /// <summary>
        ///     Close current window as OK
        /// </summary>
        public void CloseWindowAsOK()
        {
            DialogResult = true;
            Close();
        }

        public void CloseWindowAsCancel()
        {
            DialogResult = false;
            Close();
        }
    }
}
