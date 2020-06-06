using System;
using System.Collections.Generic;
using System.Linq;

namespace knghtGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeMatrix, sizeMatrix];
            WriteMatrix(matrix);

            int rowKnightAttack = -1;
            int colKnightAttack = -1;
            int countRemovedKnights = 0;

            Dictionary<int, List<int>> attackCoordinates = new Dictionary<int, List<int>>();
            AttackedCoordinates(attackCoordinates);

            while (true)
            {
                int countAttacks = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    int currentPossibleAttacks = 0;

                    for (int col = 0; col < matrix.GetLength(0); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            currentPossibleAttacks = CountOfAttackedKnights(attackCoordinates, matrix, row, col);
                        }

                        if (countAttacks < currentPossibleAttacks)
                        {
                            countAttacks = currentPossibleAttacks;
                            rowKnightAttack = row;
                            colKnightAttack = col;
                        }
                    }
                }

                if (countAttacks > 0)
                {
                    matrix[rowKnightAttack, colKnightAttack] = '0';
                    countRemovedKnights++;

                }

                else
                {
                    Console.WriteLine(countRemovedKnights);
                    break;
                }
            }
        }

        public static int CountOfAttackedKnights(Dictionary<int, List<int>> attackedCoordinates,
            char[,] matrix, int row, int col)
        {
            int countAttacks = 0;

            foreach (var rows in attackedCoordinates)
            {
                foreach (var cols in rows.Value)
                {
                    if (IndexValidator(matrix, row + rows.Key, col + cols) &&
                        matrix[row + rows.Key, col + cols] == 'K')
                    {
                        countAttacks++;
                    }
                }
            }

            return countAttacks;
        }

        public static bool IndexValidator(char[,] matrix, int row, int col)
        {
            return 0 <= row && row < matrix.GetLength(0)
                && 0 <= col && col < matrix.GetLength(1);
        }
        public static void AttackedCoordinates(Dictionary<int, List<int>> attackCoordinates)
        {
            attackCoordinates.Add(-2, new List<int>());
            attackCoordinates[-2].Add(+1);
            attackCoordinates[-2].Add(-1);

            attackCoordinates.Add(+2, new List<int>());   //moving on colums and rows the Knight coordinates.
            attackCoordinates[+2].Add(+1);
            attackCoordinates[+2].Add(-1);

            attackCoordinates.Add(-1, new List<int>());
            attackCoordinates[-1].Add(+2);
            attackCoordinates[-1].Add(-2);

            attackCoordinates.Add(+1, new List<int>());
            attackCoordinates[+1].Add(+2);
            attackCoordinates[+1].Add(-2);
        }
        public static void WriteMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
