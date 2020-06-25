using System;
using System.Collections.Generic;

namespace ComparingObjects1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string[] comand = Console.ReadLine()
                    .Split(" ");

                if (comand[0] == "END")
                {
                    break;
                }

                string name = comand[0];
                int age = int.Parse(comand[1]);
                string town = comand[2];

                Person person = new Person(name, age, town);
                people.Add(person);
            }

            int indexPersonToCompareWith = int.Parse(Console.ReadLine());

            Person personComparer = people[indexPersonToCompareWith - 1]; // the counting starts from 1 not 0

            int countEqualPeople = 0;
            int countNotEqualPeople = 0;

            foreach (var person in people)
            {
                int comparison = personComparer.CompareTo(person);

                if (comparison == 0)
                {
                    countEqualPeople++;
                }

                else
                {
                    countNotEqualPeople++;
                }
            }

            if (countEqualPeople > 1) // there will allways be at least 1 because of the personComparer
            {
                Console.WriteLine($"{countEqualPeople} {countNotEqualPeople} {people.Count}");
                return;
            }

            Console.WriteLine("No matches");
        }
    }
}
