using System;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> add = x => x + 1; // +1 by requirement
            Func<int, int> multiply = x => x * 2;
            Func<int, int> subtract = x => x - 1;

            int[] inputNumbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string toDo = Console.ReadLine();

                if (toDo == "end")
                {
                    break;
                }

                switch (toDo)
                {
                    case "add":
                        inputNumbers = inputNumbers.Select(x => add(x)).ToArray(); break;
                    case "multiply":
                        inputNumbers = inputNumbers.Select(x => multiply(x)).ToArray(); break;
                    case "subtract":
                        inputNumbers = inputNumbers.Select(x => subtract(x)).ToArray(); break;
                    case "print":
                        Console.WriteLine(string.Join(" ", inputNumbers)); 
                        break;
                }
            }
        }
    }
}
