using CoffeeShop.Helpers;
using CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace CoffeeShop.Services
{
    public class OrderValidateService : IOrderValidate
    {
        #region Private Fields

        private ModelStateDictionary _modelState;

        #endregion

        #region Public Properties

        public bool IsValid => _modelState.IsValid;

        #endregion

        #region Public Methods

        public void AddError(string key, string errorMessage)
        {
            _modelState.AddModelError(key, errorMessage);
        }

        public void SetModelState(ModelStateDictionary modelState)
        {
            _modelState = modelState;
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

        public bool Validate(CoffeeOrder element)
        {
            // coffee order validation logic here

            return false;
        }
        #endregion
    }
}
