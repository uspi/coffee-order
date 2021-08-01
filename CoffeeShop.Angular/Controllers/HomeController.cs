using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Angular.Models;
using CoffeeShop.Angular.Services;
using Newtonsoft.Json;

namespace CoffeeShop.Angular.Controllers
{
    [Produces("application/json")]
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : Controller
    {
        #region Private Fields

        private IOrder _orderService;
        private IOrderValidate _validate;

        private readonly ILogger<OrdersController> _logger;

        #endregion

        #region Constructor

        public OrdersController(
            ILogger<OrdersController> logger, 
            IOrder orderService, 
            IOrderValidate orderValidateService)
        {
            // set the service for work with coffee orders
            _orderService = orderService;

            // set model state for validation context
            _validate = orderValidateService;

            // set logger for controller
            _logger = logger;

            #region Dummy Data
            // if db empty
            if (_orderService.GetOrderList().Count() == 0)
            {
                // add start data

                //var variation1 = new Americano(CoffeeVolume.Large, 2, true, true);
                //var variation2 = new Americano(CoffeeVolume.Medium, 1, true);
                //var variation3 = new Americano(CoffeeVolume.Large, 0, false, true);

                //var variation4 = new Espresso(CoffeeVolume.Medium, 0, true);
                //var variation5 = new Espresso(CoffeeVolume.Small, 2);
                //var variation6 = new Espresso(CoffeeVolume.Medium, 0);

                //var variation7 = new Latte(CoffeeVolume.Small, 0, true);
                //var variation8 = new Latte(CoffeeVolume.Small, 3);
                //var variation9 = new Latte(CoffeeVolume.Medium, 0);

                //// add created variations
                //db.Orders.AddRange(
                //    new CoffeeOrder { CoffeeVariety = variation1 },
                //    new CoffeeOrder { CoffeeVariety = variation2 },
                //    new CoffeeOrder { CoffeeVariety = variation3 },

                //    new CoffeeOrder { CoffeeVariety = variation4 },
                //    new CoffeeOrder { CoffeeVariety = variation5 },
                //    new CoffeeOrder { CoffeeVariety = variation6 },

                //    new CoffeeOrder { CoffeeVariety = variation7 },
                //    new CoffeeOrder { CoffeeVariety = variation8 },
                //    new CoffeeOrder { CoffeeVariety = variation9 }
                //    );




                // coffee variations
                var variation1 = new Coffee
                {
                    CoffeeType = CoffeeType.Americano,
                    CoffeeVolume = CoffeeVolume.Large,
                    HasMilk = true,
                    HasCupCap = true,
                    QuantitySugarTeaspoons = 3
                };
                var variation12 = new Coffee
                {
                    CoffeeType = CoffeeType.Americano,
                    CoffeeVolume = CoffeeVolume.Large,
                    HasMilk = true,
                    HasCupCap = true,
                    QuantitySugarTeaspoons = 3
                };
                var variation2 = new Coffee
                {
                    CoffeeType = CoffeeType.Espresso,
                    CoffeeVolume = CoffeeVolume.Small,
                    HasMilk = false,
                    HasCupCap = true,
                    QuantitySugarTeaspoons = 0
                };
                var variation3 = new Coffee
                {
                    CoffeeType = CoffeeType.Latte,
                    CoffeeVolume = CoffeeVolume.Medium,
                    HasMilk = false,
                    HasCupCap = false,
                    QuantitySugarTeaspoons = 1
                };

                // order lists
                var orderList1 = new List<Coffee>
                {
                    variation1,
                    variation2,
                    variation3
                };
                var orderList2 = new List<Coffee>
                {
                    variation12
                };
                var orderList3 = new List<Coffee>
                {
                    variation1,
                    variation2
                };

                // coffee orders
                var coffeeOrder1 = new CoffeeOrder { Coffees = orderList1 };
                var coffeeOrder2 = new CoffeeOrder { Coffees = orderList2 };

                var coffeeOrder3 = new CoffeeOrder { Coffees = orderList3 };

                //_orderService.AddRange(coffeeOrder1, coffeeOrder2);

                //db.Variations.AddRange(orderList1);
                //db.Variations.AddRange(orderList2);
                //db.Variations.AddRange(orderList3);

                // save changes directly in db
                //db.SaveChanges(); 
                

            }
            #endregion
        }
        #endregion

        [HttpGet]
        public IEnumerable<CoffeeOrder> Get()
        {
            return _orderService.GetOrderList();
        }

        [HttpGet("{id}")]
        public CoffeeOrder Get(int id)
        {
            return _orderService.GetOrder(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] object order)
        {
            var newOrder = 
                JsonConvert.DeserializeObject<CoffeeOrder>(order.ToString());

            // set the context of this post request 
            _validate.SetModelState(this.ModelState);

            // if some validation errors
            if (!_orderService.CreateOrder(newOrder, _validate))
            {
                return BadRequest(_validate.ModelState);
            }

            return Ok(order);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var order = _orderService.GetOrder(id);

            // if fail
            if (!_orderService.DeleteOrder(id))
            {
                return BadRequest("Deletion Failed");
            }

            return Ok(order);
        }
    }
}
