
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Angular.Models
{
    /// <summary>
    /// Standard coffee portions in milliliters
    /// </summary>
    public enum CoffeeVolume
    {
        [Display(Name = "Not Selected")]
        None = 0,

        Small = 133,

        Medium = 250,

        Large = 500
    }
}
