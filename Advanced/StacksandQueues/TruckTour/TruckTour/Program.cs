using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPatrolStations = int.Parse(Console.ReadLine());

            Queue<int> kilometersAndPatrolStations = new Queue<int>(); // fuel, kmToPatrolStation pairs!

            for (int i = 0; i < numberOfPatrolStations; i++)
            {
                int[] patrolStation = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                int amountOfChargedFuel = patrolStation[0];
                int kmToNextPatrolStation = patrolStation[1];

                kilometersAndPatrolStations.Enqueue(amountOfChargedFuel);
                kilometersAndPatrolStations.Enqueue(kmToNextPatrolStation);
            }

            int index = 0;

            while (true)
            {
                Queue<int> copyOfQueue = new Queue<int>(kilometersAndPatrolStations);

                int littersFuel = copyOfQueue.Dequeue();
                int kilometers = copyOfQueue.Dequeue();

              
                if (littersFuel < kilometers)
                {
                    kilometersAndPatrolStations.Enqueue(kilometersAndPatrolStations.Dequeue());
                    kilometersAndPatrolStations.Enqueue(kilometersAndPatrolStations.Dequeue());
                }

                else if (littersFuel >= kilometers)
                {
                    int fuelLeft = littersFuel - kilometers;

                    while (copyOfQueue.Any())
                    {
                        int fuelToCharge = copyOfQueue.Dequeue();
                        int kmToNextPatrolStation = copyOfQueue.Dequeue();

                        if (fuelToCharge + fuelLeft >= kmToNextPatrolStation)
                        {
                            fuelLeft = fuelLeft + fuelToCharge - kmToNextPatrolStation;
                        }

                        else
                        {
                            kilometersAndPatrolStations.Enqueue(kilometersAndPatrolStations.Dequeue());
                            kilometersAndPatrolStations.Enqueue(kilometersAndPatrolStations.Dequeue());
                            fuelLeft = -1;
                            break;
                        }
                    }

                    if (fuelLeft >= 0)
                    {
                        Console.WriteLine(index);
                        break;
                    }
                }

                index++;
            }

          //  Console.WriteLine(index);
        }
    }
}
