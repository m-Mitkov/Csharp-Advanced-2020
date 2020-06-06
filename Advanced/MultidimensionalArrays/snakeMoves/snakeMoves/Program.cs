using System;
using System.Collections.Generic;
using System.Linq;

namespace snakeMoves
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
            char[,] matrix = new char[rows, cols];

            string snake = Console.ReadLine();

            Queue<char> snakeArgs = new Queue<char>(snake);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snakeArgs.Peek();
                        snakeArgs.Enqueue(snakeArgs.Dequeue());
                    }
                }

                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snakeArgs.Peek();
                        snakeArgs.Enqueue(snakeArgs.Dequeue());
                    }
                }
            }

            PrintMatrix(matrix);
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
