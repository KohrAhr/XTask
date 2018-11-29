using Lib.MVVM;
using Lib.System;
using Lib.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wpf.GridView.Models;
using Wpf.GridView.ViewModels.Base;
using Lib.Strings;

namespace Wpf.GridView.ViewModels
{
    public class LoginVM : BaseVM
    {
        #region Commands definition
        public ICommand LoginCommand { get; set; }
        #endregion Commands definition

        public LoginModel Model
        {
            get; set;
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public LoginVM()
        {
            InitData();

            InitCommands();
        }

        private void InitData()
        {
            Model = new LoginModel();
            Model.Domain = UserFunctions.GetDomainOrPcName();
            Model.Username = UserFunctions.GetFQDN();
        }

        private void InitCommands()
        {
            LoginCommand = new RelayCommand(LoginCommandProc);
        }

        private void LoginCommandProc(object o)
        {
            // PasswordBox is MVVM violation
            if (o == null || !(o is PasswordBox))
            {
                return;
            }

            // PasswordBox is MVVM violation
            bool result = UserFunctions.ValidateUsernameAndPassword(Model.Username, ((PasswordBox)o).SecurePassword);

            // OMG! MVVM Violation! If fact mostly we need it in case of failed validation
            ((PasswordBox)o).Clear();

            if (!result)
            {
                WindowsUI.RunWindowDialog(() =>
                    {
                        MessageBox.Show(
                            StringsFunctions.ResourceString("resLoginFailed"),
                            StringsFunctions.ResourceString("resError"),
                            MessageBoxButton.OK, MessageBoxImage.Hand
                        );
                    }
                );
                return;
            }

            CloseAsOkEvent();
        }
    }
}
