using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> uniqueElements = new SortedSet<string>();

            int numberOfInputsToFollow = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputsToFollow; i++)
            {
                string[] currentInput = Console.ReadLine()
                    .Split(" ");

                foreach (var element in currentInput)
                {
                    uniqueElements.Add(element);
                }
                    
            }

            Console.Write(string.Join(" ", uniqueElements)); ;
        }
    }
}
