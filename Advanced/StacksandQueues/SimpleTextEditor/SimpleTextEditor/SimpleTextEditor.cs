using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());
            StringBuilder currentString = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            stack.Push(currentString.ToString());

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] comand = Console.ReadLine()
                    .Split(" ");

                string toDo = comand[0];

                if (toDo == "1") // appends string to the end
                {
                    currentString.Append(comand[1]);
                    stack.Push(currentString.ToString());
                }

                else if (toDo == "2") // delete last count elements
                {
                    int countElementsToDelete = int.Parse(comand[1]);
                    currentString = currentString
                        .Remove(currentString.Length - countElementsToDelete, countElementsToDelete);
                    stack.Push(currentString.ToString());
                }

                else if (toDo == "3") // return the element at index
                {
                    int index = int.Parse(comand[1]);

                    Console.WriteLine(currentString[index - 1]);
                }

                else if (toDo == "4") // return one step back on comand 1 or 2
                {
                    stack.Pop();
                    currentString.Clear();
                    currentString.Append(stack.Peek());
                }
            }
        }
    }
}
