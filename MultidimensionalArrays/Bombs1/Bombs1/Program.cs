using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs1
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeMatrix, sizeMatrix];
            WriteMatrix(matrix);

            string[] inputCoordinatesBombs = Console.ReadLine()
                .Split(" ");

            foreach (var bombCoordinates in inputCoordinatesBombs)
            {
                string[] coordinates = bombCoordinates
                    .Split(",");

                int bombRow = int.Parse(coordinates[0]);
                int bombCol = int.Parse(coordinates[1]);

                BombExplosion(bombRow, bombCol, matrix);
                matrix[bombRow, bombCol] = 0;
            }

            int countAliveCells = 0;
            int sumAliveCells = 0;

            foreach (var element in matrix)
            {
                if (element > 0)
                {
                    countAliveCells++;
                    sumAliveCells += element;
                }
            }

            Console.WriteLine($"Alive cells: {countAliveCells}");
            Console.WriteLine($"Sum: {sumAliveCells}");

            PrintMatrix(matrix, ref countAliveCells, ref sumAliveCells);
        }
        public static void PrintMatrix(int[,] matrix, ref int countAliveCells, ref int sumAliveCells)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        countAliveCells++;
                        sumAliveCells += matrix[row, col];
                    }

                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
        public static void BombExplosion(int bombRow, int bombCol, int[,] matrix)
        {
            int bombStrength = matrix[bombRow, bombCol];

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    if (IndexValidator(matrix, bombRow + i, bombCol + j))
                    {
                        if (matrix[bombRow + i, bombCol + j] > 0) 
                        {
                            matrix[bombRow + i, bombCol + j] -= bombStrength; 
                        }
                    }
                }
            }
        }
        public static bool IndexValidator(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
        public static void WriteMatrix(int[,] matrix)
        {
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
            }
        }
    }
}
