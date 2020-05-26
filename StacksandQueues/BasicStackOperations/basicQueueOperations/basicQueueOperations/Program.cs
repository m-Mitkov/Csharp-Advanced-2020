using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] comandToFolow = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int countToEnqueue = comandToFolow[0];
            int countToDequeue = comandToFolow[1];
            int numberToLookFor = comandToFolow[2];

            int[] inputNumbersToEnqueue = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            inputNumbersToEnqueue.Reverse();

            Queue<int> queue = new Queue<int>(inputNumbersToEnqueue);

            for (int i = 0; i < countToDequeue; i++)
            {
                if (queue.Any())
                {
                    queue.Dequeue();
                }

                else
                {
                    break;
                }
            }

            if (queue.Any())
            {
                if (queue.Contains(numberToLookFor))
                {
                    Console.WriteLine("true");
                }

                else
                {
                    Console.WriteLine(queue.Min());
                }
            }

            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
