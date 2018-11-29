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
    public partial class EditItemModel : PropertyChangedNotification
    {
        public ItemType CurrentItem
        {
            get => GetValue(() => CurrentItem);
            set => SetValue(() => CurrentItem, value);
        }

        public ItemType OriginalItem
        {
            get => GetValue(() => OriginalItem);
            set => SetValue(() => OriginalItem, value);
        }
    }
}
