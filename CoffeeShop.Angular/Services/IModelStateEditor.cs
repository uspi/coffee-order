using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoffeeShop.Angular.Services
{
    /// <summary>
    /// Allows you to get the state of the model and add errors. 
    /// <see cref="SetModelState(ModelStateDictionary)"/> 
    /// - instead of a constructor.
    /// </summary>
    public interface IModelStateEditor
    {
        ModelStateDictionary ModelState { get; }
        bool IsValid { get; }
        void SetModelState(ModelStateDictionary modelState);
        void AddError(string key, string errorMessage);
    }
}
