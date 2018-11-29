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
using Wpf.GridView.ViewModels;

namespace Wpf.GridView.Forms
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : BaseWindow
    {
        public LoginWindow()
        {
            InitializeComponent();

            DataContext = new LoginVM();
            ((LoginVM)DataContext).CloseAsOK += CloseWindowAsOK;
        }
    }
}
