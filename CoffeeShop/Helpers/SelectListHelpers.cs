using CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Helpers
{
    public static class SelectListHelpers
    {
        public static SelectList EnumCoffeeVolumeToSelectList()
        {
            var list = EnumToSelectList<CoffeeVolume>(
                // milliliters to liters
                text => 
                { 
                    return text == 0 ? 
                        "0" : 
                        String.Format("{0:f3}", ((double)text / 1000)); 
                },
                value => ((int)value).ToString()
            );

            return new SelectList(list, "Value", "Text");
        }

        public static SelectList EnumCoffeeTypeToSelectList()
        {
            var list = EnumToSelectList<CoffeeType>(
                text  => text.GetElementName(b => Enum.GetName(b)),
                value => ((int)value).ToString()
            );

            return new SelectList(list, "Value", "Text");
        }

        /// <summary>
        /// Converts <see cref="Enum"/> to <see cref="List{SelectList}"/>
        /// </summary>
        /// <typeparam name="TEnumType">Any of Enum Type</typeparam>
        /// <param name="funcText">Conversion of field "text" of enum item</param>
        /// <param name="funcValue">Conversion of field "value" of enum item</param>
        /// <returns>Select List of selected enum type</returns>
        private static List<SelectListItem> EnumToSelectList<TEnumType>(
            Func<TEnumType, string> funcText,
            Func<TEnumType, string> funcValue)
            where TEnumType : Enum
        {
            return Enum.GetValues(typeof(TEnumType))
                   .Cast<TEnumType>()
                   .Select(v => new SelectListItem
                   {
                       Text = funcText?.Invoke(v),

                       Value = funcValue?.Invoke(v)
                   })
                   .ToList();
        }
    }
}
