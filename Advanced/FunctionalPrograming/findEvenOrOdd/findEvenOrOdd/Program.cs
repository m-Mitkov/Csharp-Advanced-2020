using System;
using System.Linq;

namespace FindEvenOrOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> findEvenNumbers = x => x % 2 == 0;
            Func<int, bool> findOddNumbers = x => x % 2 != 0;

            int[] range = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int start = range[0];
            int end = range[1];

            int[] numbers = new int[end - start + 1];
            int counter = 0;

            for (int i = start; i <= end; i++)
            {
                numbers[counter] = i;
                counter++;
            }

            string condition = Console.ReadLine();

            if (condition == "even")
            {
                Console.WriteLine(string.Join(" ", numbers.Where(findEvenNumbers)));
            }

            else
            {
                Console.WriteLine(string.Join(" ",numbers.Where(findOddNumbers)));
            }
        }
    }
}
