using Lib.MVVM;

namespace Wpf.GridView.Models
{
    public class LoginModel : PropertyChangedNotification
    {
        /// <summary>
        ///     Indicate that PC is connected to Active Directory Domain
        /// </summary>
        public bool InDomain
        {
            get { return GetValue(() => InDomain); }
            set { SetValue(() => InDomain, value); }
        }

        /// <summary>
        ///     Domain or workgroup
        /// </summary>
        public string Domain
        {
            get { return GetValue(() => Domain); }
            set { SetValue(() => Domain, value); }
        }

        /// <summary>
        ///     Fully formatted username
        /// </summary>
        public string Username
        {
            get { return GetValue(() => Username); }
            set { SetValue(() => Username, value); }
        }
    }
}
