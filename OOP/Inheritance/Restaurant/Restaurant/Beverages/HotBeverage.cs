﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Beverages
{
    public class HotBeverage : Beverage
    {
        public HotBeverage(string name, decimal price, double milliters)
            : base(name, price, milliters)
        {
        }
    }
}
