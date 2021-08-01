using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    /// <summary>
    /// Contains all data access code, logic for working with a data source
    /// </summary>
    public interface IRepository : IDisposable
    {
        IEnumerable<Coffee> GetCoffeeList();
        IEnumerable<CoffeeOrder> GetOrderList();

        void CreateOrder(CoffeeOrder item);
        void CreateCoffe(CoffeeOrder parentOrder, Coffee coffee);

        Coffee GetCoffee(long id);
        CoffeeOrder GetOrder(long id);

        void UpdateOrder(CoffeeOrder item);
        void UpdateCoffee(Coffee item);

        void DeleteOrder(long id);
        void DeleteCoffee(long id);

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
