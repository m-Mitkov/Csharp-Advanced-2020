using System;
using System.Collections.Generic;
using System.Text;

namespace Person1
{
    public class Person
    {
        protected int age;
        protected string name;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public virtual int Age
        {
            get { return age; }
            protected set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Age cannot be a negative number!");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }

    }
}
