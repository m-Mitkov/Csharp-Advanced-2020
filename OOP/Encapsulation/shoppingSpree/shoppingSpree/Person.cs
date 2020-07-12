using System;
using System.Collections.Generic;
using System.Linq;

namespace shoppingSpree
{
    class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagProducts = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be an empty");
                }

                this.name = value;
            }
        }
        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public string BuyProduct(Product product)
        {
            if (this.money - product.Cost >= 0)
            {
                this.bagProducts.Add(product);
                this.money -= product.Cost;

                return $"{this.Name} bought {product.Name}";
            }

            return $"{this.Name} can't afford {product.Name}";
        }

        public override string ToString()
        {
            if (bagProducts.Count != 0)
            {
                return $"{this.name} - {string.Join(", ", this.bagProducts.Select(x => x.Name))}";
            }

            return $"{this.name} - Nothing bought";
        }
    }
}
