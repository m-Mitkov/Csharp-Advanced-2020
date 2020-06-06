using System;
using System.Collections.Generic;

namespace Wardrobe1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfClothes = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            // color => dress => count dress.

            for (int i = 0; i < numberOfClothes; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ");

                string color = input[0];
                string[] clothes = input[1]
                    .Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());

                    foreach (var item in clothes)
                    {
                        if (!wardrobe[color].ContainsKey(item))
                        {
                            wardrobe[color].Add(item, 1);
                            continue;
                        }

                        wardrobe[color][item]++;
                    }
                }

                else
                {
                    foreach (var item in clothes)
                    {
                        if (!wardrobe[color].ContainsKey(item))
                        {
                            wardrobe[color].Add(item, 1);
                            continue;
                        }

                        wardrobe[color][item]++;
                    }
                }
            }

            string[] clothToFind = Console.ReadLine()
                .Split(" ");

            string colorToFind = clothToFind[0];
            string searchedCloth = clothToFind[1];

            foreach (var (color, clothes) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");

                foreach (var (cloth, cout) in clothes)
                {
                    if (color == colorToFind && cloth == searchedCloth)
                    {
                        Console.WriteLine($"* {cloth} - {cout} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {cloth} - {cout}");
                }
            }
        }
    }
}
