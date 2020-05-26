using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfComandToFollow = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numberOfComandToFollow; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()                              //1 - Push, 2 - Delete/pop
                    .Select(int.Parse)                    // 3 - PrintMax, 4 - printMin
                    .ToArray();

                int toDo = input[0];

                if (toDo == 1)
                {
                    stack.Push(input[1]);
                }

                else if (toDo == 2)
                {
                    if (stack.Any())
                    {
                        stack.Pop();
                    }
                }

                else if (toDo == 3)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Max());
                    }
                }

                else if (toDo == 4)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
