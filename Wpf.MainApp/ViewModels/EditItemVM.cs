using System;
using System.Windows.Input;
using Lib.MVVM;
using Wpf.GridView.Models;
using Wpf.GridView.Types;
using Wpf.GridView.ViewModels.Base;
using Wpf.GridView.ViewModels.Functions;

namespace Wpf.GridView.ViewModels
{
    public partial class EditItemVM : BaseVM
    {
        public EditItemModel Model { get; set; }

        /// <summary>
        ///     Constructor
        /// </summary>
        public EditItemVM(ItemType item)
        {
            InitData();

            Model.OriginalItem = item;
            Model.CurrentItem = (ItemType)item.Clone();

            InitCommands();
        }

        private void InitData()
        {
            Model = new EditItemModel();
        }

        private void InitCommands()
        {
            OkCommand = new RelayCommand(OkCommandProc);
        }

        private void OkCommandProc(object o)
        {
            // Validate data (all data should be entered)
            if (!Model.CurrentItem.IsEntered)
            {
                new ItemFunctions().ShowDataValidationWarning();
                return;
            }

            // Raise Close event
            CloseAsOkEvent();
        }
    }
}
