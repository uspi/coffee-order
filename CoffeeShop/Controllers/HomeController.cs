using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Models;
using CoffeeShop.Services;
using CoffeeShop.ViewModels;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        #region Private Fields

        private IOrder _orderService;
        private IOrderValidate _orderValidateService;

        private readonly ILogger<HomeController> _logger;

        #endregion

        #region Constructor

        public HomeController(
            ILogger<HomeController> logger,
            IOrder orderService,
            IOrderValidate orderValidateService
            )
        {
            // set the service for work with coffee orders
            _orderService = orderService;

            // set model state for validation context
            _orderValidateService = orderValidateService;

            // set logger for controller
            _logger = logger;

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
        }
        #endregion

        #region Http Get Methods
        [HttpGet]
        // all orders page
        public IActionResult Orders()
        {
            var ordersList = _orderService.GetOrderList().ToList();

            // create orders page view model
            var viewModel = new OrdersViewModel
            {
                Orders = ordersList
            };

            //return View();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpGet]
        public IActionResult OrderPage()
        {
            // show order page
            return View();
        }

        public IActionResult OrderDone()
        {
            return View();
        }
        #endregion

        #region Http Post Methods

        // create new order
        [HttpPost]
        public IActionResult Create(Coffee coffee)
        {
            // set the context of this post request 
            _orderValidateService.SetModelState(this.ModelState);

            // if some validation errors
            if (!_orderService.CreateOrder(coffee, _orderValidateService))
            {
                // show validation errors
                return View();
            }

            return RedirectToAction("OrderDone");
        }
        #endregion
    }
}
