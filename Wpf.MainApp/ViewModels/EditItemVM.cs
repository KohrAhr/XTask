using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
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
            string result = Model.CurrentItem.ValidateProperty("FirstName");
            result += Model.CurrentItem.ValidateProperty("SpecialCode");
            if (String.IsNullOrEmpty(result))
            {
                CloseAsOkEvent();
            };


            //// Validate data (all data should be entered)
            //if (!Model.CurrentItem.IsEntered)
            //{
            //    new ItemFunctions().ShowDataValidationWarning();
            //    return;
            //}

            //// Raise Close event
            //CloseAsOkEvent();
        }
    }
}
