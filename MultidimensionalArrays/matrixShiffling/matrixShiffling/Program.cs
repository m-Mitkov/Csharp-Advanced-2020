using System;
using System.Collections.Generic;
using System.Linq;

namespace matrixShiffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int rows = sizeMatrix[0];
            int cols = sizeMatrix[1];

            string[,] matrix = new string[rows, cols];
            WriteMatrix(matrix);

            while (true)
            {
                string[] comand = Console.ReadLine()
                    .Split(" ");

                string toDo = comand[0];

                if (toDo == "END")
                {
                    break;
                }

                if (toDo == "swap" && comand.Length == 5)
                {
                    int firstRowSwap = int.Parse(comand[1]);
                    int firstColSwap = int.Parse(comand[2]);

                    int secondRowSwap = int.Parse(comand[3]);
                    int secondColSwap = int.Parse(comand[4]);

                    if (IndexValidator(matrix, firstRowSwap, firstColSwap) &&
                        IndexValidator(matrix, secondRowSwap, secondColSwap))
                    {
                        string temporary = matrix[firstRowSwap, firstColSwap];

                        matrix[firstRowSwap, firstColSwap] = matrix[secondRowSwap, secondColSwap];
                        matrix[secondRowSwap, secondColSwap] = temporary;

                        PrintMatrix(matrix);
                    }

                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        public static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
        public static bool IndexValidator(string[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
        public static void WriteMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
