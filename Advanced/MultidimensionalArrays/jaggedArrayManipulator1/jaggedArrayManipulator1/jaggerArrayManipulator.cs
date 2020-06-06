using System;
using System.Collections.Generic;
using System.Linq;

namespace JaggedArrayManipulator1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[numberOfRows][];
            WriteMatrix(jaggedArray);
            AnalyzeArray(jaggedArray);

            while (true)
            {
                string[] comand = Console.ReadLine()
                    .Split(" ");

                string toDo = comand[0];

                if (toDo == "End")
                {
                    break;
                }

                int row = int.Parse(comand[1]);
                int col = int.Parse(comand[2]);
                double value = double.Parse(comand[3]);

                if (toDo == "Add")
                {
                    if (IndexValidator(jaggedArray, row, col))
                    {
                        jaggedArray[row][col] += value;
                    }
                }

                else if (toDo == "Subtract")
                {
                    if (IndexValidator(jaggedArray, row, col))
                    {
                        jaggedArray[row][col] -= value; 
                    }
                }
            }

            PrintMatrix(jaggedArray);
        }

        public static void PrintMatrix(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
        public static bool IndexValidator(double[][] jaggedArray, int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length
                && col >= 0 && col < jaggedArray[row].Length;
        }
        public static void AnalyzeArray(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }

                else
                {
                    for (int i = 0; i < jaggedArray[row].Length; i++)
                    {
                        jaggedArray[row][i] /= 2;
                    }

                    for (int j = 0; j < jaggedArray[row + 1].Length; j++)
                    {
                        jaggedArray[row + 1][j] /= 2;
                    }
                }
            }
        }
        public static void WriteMatrix(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                double[] input = Console.ReadLine()
                    .Split(" ")
                    .Select(double.Parse)
                    .ToArray();

                jaggedArray[row] = input;
            }
        }
    }
}
