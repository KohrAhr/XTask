using Lib.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf.GridView.Base;
using Wpf.GridView.Controls;
using Wpf.GridView.Types;
using Wpf.GridView.ViewModels;

namespace Wpf.GridView.Forms
{
    /// <summary>   
    /// Interaction logic for NewItemWindow.xaml
    /// </summary>
    public partial class NewItemWindow : BaseWindow
    { 
        public NewItemWindow()
        {
            InitializeComponent();

            ucTop.SetButtons(
                new ItemFormActionBar.AvailableButtons[]
                {
                    ItemFormActionBar.AvailableButtons.abNew,
                    ItemFormActionBar.AvailableButtons.abCancel,
                    ItemFormActionBar.AvailableButtons.abAddon1,
                    ItemFormActionBar.AvailableButtons.abAddon2
                }
            );

            ucTop.NewButton1Title = "TEST1";
            ucTop.NewButton1Command = new RelayCommand(NewButton1CommandProc);
            ucTop.NewButton2.Content = "TEST2";

            DataContext = new NewItemVM();
            ((NewItemVM)DataContext).CloseAsOK += CloseWindowAsOK;

            //ucTop.SetButtons(
            //    new ItemFormActionBar.AvailableButtons[]
            //    {
            //        ItemFormActionBar.AvailableButtons.abNew,
            //        ItemFormActionBar.AvailableButtons.abCancel
            //    }
            //);
        }

        private void NewButton1CommandProc(object obj)
        {
            ((NewItemVM)DataContext).CustomCommand.Execute(null);
        }

        private void ucTop_UserControlNewButtonClicked(object sender, EventArgs e)
        {
            ((NewItemVM)DataContext).OkCommand.Execute(null);
        }
    }
}
