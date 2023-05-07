using System;
using System.Windows;
using System.Windows.Input;
using Lib.MVVM;
using Wpf.GridView.Models;
using Wpf.GridView.ViewModels.Base;
using Wpf.GridView.ViewModels.Functions;

namespace Wpf.GridView.ViewModels
{
    public partial class NewItemVM : BaseVM
    {
        public ICommand CustomCommand { get; set; }

        public NewItemModel Model { get; set; }

        /// <summary>
        ///     Constructor
        /// </summary>
        public NewItemVM()
        {
            InitData();

            InitCommands();
        }

        private void InitData()
        {
            Model = new NewItemModel();
            Model.NewItem = new Types.ItemType();

        }

        private void InitCommands()
        {
            OkCommand = new RelayCommand(OkCommandProc);

            CustomCommand = new RelayCommand(CustomCommandProc);
        }

        private void CustomCommandProc(object obj)
        {
            MessageBox.Show("Command 1!", "Information");
        }

        private void OkCommandProc(object o)
        {
            // Validate data (all data should be entered)
            if (!Model.NewItem.IsEntered)
            {
                new ItemFunctions().ShowDataValidationWarning();
                return;
            }

            // Raise Close event
            CloseAsOkEvent();
        }
    }
}
