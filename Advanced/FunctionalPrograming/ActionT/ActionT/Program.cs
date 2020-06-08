using System;
using System.Linq;

namespace ActionT
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = s => Console.WriteLine(s);

            Console.ReadLine()
                           .Split(" ")
                           .ToList()
                           .ForEach(print);
        }
    }
}
