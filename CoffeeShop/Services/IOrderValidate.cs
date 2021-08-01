using CoffeeShop.Models;

namespace CoffeeShop.Services
{
    /// <summary>
    /// Describes an order validation class template
    /// </summary>
    public interface IOrderValidate 
        : IModelStateEditor, IValidate<Coffee>, IValidate<CoffeeOrder> 
    { 
    }
}
