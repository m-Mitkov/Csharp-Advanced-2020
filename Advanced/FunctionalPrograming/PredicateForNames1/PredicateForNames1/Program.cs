using System;
using System.Linq;

namespace PredicateForNames1
{
    class Program
    {
        static void Main(string[] args)
        {
            int allowedLenghtName = int.Parse(Console.ReadLine());

            Func<string, bool> lenghtChecker = x => x.Length <= allowedLenghtName;
            
            string[] names = Console.ReadLine()
                .Split(" ");

            Console.WriteLine(string.Join(Environment.NewLine, names.Where(x => lenghtChecker(x))));
        }
    }
}
