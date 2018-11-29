using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wpf.GridView.Core;
using Lib.MVVM;
using Wpf.GridView.Types;

namespace Wpf.GridView.ViewModels
{
    public partial class MainWindowVM : PropertyChangedNotification
    {
        public string SecretKey
        {
            get { return CoreData.EncryptionKey; }
            set { }
        }

        public ItemsType TestItems
        {
            get { return GetValue(() => TestItems); }
            set { SetValue(() => TestItems, value); }
        }
    }
}
