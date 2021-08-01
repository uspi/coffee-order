using CoffeeShop.Angular.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Angular.Services
{
    public class SqlRepository : IRepository
    {
        #region Private Fields
        private DataContext db;
        #endregion

        #region Constructor
        public SqlRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var dbContextOptions =
                new DbContextOptionsBuilder<DataContext>()
                    .UseSqlServer(connectionString)
                    .Options;

            this.db = new DataContext(dbContextOptions);
        }
        #endregion

        #region Create Methods
        public bool CreateOrder(CoffeeOrder item)
        {
            try
            {
                db.Orders.Add(item);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool CreateCoffee(long parentOrderId, Coffee coffee)
        {
            // get order
            CoffeeOrder order = db.Orders
                .Include(o => o.Coffees)
                .FirstOrDefault(i => i.Id == parentOrderId);

            // checks
            if (order == null)
            {
                return false;
            }

            // add order reference
            coffee.CoffeeOrder = order;

            // add
            try
            {
                db.Variations.Add(coffee);
            }
            catch
            {
                return false;
            }

            return true;
        } 
        #endregion

        #region Delete Methods
        public bool DeleteCoffee(long id)
        {
            // get coffee object
            Coffee coffee = db.Variations
                .Include(o => o.CoffeeOrder)
                .FirstOrDefault(c => c.Id == id);

            // checks
            if (coffee == null)
            {
                return false;
            }
            if (coffee.CoffeeOrder == null)
            {
                return false;
            }

            // remove
            try
            {
                db.Variations.Remove(coffee);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool DeleteOrder(long id)
        {
            // get order object
            CoffeeOrder order = db.Orders.FirstOrDefault(o => o.Id == id);
            
            // checks
            if (order == null)
            {
                return false;
            }

            // remove
            try
            {
                db.Orders.Remove(order);
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Get Methods

        public Coffee GetCoffee(long id)
        {
            return db.Variations.FirstOrDefault(v => v.Id == id);
        }

        public CoffeeOrder GetOrder(long id)
        {
            return db.Orders.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Coffee> GetCoffeeList()
        {
            return db.Variations.ToList();
        }

        public IEnumerable<CoffeeOrder> GetOrderList()
        {
            // add data from variations table
            var ordersSource = db.Orders.Include(o => o.Coffees);

            // queryable to list
            var ordersList = ordersSource
                // new first
                .OrderByDescending(o => o.CreateAt)
                .ToList();

            return ordersList;
        }

        #endregion

        #region Update Methods

        public bool UpdateCoffee(Coffee item)
        {
            try
            {
                db.Variations.Update(item);
            }
            catch
            {
                return false;
            }
            
            return true;
        }

        public bool UpdateOrder(CoffeeOrder item)
        {
            try
            {
                db.Orders.Update(item);
            }
            catch
            {
                return false;
            }
            
            return true;
        }

        #endregion

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
