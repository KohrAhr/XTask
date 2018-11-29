using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.GridView.Functions
{
    public static class DataFunctions
    {
        ///// <summary>
        /////     Is text match in any fields in class
        /////     <para>If "filterText" is empty, return True (Match) -- mean that -- "No Entry" (or "empty string") always equal to anything</para>
        /////     <para>Why so strange? In DataGrid when filter text does not specified we should display all rows, in other words, all rows should match to empty string :)</para>
        /////     <para>This function could be used as alternative way for search in datagrid</para>
        ///// </summary>
        ///// <typeparam name="T">
        /////     Any type
        ///// </typeparam>
        ///// <param name="instance">
        /////     Instance of any class
        ///// </param>
        ///// <param name="text">
        /////     Text for search
        ///// </param>
        ///// <param name="caseSensative">
        /////     Default is False
        ///// </param>
        ///// <returns>
        /////     True if is match
        ///// </returns>
        //public static bool IsTextMatchInValues<T>(T instance, string text, bool caseSensative = false)
        //{
        //    bool result = true;

        //    if (!String.IsNullOrEmpty(text))
        //    {
        //        if (caseSensative)
        //        {
        //            text = text.ToUpper();
        //        }

        //        foreach (PropertyInfo propertyInfo in instance.GetType().GetProperties())
        //        {
        //            object value = propertyInfo.GetValue(instance, null);

        //            if (value == null)
        //            {
        //                continue;
        //            }

        //            string valueAsString = value.ToString();

        //            if (caseSensative)
        //            {
        //                valueAsString = valueAsString.ToUpper();
        //            }

        //            result = valueAsString.Contains(text);

        //            // "If" for optimization
        //            if (result)
        //            {
        //                break;
        //            }
        //        }
        //    }

        //    return result;
        //}

            // TODO: Move to library: Lib.Data
    }
}
