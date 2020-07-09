using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Beverages
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name)
            : base(name, 3.50M, 50)
        {
        }

        public Coffee(string name, decimal price, double milliters, double caffeine)
            : base(name, price, milliters)
        {
            this.Caffeine = caffeine;
            this.Price = CoffeePrice;
            this.Milliliters = CoffeeMilliliters;
        }

        public double CoffeeMilliliters => 50;
        public decimal CoffeePrice => 3.50M;
        public double Caffeine { get; set; }
    }
}
