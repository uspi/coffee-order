using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoffeeShop.Services
{
    /// <summary>
    /// Allows you to get the state of the model and add errors. 
    /// <see cref="SetModelState(ModelStateDictionary)"/> 
    /// - instead of a constructor.
    /// </summary>
    public interface IModelStateEditor
    {
        // private ModelStateDictionary _modelState
        bool IsValid { get; }
        void SetModelState(ModelStateDictionary modelState);
        void AddError(string key, string errorMessage);
    }
}
