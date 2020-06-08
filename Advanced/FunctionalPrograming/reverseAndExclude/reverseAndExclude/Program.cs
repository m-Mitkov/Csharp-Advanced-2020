using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Reverse(inputNumbers);

            int divider = int.Parse(Console.ReadLine());

            Func<int, bool> isDivisible = x => x % divider != 0;

            Console.WriteLine(string.Join(" ", inputNumbers.Where((x, y) => isDivisible(x))));
        }
    }
}
