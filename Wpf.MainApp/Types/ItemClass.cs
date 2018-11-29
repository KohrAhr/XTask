using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lib.MVVM;
using Wpf.GridView.Core;

namespace Wpf.GridView.Types
{
    public class ItemType : PropertyChangedNotification, ICloneable
    {
        public string FirstName
        {
            get => GetValue(() => FirstName);
            set => SetValue(() => FirstName, value);
        }

        public string Surname
        {
            get => GetValue(() => Surname);
            set => SetValue(() => Surname, value);
        }

        public string CardNumber
        {
            get => GetValue(() => CardNumber);
            set
            {
                SetValue(() => CardNumber, value);

                Task.Run(() =>
                {
                    DisplayValue_CardNumber = "...";
                    DisplayValue_CardNumber = SecurityCore.GetEncryptedData(value).GetAwaiter().GetResult();
                });

                //Task.Run(async() =>
                //{
                //    DisplayValue_CardNumber = "...";
                //    DisplayValue_CardNumber = await SecurityCore.GetEncryptedData(value);
                //});
            }
        }

        public double Amount
        {
            get => GetValue(() => Amount);
            set => SetValue(() => Amount, value);
        }

        /// <summary>
        ///     Simple data validation
        ///     <para>Check that all data entered and nothing else!</para>
        /// </summary>
        public bool IsEntered
        {
            get
            {
                return !String.IsNullOrEmpty(FirstName) && !String.IsNullOrEmpty(Surname) && !String.IsNullOrEmpty(CardNumber);
            }
            set
            {
            }
        }

        // TODO: Should be in upper class & should use Dependency Property
        /// <summary>
        /// </summary>
        public string DisplayValue_CardNumber
        {
            get => GetValue(() => DisplayValue_CardNumber);
            set {
                SetValue(() => DisplayValue_CardNumber, value);
                NotifyPropertyChanged("AdHock_Item1");
                NotifyPropertyChanged("AdHock_Item2");
            }
        }

        public bool AdHock_Item1
        {
            get
            {
                bool result = false;
                if (!String.IsNullOrEmpty(DisplayValue_CardNumber))
                {
                    result = DisplayValue_CardNumber.Contains("<");
                }
                return result;
            }
            set { SetValue(() => AdHock_Item1, value); }
        }

        public bool AdHock_Item2
        {
            get
            {
                bool result = false;
                if (!String.IsNullOrEmpty(DisplayValue_CardNumber))
                {
                    result = DisplayValue_CardNumber.Contains("[");
                }
                return result;
            }
            set { SetValue(() => AdHock_Item2, value); }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new ItemType()
            {
                Amount = this.Amount,
                FirstName = this.FirstName,
                Surname = this.Surname,
                CardNumber = this.CardNumber
            };
        }
    }
}
