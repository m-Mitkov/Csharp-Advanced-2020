using System;
using System.Collections.Generic;
using System.Linq;

namespace maximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizeMatrix[0];
            int cols = sizeMatrix[1];

            int[,] matrix = new int[rows, cols];
            WriteMatrix(matrix);

            int subMatrixRow = 3;
            int subMatrixCol = 3;

            int bestSum = 0;
            int bestRowIndex = -1;
            int bestColIndex = -1;

            for (int row = 0; row <= matrix.GetLength(0) - subMatrixRow; row++)
            {

                for (int col = 0; col <= matrix.GetLength(1) - subMatrixCol; col++)
                {
                    int currentBestSum = 0;

                    for (int subRow = 0; subRow < subMatrixRow; subRow++)
                    {
                        for (int subCol = 0; subCol < subMatrixCol; subCol++)
                        {
                            currentBestSum += matrix[row + subRow, col + subCol];
                        }
                    }

                    if (currentBestSum > bestSum)
                    {
                        bestSum = currentBestSum;
                        bestRowIndex = row;
                        bestColIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {bestSum}");

            for (int row = bestRowIndex; row < bestRowIndex + subMatrixRow; row++)
            {
                for (int col = bestColIndex; col < bestColIndex + subMatrixCol; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        public static void WriteMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
