using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputClothes = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int capacityRack = int.Parse(Console.ReadLine());

            Stack<int> clothes = new Stack<int>(inputClothes);

            int countOfUsedRacks = 1;
            int currentAmountClothesRack = 0;

            while (clothes.Any())
            {
                int currentClothe = clothes.Pop();

                if (currentClothe > capacityRack)
                {
                    continue;
                }

                if (currentAmountClothesRack + currentClothe <= capacityRack)
                {
                    currentAmountClothesRack += currentClothe;
                    continue;
                }

                else
                {
                    countOfUsedRacks++;
                    currentAmountClothesRack = 0;
                    currentAmountClothesRack += currentClothe;
                }
            }

            Console.WriteLine(countOfUsedRacks);
        }
    }
}
