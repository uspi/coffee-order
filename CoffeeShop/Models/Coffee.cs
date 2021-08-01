using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Models
{
    public class Coffee : ICoffeeVariation
    {
        [Key]
        public long Id { get; set; }

        public CoffeeOrder CoffeeOrder { get; set; }

        [Required(ErrorMessage = "Please select the type")]
        public CoffeeType? CoffeeType { get; set; }

        // volume in liters
        [Required(ErrorMessage = "Please select the volume")]
        public CoffeeVolume? CoffeeVolume { get; set; }

        [Required(ErrorMessage = "Please set the quantity of teaspoons")]
        public byte? QuantitySugarTeaspoons { get; set; }

        public bool HasMilk { get; set; }

        public bool HasSugar { get; set; }

        public bool HasCupCap { get; set; } 
    }
}
