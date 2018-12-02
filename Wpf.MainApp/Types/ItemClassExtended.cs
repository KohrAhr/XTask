using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Wpf.GridView.Core;

namespace Wpf.GridView.Types
{
    /// <summary>
    ///     Extended Base Item Class
    /// </summary>
    public class ItemTypeExtended : ItemType
    {
        public static ItemTypeExtended/* explicit operator*/ GetItemTypeAsItemClassExtended(ItemType obj)
        {
            ItemTypeExtended result = new ItemTypeExtended()
            {
                Surname = obj.Surname,
                FirstName = obj.FirstName,
                Amount = obj.Amount,
                CardNumber = obj.CardNumber
            };
            return result;
        }

        public override string CardNumber
        {
            get => GetValue(() => CardNumber);
            set
            {
                SetValue(() => CardNumber, value);

                Task.Run(() =>
                {
                    DisplayValue_CardNumber = "...";
                    if (!String.IsNullOrEmpty(value))
                    {
                        DisplayValue_CardNumber = SecurityCore.GetEncryptedData(value).GetAwaiter().GetResult();
                    }
                });

                //Task.Run(async() =>
                //{
                //    DisplayValue_CardNumber = "...";
                //    DisplayValue_CardNumber = await SecurityCore.GetEncryptedData(value);
                //});
            }
        }

        /// <summary>
        /// </summary>
        public string DisplayValue_CardNumber
        {
            get => GetValue(() => DisplayValue_CardNumber);
            set
            {
                SetValue(() => DisplayValue_CardNumber, value);
                NotifyPropertyChanged("AdHock_Item1");
                NotifyPropertyChanged("AdHock_Item2");
            }
        }

        /// <summary>
        ///     Red background
        /// </summary>
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

        /// <summary>
        ///     Yellow background
        /// </summary>
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

    }
}
