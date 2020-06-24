using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> elements;
        private int index;

        public ListyIterator(List<T> input)
        {
            this.elements = input;
            this.index = 0;
        }

        public bool HasNext()
        {
            if (index + 1 < elements.Count)
            {
                return true;
            }

            return false;
        }
        public bool Move()
        {
            if (HasNext())
            {
                this.index++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (elements.Any())
            {
                Console.WriteLine(elements[index]);
            }

            else
            {
                throw new IndexOutOfRangeException("Invalid Operation!");
            }
        }
    }
}
