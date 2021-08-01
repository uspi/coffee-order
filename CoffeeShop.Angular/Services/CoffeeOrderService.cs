using CoffeeShop.Angular.Models;
using System.Collections.Generic;

namespace CoffeeShop.Angular.Services
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

        public bool CreateOrder(CoffeeOrder coffee, IOrderValidate validate)
        {
            // check the state of the model from the validation service
            if (!validate.Validate(coffee))
            {
                // fail
                return false;
            }

            // if fail
            if (!_repository.CreateOrder(coffee))
            {
                return false;
            }

            _repository.Save();

            // successfully
            return true;
        }

        public bool DeleteOrder(long id)
        {
            return _repository.DeleteOrder(id);
        }

        public IEnumerable<Coffee> GetCoffeeList()
        {
            return _repository.GetCoffeeList();
        }

        public CoffeeOrder GetOrder(long id)
        {
            return _repository.GetOrder(id);
        }

        public IEnumerable<CoffeeOrder> GetOrderList()
        {
            return _repository.GetOrderList();
        }

        #endregion
    }
}
