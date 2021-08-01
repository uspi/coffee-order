using CoffeeShop.Angular.Models;
using System.Collections.Generic;

namespace CoffeeShop.Angular.Services
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
        bool CreateOrder(CoffeeOrder coffee, IOrderValidate validate);
        bool DeleteOrder(long id);
        CoffeeOrder GetOrder(long id);
        IEnumerable<Coffee> GetCoffeeList();
        IEnumerable<CoffeeOrder> GetOrderList();
    }
}
