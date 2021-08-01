using CoffeeShop.Angular.Models;

namespace CoffeeShop.Angular.Services
{
    /// <summary>
    /// Describes an order validation class template
    /// </summary>
    public interface IOrderValidate : IModelStateEditor, IValidate<Coffee>, IValidate<CoffeeOrder> { }
}
