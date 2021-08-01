using CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Services
{
    public class OrderService : IOrder
    {
        #region Private Fields

        private IRepository _repository;

        private IOrderValidate _orderValidate;

        #endregion

        #region Constructor

        public OrderService(IRepository repository, IOrderValidate orderValidate)
        {
            _repository = repository;
            _orderValidate = orderValidate;
        }

        #endregion

        #region Public Methods

        public bool CreateOrder(Coffee coffee, IOrderValidate validate)
        {
            // check the state of the model from the validation service
            if (!validate.Validate(coffee))
            {
                return false;
            }
            

            // creating a list of custom coffees
            var orderList = new List<Coffee> { coffee };

            // add coffees to order
            var order =
                new CoffeeOrder
                {
                    Coffees = orderList
                };

            _repository.CreateOrder(order);
            _repository.Save();

            return true;
        }

        public IEnumerable<Coffee> GetCoffeeList()
        {
            return _repository.GetCoffeeList();
        }

        public IEnumerable<CoffeeOrder> GetOrderList()
        {
            return _repository.GetOrderList();
        }

        #endregion
    }
}
