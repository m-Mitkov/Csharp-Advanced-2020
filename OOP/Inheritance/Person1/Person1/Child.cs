using System;
using System.Collections.Generic;
using System.Text;

namespace Person1
{
    public class Child : Person
    {
        public Child(string name, int age)
            : base(name, age)
        {
        }

        public override int Age
        {
            get => base.Age;
            protected set
            {
                if (value > 15)
                {
                    throw new IndexOutOfRangeException("Child age cannot be greather than 15!");
                }

                base.Age = value;
            }
        }
    }
}
