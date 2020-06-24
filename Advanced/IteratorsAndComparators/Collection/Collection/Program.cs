using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {

            ListyIterator<string> listyIterator = null;

            string[] command = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "Create": listyIterator = new ListyIterator<string>(command.Skip(1).ToList()); break;

                    case "Move": Console.WriteLine(listyIterator.Move()); break;

                    case "HasNext": Console.WriteLine(listyIterator.HasNext()); break;

                    case "PrintAll": Console.Write(string.Join(" ", listyIterator));
                        Console.WriteLine(); break;

                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }


                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);

                        }

                        break;
                }
                command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
