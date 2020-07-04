using System;
using System.Text;
using System.Linq;

namespace CommandInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (true)
            {
                string[] comand = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (comand[0] == "end")
                {
                    break;
                }

                string toDo = comand[0];

                if (toDo == "reverse")
                {
                    int startIndex = int.Parse(comand[2]);
                    int countElements = int.Parse(comand[4]);

                    string[] subArray = GetRange(input, startIndex, countElements);
                    Array.Reverse(subArray);

                    for (int i = 0; i < countElements; i++)
                    {
                        input[startIndex + i] = subArray[i];
                    }
                }

                else if (toDo == "sort")
                {
                    int startIndex = int.Parse(comand[2]);
                    int countElements = int.Parse(comand[4]);

                    string[] subArray = GetRange(input, startIndex, countElements);
                    Array.Sort(subArray);

                    for (int i = 0; i < countElements; i++)
                    {
                        input[startIndex + i] = subArray[i];
                    }
                }

                else if (toDo == "rollLeft")
                {
                    int countTimes = int.Parse(comand[1]);
                    string[] manipulatedArray = new string[input.Length];

                    for (int i = 0; i < countTimes; i++)
                    {
                        string firstElement = input[0];

                        for (int j = 0; j < input.Length - 1; j++)
                        {
                            input[j] = input[j + 1];
                        }

                        input[input.Length - 1] = firstElement;
                    }
                }

                else if (toDo == "rollRight")
                {
                    int countTimes = int.Parse(comand[1]);
                    string[] manipulatedArray = new string[input.Length];

                    for (int i = 0; i < countTimes; i++)
                    {
                        string lastElement = input[input.Length - 1];

                        for (int j = input.Length - 1; j > 0; j--)
                        {
                            input[j] = input[j - 1];
                        }

                        input[0] = lastElement;
                    }
                }

                Console.WriteLine(string.Join(" ", input));
            }
        }
        public static string[] GetRange(string[] input, int startIndex, int countElements)
        {
            string[] subArr = input
                        .Skip(startIndex)
                        .Take(countElements)
                        .ToArray();

            return subArr;
        }
    }
}
