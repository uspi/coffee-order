using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace CoffeeShop.Helpers
{
    public static class EnumHelpers
    {
        /// <summary>
        /// Checks if an element has an <see cref="DisplayAttribute"/>.
        /// If yes before returns it <see cref="DisplayAttribute.Name"/>. 
        /// If not then returns result of <paramref name="func"/> 
        /// for this <typeparamref name="EnumType"/> element        
        /// </summary>
        /// <typeparam name="EnumType">Element type your <see cref="Enum"/></typeparam>
        /// <param name="v">Type <typeparamref name="EnumType"/> element</param>
        /// <param name="func">A lambda that needs to be executed on a list 
        /// item <typeparamref name="EnumType"/> in order to return its name. 
        /// In case when attribute <see cref="DisplayAttribute"/> is not found.</param>
        /// <returns>String name of <paramref name="v"/> element</returns>
        public static string GetElementName<EnumType>(this EnumType v, Func<EnumType, string> func) 
            where EnumType : Enum
        {
            // member info about v element
            MemberInfo info =
                v.GetType()
                .GetMember(v.ToString())
                .First();

            // display attribute of v element
            var displayAttribute = info.GetCustomAttribute<DisplayAttribute>();

            // does the element have no display attribute?
            if (displayAttribute == null)
            {
                // no attribute
                return func?.Invoke(v);
            }

            // name from display attribute
            return displayAttribute.GetName();
        }
    }
}
