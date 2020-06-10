using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            //var endNumberOfSequence = int.Parse(Console.ReadLine());

            //var numbers = Enumerable.Range(1, endNumberOfSequence > 0 ? endNumberOfSequence : 0);

            //var dividers = Console.ReadLine()
            //    .Split(" ")
            //    .Select(int.Parse)
            //    .ToArray();

            //Predicate<int> isDivisble = x => dividers.All(y => x % y == 0);

            //Console.Write(string.Join(" ", numbers.Where(x => isDivisble(x))));

            var endNumberSequence = int.Parse(Console.ReadLine());

            Func<int, int, bool> isDivisible = (x, y) => x % y == 0;

            var dividers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            for (int i = 1; i <= endNumberSequence; i++)
            {
               bool Divisible = true; 

                foreach (var item in dividers)
                {
                    if (!isDivisible(i, item))
                    {
                        Divisible = false;
                        break;
                    }
                }

                if (Divisible)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
