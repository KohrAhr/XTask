using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using Lib.Strings;

namespace Wpf.GridView.Types
{
    public class ItemsType : ObservableCollection<ItemType>
    {
        private ObservableCollection<ItemType> items;

        public ItemsType()
        {
            items = new ObservableCollection<ItemType>();
        }

        public new IEnumerable Items
        {
            get { return items; }
        }

        #region 'CRUD'
        public new void Remove(ItemType item)
        {
            items.Remove(item);
        }

        public void Update(ItemType existingItem, ItemType newItem)
        {
            if (!IsCreditCardValid(newItem, existingItem))
            {
                return;
            }

            // Firstname and surname must unique
            if (IsItemDataUnique(newItem, existingItem))
            {
                return;
            }

            // Find
            ItemType itemType = items.First(x => x == existingItem);

            // Update
            if (itemType != null)
            {
                itemType.Amount = newItem.Amount;
                itemType.Surname = newItem.Surname;
                itemType.FirstName = newItem.FirstName;
                itemType.CardNumber = newItem.CardNumber;
            }
        }

        public new void Add(ItemType item)
        {
            if (item == null)
            {
                return;
            }

            if (!IsCreditCardValid(item))
            {
                return;
            }

            // Firstname and surname must unique
            if (IsItemDataUnique(item))
            {
                return;
            }

            items.Add(item);
        }
        #endregion 'CRUD'

        /// <summary>
        ///     Check: is items in list
        /// </summary>
        /// <returns>
        ///     True -- if at least one item is in list
        ///     <para>False -- list is empty</para>
        /// </returns>
        public bool IsItems()
        {
            return items.Count > 0;
        }

        /// <summary>
        ///     Validate that 
        ///     <para>Card number must contain only numbers</para>
        ///     <para>Card number already exist?</para>
        /// </summary>
        /// <param name="item">
        ///     Item с данными
        /// </param>
        /// <param name="exceptItem">
        ///     ExceptItem как правило тот набор данных, который мы изначально открыли для редактирования
        ///     <para>Если не указан, то скорее всего проверка перед добавлением новой записи</para>
        /// </param>
        /// <returns></returns>
        private bool IsCreditCardValid(ItemType item, ItemType existingItem = null)
        {
            // Card number must contain only numbers
            if (!StringsFunctions.StringContainOnlyDigits(item.CardNumber))
            {
                return false;
            }

            // Card number already exist?
            if (existingItem == null)
            {
                if (items.Where(x => x.CardNumber == item.CardNumber).Count() > 0)
                {
                    return false;
                }
            }
            else
            {
                if (items.Where(x => x.CardNumber == item.CardNumber && x != existingItem).Count() > 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Проверить, что такой Item c данными является уникальным в нашем списке
        /// </summary>
        /// <param name="item">
        ///     Item с данными
        /// </param>
        /// <param name="exceptItem">
        ///     ExceptItem как правило тот набор данных, который мы изначально открыли для редактирования
        ///     <para>Если не указан, то скорее всего проверка перед добавлением новой записи</para>
        /// </param>
        /// <returns></returns>
        private bool IsItemDataUnique(ItemType item, ItemType exceptItem = null)
        {
            bool result = false;

            if (exceptItem == null)
            {
                result = items.Where(x => x.FirstName.ToUpper() == item.FirstName.ToUpper() && x.Surname.ToUpper() == item.Surname.ToUpper()).Count() > 0;
            }
            else
            {
                result = items.Where(x => x.FirstName.ToUpper() == item.FirstName.ToUpper() && x.Surname.ToUpper() == item.Surname.ToUpper() && x != exceptItem).Count() > 0;
            }

            return result;
        }
    }
}
