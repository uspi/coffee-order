using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.Models
{
    [Table("Orders")]
    public class CoffeeOrder
    {
        public long Id { get; set; }

        public DateTimeOffset CreateAt { get; set; }

        public List<Coffee> Coffees { get; set; } = new List<Coffee>();

        public CoffeeOrder()
        {
            CreateAt = DateTime.UtcNow;
        }
    } 
}
