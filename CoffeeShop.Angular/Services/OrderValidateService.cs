using CoffeeShop.Angular.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoffeeShop.Angular.Services
{
    public class OrderValidateService : IOrderValidate
    {
        #region Private Fields

        public ModelStateDictionary ModelState { get; private set; }

        #endregion

        #region Public Properties

        public bool IsValid => this.ModelState.IsValid;

        #endregion

        #region Public Methods

        public void AddError(string key, string errorMessage)
        {
            this.ModelState.AddModelError(key, errorMessage);
        }

        public void SetModelState(ModelStateDictionary modelState)
        {
            this.ModelState = modelState;
        }

        public bool Validate(Coffee element)
        {
            //if volume not selected(0 = none)
            if (element.CoffeeVolume == 0)
            {
                AddError(nameof(CoffeeVolume), "Please select the volume");
            }

            // if type not selected(0 = none)
            if (element.CoffeeType == 0)
            {
                AddError(nameof(CoffeeType), "Please select the type");
            }

            #region Only americano 500 milileters
            // if not americano ...
            if (element.CoffeeType != CoffeeType.Americano
                // ... and volume 500
                && element.CoffeeVolume == CoffeeVolume.Large
                // ... and enum is not none
                && element.CoffeeVolume != 0)
            {
                AddError(nameof(CoffeeVolume),
                    // cast volume to liters
                    $"{element.CoffeeVolume?.GetElementName(c => ((double)c / 1000).ToString())} only for americano");
            }
            #endregion

            #region Milk americano only
            // if not americano ...
            if (element.CoffeeType != CoffeeType.Americano
                // ... and has milk
                && element.HasMilk == true
                // ... and enum is not none
                && element.CoffeeType != 0)
            {
                AddError(nameof(element.HasMilk), "Americano only");
            }

            #endregion

            return IsValid;
        }

        // if one of the order list did not
        // pass the validation all do not pass 
        public bool Validate(CoffeeOrder element)
        {
            bool validationStatus = true;

            // check all coffees of order list
            foreach (var item in element.Coffees)
            {
                // if coffee not valid
                if (!this.Validate(item))
                {
                    validationStatus = false;
                }

                // continue validation
            }

            return validationStatus;
        }
        #endregion
    }
}
