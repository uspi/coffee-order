
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Models
{
    ///// <summary>
    ///// Standard coffee portions in liters
    ///// </summary>
    //public static class CoffeeVolume
    //{
    //    public static double Small => 0.133;
           
    //    public static double Medium => 0.250;
            
    //    public static double Large => 0.500;
    //}

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
