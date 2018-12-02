using Lib.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
using Wpf.GridView.Functions;
using Wpf.GridView.Types;
using Wpf.GridView.ViewModels;

namespace Wpf.GridView.Forms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string TextSearch
        {
            get
            {
                return txtSearch.Text.ToUpper();
            }
            set
            {
                txtSearch.Text = value;
            }
        }

        public string TextHighlight
        {
            get
            {
                return txtHighlight.Text.ToUpper();
            }
            set
            {
                txtHighlight.Text = value;
            }
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowVM();
        }

        /// <summary>
        ///     Data grid filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBoxName = (TextBox)sender;
            string filterText = textBoxName.Text.ToUpper();

            FilterGridView(dgMain.ItemsSource, filterText);
        }

        private void FilterGridView(IEnumerable itemsControls, string filterText)
        {
            ICollectionView cv = CollectionViewSource.GetDefaultView(itemsControls);

            cv.Filter = o => {
                ItemType p = o as ItemType;

                if (String.IsNullOrEmpty(filterText))
                {
                    return true;
                }
                else
                {
                    return ClassFunctions.IsTextMatchInValues(p, filterText);
                }
            };
        }

        /// <summary>
        ///     Reset filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetSearch_Click(object sender, RoutedEventArgs e)
        {
            ResetSearch();
        }

        /// <summary>
        ///     Reset Highlight
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetHighlight_Click(object sender, RoutedEventArgs e)
        {
            ResetHighlight();
        }

        private void ResetSearch()
        {
            TextSearch = "";
        }

        private void ResetHighlight()
        {
            TextHighlight = "";
        }

        private void miModifyItem_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindowVM)DataContext).ModifyItemCommand.Execute(dgMain.SelectedItems);
        }

        private void miDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindowVM)DataContext).DeleteItemCommand.Execute(dgMain.SelectedItems);
        }
    }
}
