using Lib.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Lib.Strings;

namespace Wpf.GridView.ViewModels.Functions
{
    public class ItemFunctions
    {
        public void ShowDataValidationWarning()
        {
            WindowsUI.RunWindowDialog(() =>
                {
                    MessageBox.Show(
                        StringsFunctions.ResourceString("resItemValidationGeneral"),
                        StringsFunctions.ResourceString("resInformation"),
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );

                });
        }
    }
}
