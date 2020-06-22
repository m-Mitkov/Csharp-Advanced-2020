using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethod
{
    class Box<T> where T : IComparable<T>
    {
        private List<T> values;
        public Box()
        {
            this.values = new List<T>();
        }
        public T Value { get; set; }

        public void Add(T value)
        {
            this.values.Add(value);
        }

        public int FilterTGreatherThanParameter(T parameter)
        {
            int countGreatherElements = 0;

            foreach (T item in this.values)
            {
                if (item.CompareTo(parameter) > 0)
                {
                    countGreatherElements++;
                }
            }

            return countGreatherElements;
        }
        public override string ToString()
        {
            return $"{Value.GetType()}: {this.Value}";
        }
    }
}
