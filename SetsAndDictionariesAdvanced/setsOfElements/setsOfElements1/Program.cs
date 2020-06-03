using System;
using System.Collections.Generic;
using System.Linq;

namespace setsOfElements1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> countNumbers = new Dictionary<int, int>();

            int[] setsInput = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int firstSet = setsInput[0];
            int secondSet = setsInput[1];

            for (int i = 0; i < firstSet + secondSet; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (!countNumbers.ContainsKey(currentNumber))
                {
                    countNumbers.Add(currentNumber, 1);
                    continue;
                }

                countNumbers[currentNumber]++;
            }

            Console.WriteLine(string.Join(" ", countNumbers.Where(x => x.Value > 1).Select(x => x.Key)));
        }
    }
}
