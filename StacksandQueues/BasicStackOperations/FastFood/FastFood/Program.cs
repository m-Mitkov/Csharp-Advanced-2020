using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalQuantityOfFood = int.Parse(Console.ReadLine());

            int[] inputOrders = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(inputOrders);
            Console.WriteLine(orders.Max());

            while (orders.Any())
            {
                int currentOrder = orders.Peek();

                if (totalQuantityOfFood - currentOrder >= 0)
                {
                    totalQuantityOfFood -= currentOrder;
                    orders.Dequeue();
                }

                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
