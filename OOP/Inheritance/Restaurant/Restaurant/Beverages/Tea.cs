﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Beverages
{
    public class Tea : HotBeverage
    {
        public Tea(string name, decimal price, double milliters) 
            : base(name, price, milliters)
        {
        }
    }
}
