using CoffeeShop.Models;
using System.Collections.Generic;

namespace CoffeeShop.Services
{
    /// <summary>
    /// The service provides a layer of communication between the 
    /// controller and the repository, provides access to data.
    /// </summary>
    public interface IOrder
    {
        // private IRepository _repository;
        // IOrderModelValidate _orderValidate;
        bool CreateOrder(Coffee coffee, IOrderValidate validate);
        IEnumerable<Coffee> GetCoffeeList();
        IEnumerable<CoffeeOrder> GetOrderList();
    }
}
