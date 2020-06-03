using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = sizeMatrix[0];
            int cols = sizeMatrix[1];

            char[,] matrix = new char[rows, cols];

            int playerRow = -1;
            int playerCol = -1;

            bool playerDead = false;
            bool playerEscapeField = false;

            WriteMatrix(matrix, ref playerRow, ref playerCol);

            string directionsInput = Console.ReadLine();

            for (int i = 0; i < directionsInput.Length; i++)
            {
                char currentDirection = directionsInput[i];

                int newRowPlayer = playerRow;
                int newColPlayer = playerCol;

                if (currentDirection == 'U')
                {
                    newRowPlayer -= 1;

                    if (!playerEscapeField)
                    {
                        playerRow = newRowPlayer;
                    }
                }

                else if (currentDirection == 'D')
                {
                    newRowPlayer += 1;

                    if (!playerEscapeField)
                    {
                        playerRow = newRowPlayer;
                    }
                }

                else if (currentDirection == 'L')
                {
                    newColPlayer -= 1;


                    if (!playerEscapeField)
                    {
                        playerCol = newColPlayer;
                    }
                }

                else if (currentDirection == 'R')
                {
                    newColPlayer += 1;

                    if (!playerEscapeField)
                    {
                        playerCol = newColPlayer;
                    }
                }

                MovePlayer(matrix, newRowPlayer, newColPlayer, ref playerDead, ref playerEscapeField);

                if (!playerEscapeField)
                {
                    playerRow = newRowPlayer;
                    playerCol = newColPlayer;
                    matrix[playerRow, playerCol] = '.';
                }

                SpreadBunnies(matrix, ref playerDead);

                if (playerDead || playerEscapeField)
                {
                    break;
                }
            }

            PrintMatrix(matrix);

            if (playerDead)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }

            if (playerEscapeField)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
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
        public static void SpreadBunnies(char[,] matrix, ref bool playerDead)
        {
            List<int> bunniesIndexes = new List<int>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunniesIndexes.Add(row);
                        bunniesIndexes.Add(col);
                    }
                }
            }

            for (int i = 0; i < bunniesIndexes.Count - 1; i += 2)
            {
                int bunnieRow = bunniesIndexes[i];
                int bunnieCol = bunniesIndexes[i + 1];

                if (IndexValidator(matrix, bunnieRow - 1, bunnieCol + 0))
                {
                    if (matrix[bunnieRow - 1, bunnieCol] == 'P')
                    {
                        matrix[bunnieRow - 1, bunnieCol] = 'B';
                        playerDead = true;
                    }

                    matrix[bunnieRow - 1, bunnieCol] = 'B';
                }

                if (IndexValidator(matrix, bunnieRow + 1, bunnieCol + 0))
                {
                    if (matrix[bunnieRow + 1, bunnieCol] == 'P')
                    {
                        matrix[bunnieRow + 1, bunnieCol] = 'B';
                        playerDead = true;
                    }

                    matrix[bunnieRow + 1, bunnieCol] = 'B';
                }

                if (IndexValidator(matrix, bunnieRow, bunnieCol - 1))
                {
                    if (matrix[bunnieRow, bunnieCol - 1] == 'P')
                    {
                        matrix[bunnieRow, bunnieCol - 1] = 'B';
                        playerDead = true;
                    }

                    matrix[bunnieRow, bunnieCol - 1] = 'B';
                }

                if (IndexValidator(matrix, bunnieRow, bunnieCol + 1))
                {
                    if (matrix[bunnieRow, bunnieCol + 1] == 'P')
                    {
                        matrix[bunnieRow, bunnieCol + 1] = 'B';
                        playerDead = true;
                    }

                    matrix[bunnieRow, bunnieCol + 1] = 'B';
                }
            }
        }
        public static void MovePlayer(char[,] matrix, int playerRow, int playerCol, ref bool playerDead,
            ref bool playerEscapeField)
        {
            if (IndexValidator(matrix, playerRow, playerCol)
                        && matrix[playerRow, playerCol] != 'B')
            {
                matrix[playerRow, playerCol] = 'P';
            }

            else if (!IndexValidator(matrix, playerRow, playerCol))
            {
                playerEscapeField = true;
            }

            else
            {
                playerDead = true;
            }
        }
        public static bool IndexValidator(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
        public static void WriteMatrix(char[,] matrix, ref int playerRow, ref int playerCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}
