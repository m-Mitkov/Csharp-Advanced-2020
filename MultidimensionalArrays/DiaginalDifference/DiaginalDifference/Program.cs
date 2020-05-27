using System;
using System.Collections.Generic;
using System.Linq;

namespace DiaginalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeMatrix, sizeMatrix];

            int firstDiagonal = 0;
            int secondDiagonal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }

                firstDiagonal += matrix[row, row];
                secondDiagonal += matrix[row, matrix.GetLength(0) - 1 - row];
            }

            int result = Math.Abs(firstDiagonal - secondDiagonal);
            Console.WriteLine(result);
        }
    }
}
