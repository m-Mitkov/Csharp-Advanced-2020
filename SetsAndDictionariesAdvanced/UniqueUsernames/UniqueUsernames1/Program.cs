using System;
using System.Collections.Generic;

namespace UniqueUsernames1
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();

            int numberOfInputNames = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputNames; i++)
            {
                string name = Console.ReadLine();

                names.Add(name);
            }

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
