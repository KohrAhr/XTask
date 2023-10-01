using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lib.MVVM;
using Wpf.GridView.Core;
using System.ComponentModel;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Wpf.GridView.Types
{
    /// <summary>
    ///     Base Item Class
    /// </summary>
    public class ItemType : PropertyChangedNotification, ICloneable
    {


        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50, ErrorMessage = "First name should be between range 3-50")]
        [MinLength(3, ErrorMessage = "First name should be between range 3-50")]
        [RegularExpression(@"^[a-zA-Z_]+$", ErrorMessage = "Use letters only please")]
        public string FirstName
        {
            get => GetValue(() => FirstName);
            set => SetValue(() => FirstName, value);
        }

        //[RegularExpression(@"^[a-zA-Z_]+$", ErrorMessage = "Use letters only please")]
        [RegexStringValidator(@"^[a-zA-Z_]+$")]
        //[RegexStringValidator(@"^[\S-]+$")]
        public string Surname
        {
            get => GetValue(() => Surname);
            set => SetValue(() => Surname, value);
        }

        [MaxLength(20, ErrorMessage = "Max length 20")]
        [MinLength(12, ErrorMessage = "Min length 12")]
        [RegularExpression(@"^[\d-]+$", ErrorMessage = "CreditCardNumber is required and it must contain only digits")]
        public virtual string CardNumber
        {
            get => GetValue(() => CardNumber);
            set => SetValue(() => CardNumber, value);
        }

        [Required(ErrorMessage = "Amount is required")]
        public double Amount
        {
            get => GetValue(() => Amount);
            set => SetValue(() => Amount, value);
        }

        [Required(ErrorMessage = "SpecialCode is required")]
        [Range(0, 100, ErrorMessage = "Amount should be between range 0-100")]
        public sbyte SpecialCode
        {
            get => GetValue(() => SpecialCode);
            set => SetValue(() => SpecialCode, value);
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
