using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Beverages
{
    public class ColdBeverage : Beverage
    {
        public ColdBeverage(string name, decimal price, double milliters)
            : base(name, price, milliters)
        {
        }
    }
}
