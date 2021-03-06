﻿using Lib.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Lib.MVVM;
using Wpf.GridView.Forms;
using Lib.Strings;
using Wpf.GridView.Types;
using System.Security;

namespace Wpf.GridView.ViewModels
{
    public partial class MainWindowVM
    {
        #region Commands definition
        public ICommand NewItemCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }
        public ICommand ModifyItemCommand { get; set; }
        #endregion Commands definition

        /// <summary>
        ///     Constructor
        /// </summary>
        public MainWindowVM()
        {
            InitData();

            InitCommands();
        }

        private void InitData()
        {
            TestItems = new ItemsType();

            // Should be added
            TestItems.Add(
                new ItemTypeExtended { FirstName = "X1", Surname = "S1", CardNumber = "12345", Amount = 25.67 }
            );

            // Shoudn't be added -- card number contain not only digits
            TestItems.Add(
                new ItemTypeExtended { FirstName = "X2", Surname = "S2", CardNumber = "12345 ", Amount = 12.1 }
            );

            // Shoudn't be added -- card number contain not only digits
            TestItems.Add(
                new ItemTypeExtended { FirstName = "X3", Surname = "S3", CardNumber = "12345B", Amount = 13 }
            );

            // Shoudn't be added -- card number already exist
            TestItems.Add(
                new ItemTypeExtended { FirstName = "X4", Surname = "S4", CardNumber = "12345", Amount = 0.03 }
            );

            // Should be added
            TestItems.Add(
                new ItemTypeExtended { FirstName = "X5", Surname = "S5", CardNumber = "123456", Amount = 0.03 }
            );

            // Should be added
            TestItems.Add(
                new ItemTypeExtended { FirstName = "X5", Surname = "S5T1", CardNumber = "1234567", Amount = 0.02 }
            );

            // Should be added
            TestItems.Add(
                new ItemTypeExtended { FirstName = "X5T1", Surname = "S5", CardNumber = "12345678", Amount = 0.01 }
            );

            // Shoudn't be added -- full name already exist
            TestItems.Add(
                new ItemTypeExtended { FirstName = "X5T1", Surname = "S5", CardNumber = "123456789", Amount = 0 }
            );
        }

        private void InitCommands()
        {
            NewItemCommand = new RelayCommand(NewItemCommandProc);
            DeleteItemCommand = new RelayCommand(DeleteItemCommandProc, DeleteItemCommandEnabled);
            ModifyItemCommand = new RelayCommand(ModifyItemCommandProc, ModifyItemCommandEnabled);
        }

        #region Commands implementation
        private void NewItemCommandProc(Object o)
        {
            NewItemWindow newItemWindow = WindowsUI.ShowWindowDialogEx<NewItemWindow>();
            if (newItemWindow.DialogResult == true)
            {
                ItemTypeExtended newItem = ItemTypeExtended.GetItemTypeAsItemClassExtended(
                    ((NewItemVM)(newItemWindow.DataContext)).Model.NewItem
                );

                // Update item
                TestItems.Add(
                    newItem
                );
            }
        }

        private void DeleteItemCommandProc(Object selectedItems)
        {
            ItemType selectedItem = (ItemType)((ObservableCollection<object>)selectedItems).FirstOrDefault();
            if (selectedItem == null)
            {
                return;
            }

            bool result = true;
            WindowsUI.RunWindowDialog(() =>
                {
                    if (MessageBox.Show(
                        String.Format(StringsFunctions.ResourceString("resDeleteConfirmation"), selectedItem.FirstName, selectedItem.Surname),
                        StringsFunctions.ResourceString("resConfirmationRequired"), MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                    {
                        result = false;
                    }
                }
            );
            if (!result)
            {
                return;
            }

            TestItems.Remove((ItemTypeExtended)selectedItem);
        }

        private bool DeleteItemCommandEnabled(Object o)
        {
            bool result = false;

            if (o != null)
            {
                ItemType selectedItem = (ItemType)((ObservableCollection<object>)o).FirstOrDefault();

                result = selectedItem != null;
            }

            return result;
        }

        private void ModifyItemCommandProc(Object selectedItems)
        {
            ItemTypeExtended selectedItem = (ItemTypeExtended)((ObservableCollection<object>)selectedItems).FirstOrDefault();
            if (selectedItem == null)
            {
                return;
            }

            // Show window
            EditItemWindow editItemWindow = WindowsUI.ShowWindowDialogEx<EditItemWindow>(selectedItem);
            if (editItemWindow.DialogResult == true)
            {
                ItemTypeExtended currentItem = ItemTypeExtended.GetItemTypeAsItemClassExtended(
                    ((EditItemVM)(editItemWindow.DataContext)).Model.CurrentItem
                );

                // Update item
                TestItems.Update(selectedItem, currentItem);
            }
        }

        private bool ModifyItemCommandEnabled(Object o)
        {
            bool result = false;

            if (o != null)
            {
                ItemType selectedItem = (ItemType)((ObservableCollection<object>)o).FirstOrDefault();

                result = selectedItem != null;
            }

            return result;
        }
        #endregion Commands implementation
    }
}
