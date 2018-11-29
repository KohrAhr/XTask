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
    /// Interaction logic for EditItemWindow.xaml
    /// </summary>
    public partial class EditItemWindow : BaseWindow
    {
        public EditItemWindow(ItemType item)
        {
            InitializeComponent();

            DataContext = new EditItemVM(item);
            ((EditItemVM)DataContext).CloseAsOK += CloseWindowAsOK;

            ucTop.SetButtons(
                new ItemFormActionBar.AvailableButtons[]
                {
                    ItemFormActionBar.AvailableButtons.abUpdate,
                    ItemFormActionBar.AvailableButtons.abCancel
                }
            );
        }

        private void ucTop_UserControlUpdateButtonClicked(object sender, EventArgs e)
        {
            ((EditItemVM)DataContext).OkCommand.Execute(null);
        }
    }
}
