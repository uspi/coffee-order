
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Angular.Models
{
    /// <summary>
    /// List of standard coffee beverage types
    /// </summary>
    public enum CoffeeType
    {
        [Display(Name = "Not Selected")]
        None = 0,

        Espresso,

        Latte,

        Americano
    }
}
