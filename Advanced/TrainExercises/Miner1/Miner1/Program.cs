using System;
using System.Linq;

namespace Miner1
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            string[] inputMovingComands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = new char[sizeMatrix, sizeMatrix];

            int totalAmountCoals = 0;
            int playerRow = -1;
            int playerCol = -1;
            bool playerDead = false;

            FillMatrix(matrix, ref totalAmountCoals, ref playerRow, ref playerCol);

            for (int i = 0; i < inputMovingComands.Length; i++)
            {
                string direction = inputMovingComands[i];
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                switch (direction)
                {
                    case "up":
                        newPlayerRow -= 1;
                        break;

                    case "down":
                        newPlayerRow += 1;
                        break;

                    case "left":
                        newPlayerCol -= 1;
                        break;

                    case "right":
                        newPlayerCol += 1;
                        break;
                }

                MovePlayer(matrix, newPlayerRow, newPlayerCol, ref totalAmountCoals, ref playerDead);

                if (totalAmountCoals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({newPlayerRow}, {newPlayerCol})");
                    return;
                }

                if (playerDead)
                {
                    Console.WriteLine($"Game over! ({newPlayerRow}, {newPlayerCol})");
                    return;
                }

                if (IndexValidator(matrix, newPlayerRow, newPlayerCol))
                {
                    matrix[playerRow, playerCol] = '*';
                    matrix[newPlayerRow, newPlayerCol] = 's';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }
            }

            Console.WriteLine($"{totalAmountCoals} coals left. ({playerRow}, {playerCol})");
        }

        public static void MovePlayer(char[,] matrix, int playerRow, int playerCol, ref int coals, ref bool playerDead)
        {
            if (IndexValidator(matrix, playerRow, playerCol))
            {
                if (matrix[playerRow, playerCol] == 'c')
                {
                    coals--;
                }

                if (matrix[playerRow, playerCol] == 'e')
                {
                    playerDead = true;
                }
            }
        }

        public static bool IndexValidator(char[,] matrix, int playerRow, int playerCol)
        {
            return playerRow >= 0 && playerRow < matrix.GetLength(0)
                && playerCol >= 0 && playerCol < matrix.GetLength(1);
        }
        public static void FillMatrix(char[,] matrix, ref int coals, ref int playerRow, ref int playerCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                    
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 's')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    if (input[col] == 'c')
                    {
                        coals++;
                    }
                }
            }
        }
    }
}
