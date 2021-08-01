
namespace CoffeeShop.Models
{
    public interface ICoffeeVariation
    {
        public CoffeeType? CoffeeType { get; set; }

        // volume in milliliters
        public CoffeeVolume? CoffeeVolume { get; set; }

        public byte? QuantitySugarTeaspoons { get; set; }

        public bool HasMilk { get; set; }

        public bool HasSugar { get; set; }

        public bool HasCupCap { get; set; }
    }
}
