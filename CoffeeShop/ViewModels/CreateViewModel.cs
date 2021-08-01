using CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoffeeShop.ViewModels
{
    public class CreateViewModel
    {
        public SelectList CoffeeTypeSelectList { get; set; }

        public SelectList CoffeeVolumeSelectList { get; set; }

        public Coffee Coffee { get; set; }
    }
}
