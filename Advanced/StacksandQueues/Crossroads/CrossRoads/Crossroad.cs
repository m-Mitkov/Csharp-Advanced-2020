using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());

            Queue<string> carsQueue = new Queue<string>();
            int countCarsPassedCrosroad = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                if (input != "green")
                {
                    carsQueue.Enqueue(input);
                    continue;
                }

                string currentCar = string.Empty;
                int greenLightLeft = greenLightSeconds;

                while (carsQueue.Any())
                {
                    currentCar = carsQueue.Dequeue();

                    if (currentCar.Length < greenLightLeft)
                    {
                        greenLightLeft -= currentCar.Length;
                        countCarsPassedCrosroad++;
                        continue;
                    }

                    else if (greenLightLeft > 0)
                    {
                        if (currentCar.Length <= greenLightLeft + freeWindowSeconds)
                        {
                            countCarsPassedCrosroad++;
                            break;
                        }

                        else
                        {
                            int indexWhereCrashHappen = freeWindowSeconds + greenLightLeft;
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {currentCar[indexWhereCrashHappen]}.");
                            return;
                        }
                    }
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{countCarsPassedCrosroad} total cars passed the crossroads.");
        }
    }
}
