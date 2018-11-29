using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Lib.MVVM;
using Wpf.GridView.Types;

namespace Wpf.GridView.Models
{
    public partial class NewItemModel : PropertyChangedNotification
    {
        public ItemType NewItem
        {
            get => GetValue(() => NewItem);
            set => SetValue(() => NewItem, value);
        }
    }
}
