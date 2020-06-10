    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace PredicateParty1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var guests = Console.ReadLine()
                     .Split(" ")
                     .ToList();

                while (true)
                {
                    string[] comand = Console.ReadLine()
                        .Split(" ");

                    if (comand[0] == "Party!")
                    {
                        break;
                    }

                    var doubleOrRemove = comand[0];
                    var criteria = comand[1];
                    var givenString = comand[2];

                    Func<string, string, bool> filter = null;
                    filter = GetFunc(criteria);

                    if (doubleOrRemove == "Double")
                    {
                        var guestsToDouble = new List<string>();
                        guestsToDouble = guests.Where(x => filter(x, givenString)).ToList();

                        foreach (var name in guestsToDouble)
                        {
                            guests.Insert(guests.IndexOf(name), name);
                        }
                    }

                    else if (doubleOrRemove == "Remove")
                    {
                        guests = guests.Where(x => !filter(x, givenString)).ToList();
                    }
                }

                Console.WriteLine(guests.Any()
                    ? $"{ string.Join(", ", guests)} are going to the party!" 
                    : "Nobody is going to the party!");
            }

            public static Func<string, string, bool> GetFunc(string criteria)
            {
                if (criteria == "StartsWith")
                {
                    return (x, y) => x.StartsWith(y);
                }

                else if (criteria == "EndsWith")
                {
                    return (x, y) => x.EndsWith(y);
                }

                else if (criteria == "Length")
                {
                    return (x, y) => x.Length == int.Parse(y);
                }

                return null;
            }
        }
    }
