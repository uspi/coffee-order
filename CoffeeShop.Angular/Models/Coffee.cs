using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Angular.Models
{
    public class Coffee : ICoffeeVariation
    {
        [Key]
        public long Id { get; set; }

        public CoffeeOrder CoffeeOrder { get; set; }

        [Required(ErrorMessage = "Please select the type")]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("coffeeType")]
        public CoffeeType? CoffeeType { get; set; }

        // volume in liters
        [Required(ErrorMessage = "Please select the volume")]
        [JsonProperty("coffeeVolume")]
        public CoffeeVolume? CoffeeVolume { get; set; }

        [Required(ErrorMessage = "Please set the quantity of teaspoons")]
        [JsonProperty("quantitySugarTeaspoons")]
        public byte? QuantitySugarTeaspoons { get; set; }

        [JsonProperty("hasMilk")]
        public bool HasMilk { get; set; }

        [JsonProperty("hasSugar")]
        public bool HasSugar { get; set; }
        //{
        //    get => QuantitySugarTeaspoons == 0 ? false : true;
        //    set => HasSugar = value;
        //}

        [JsonProperty("hasCupCap")]
        public bool HasCupCap { get; set; }
    }
}
