using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] comandToFolow = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int countToPush = comandToFolow[0];
            int countToPop = comandToFolow[1];
            int numberToLookFor = comandToFolow[2];

            int[] inputNumbersToPush = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(inputNumbersToPush);

            for (int i = 0; i < countToPop; i++)
            {
                if (stack.Any())
                {
                    stack.Pop();
                }

                else
                {
                    break;
                }
            }

            if (stack.Any())
            {
                if (stack.Contains(numberToLookFor))
                {
                    Console.WriteLine("true");
                }

                else
                {
                    Console.WriteLine(stack.Min());
                }
            }

            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
