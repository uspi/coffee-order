using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Models
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
        public void CreateOrder(CoffeeOrder item)
        {
            db.Orders.Add(item);
        }

        public void CreateCoffe(CoffeeOrder parentOrder, Coffee coffee)
        {
            throw new NotImplementedException();
        } 
        #endregion

        #region Delete Methods
        public void DeleteCoffee(long id)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(long id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Get Methods

        public Coffee GetCoffee(long id)
        {
            throw new NotImplementedException();
        }

        public CoffeeOrder GetOrder(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Coffee> GetCoffeeList()
        {
            throw new NotImplementedException();
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

        public void UpdateCoffee(Coffee item)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(CoffeeOrder item)
        {
            throw new NotImplementedException();
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
