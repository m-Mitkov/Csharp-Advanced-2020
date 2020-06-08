using System;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string> appendSIR = x => $"Sir {x}";

            string[] input = Console.ReadLine()
                .Split(" ");

            foreach (var item in input)
            {
                Console.WriteLine(appendSIR(item));
            }
        }
    }
}
