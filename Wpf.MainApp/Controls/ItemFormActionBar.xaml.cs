﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib.MVVM;
using Wpf.GridView.Functions;
using Lib.UI;
using System.ComponentModel;
using Wpf.GridView.Types;

namespace Wpf.GridView.Controls
{
    /// <summary>
    /// Interaction logic for ItemFormActionBar.xaml
    /// </summary>
    public partial class ItemFormActionBar : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Setters for the new button properties here

        public string NewButton1Title
        {
            get { return (string)GetValue(NewButton1TitleProperty); }
            set 
            { 
                SetValue(NewButton1TitleProperty, value);
                OnPropertyChanged(nameof(NewButton1Title));
            }
        }

        public RelayCommand NewButton1Command
        {
            get { return (RelayCommand)GetValue(NewButton1CommandProperty); }
            set
            {
                SetValue(NewButton1CommandProperty, value);
                OnPropertyChanged(nameof(NewButton1CommandProperty));
            }
        }

        public static readonly DependencyProperty NewButton1TitleProperty = DependencyProperty.Register("NewButton1Title", typeof(string), typeof(ItemFormActionBar));

        public static readonly DependencyProperty NewButton1CommandProperty = DependencyProperty.Register("NewButton1Command", typeof(RelayCommand), typeof(ItemFormActionBar));
        
        /// <summary>
        /// 
        /// </summary>
        public enum AvailableButtons
        {
            abNew = 0,
            abUpdate = 1,
            abCancel = 2,
            abAddon1 = 3,
            abAddon2 = 4,
        };

        #region Events definition
        public event EventHandler UserControlNewButtonClicked;
        public event EventHandler UserControlUpdateButtonClicked;
        #endregion Events definition

        #region Commands definition
        //public ICommand NewCommand { get; set; }
        //public ICommand UpdateCommand { get; set; }
        #endregion Commands definition

        public ItemFormActionBar()
        {
            InitializeComponent();

//            InitCommands();
        }

        //private void InitCommands()
        //{
        //    NewCommand = new RelayCommand(NewCommandProc);
        //    UpdateCommand = new RelayCommand(UpdateCommandProc);
        //}

        //public void NewCommandProc(object o)
        //{
        //    UserControlNewButtonClicked?.Invoke(this, EventArgs.Empty);
        //}

        //private void UpdateCommandProc(object o)
        //{
        //    UserControlUpdateButtonClicked?.Invoke(this, EventArgs.Empty);
        //}

        public void SetButtons(AvailableButtons[] availableButtons)
        {
            // Hide all
            foreach(AvailableButtons i in Enum.GetValues(typeof(AvailableButtons)))
            {
                HideButtonByTag((int)i);
            }

            // Set only what we need
            foreach (AvailableButtons i in availableButtons)
            {
                ShowButtonByTag((int)i);
            }
        }

        private void HideButtonByTag(int buttonTag)
        {
            // TODO: gdTop should be replaced on this
            var z = UIFunctions.FindControl<WrapPanel>(this.gdTop);
            Button element = UIFunctions.FindControlByTag<Button>(z, buttonTag.ToString());
            if (element != null)
            {
                element.Visibility = Visibility.Collapsed;
            }
        }

        private void ShowButtonByTag(int buttonTag)
        {
            // TODO: gdTop should be replaced on this
            Button element = UIFunctions.FindControlByTag<Button>(gdTop, buttonTag.ToString());
            if (element != null)
            {
                element.Visibility = Visibility.Visible;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            UserControlNewButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UserControlUpdateButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
