using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Foods
{
    public class Cake : Dessert
    {
        private decimal price = 5;
        private double grams = 250;
        private double calories = 1000;

        public Cake(string name)
            : base(name, 5, 250, 1000)
        {

        }
        public Cake(string name, decimal price, double grams, double calories)
            : base(name, price, grams, calories)
        {
            //base.Price = this.price;
            //base.Grams = this.grams;
            //base.Calories = this.calories;
        }
    }
}
