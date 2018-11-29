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
    /// <summary>
    ///     Base Item Class
    /// </summary>
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

        public virtual string CardNumber
        {
            get => GetValue(() => CardNumber);
            set => SetValue(() => CardNumber, value);
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
