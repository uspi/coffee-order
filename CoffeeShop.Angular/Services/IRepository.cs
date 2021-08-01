using CoffeeShop.Angular.Models;
using System;
using System.Collections.Generic;

namespace CoffeeShop.Angular.Services
{
    /// <summary>
    /// Contains all data access code, logic for working with a data source
    /// </summary>
    public interface IRepository : IDisposable
    {
        IEnumerable<Coffee> GetCoffeeList();
        IEnumerable<CoffeeOrder> GetOrderList();

        bool CreateOrder(CoffeeOrder item);
        bool CreateCoffee(long parentOrderId, Coffee coffee);

        Coffee GetCoffee(long id);
        CoffeeOrder GetOrder(long id);

        bool UpdateOrder(CoffeeOrder item);
        bool UpdateCoffee(Coffee item);

        bool DeleteOrder(long id);
        bool DeleteCoffee(long id);

        void Save();
    }

    

    ///// <summary>
    ///// Contains all data access code, logic for working with a data source
    ///// </summary>
    ///// <typeparam name="T">The entity that is expected to be 
    ///// received from the data source</typeparam>
    //public interface IRepository<T> : IDisposable
    //{
    //    IEnumerable<T> GetList();

    //    T GetElement(long id);

    //    void Create(T item);

    //    void Update(T item);

    //    void Delete(long id);

    //    void Save();
    //}
}
