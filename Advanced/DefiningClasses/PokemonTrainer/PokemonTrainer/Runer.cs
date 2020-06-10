using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Runer
    {
        public static void Start()
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string[] comand = Console.ReadLine()
                    .Split(" ");

                if (comand[0] == "Tournament")
                {
                    break;
                }

                string trainerName = comand[0];
                string pokemonName = comand[1];
                string pokemonElement = comand[2];
                int pokemonHealth = int.Parse(comand[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainers.Any(x => x.Name == trainerName))
                {
                    var trainer = trainers
                        .FirstOrDefault(x => x.Name == trainerName);

                    trainer.Pokemons.Add(pokemon);
                }

                else
                {
                    List<Pokemon> pokemons = new List<Pokemon>();
                    pokemons.Add(pokemon);

                    Trainer trainer = new Trainer(trainerName, 0, pokemons);
                    trainers.Add(trainer);
                }
            }

            while (true)
            {
                string element = Console.ReadLine();

                if (element == "End")
                {
                    break;
                }
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == element))
                    {
                        trainer.NumberOfBadges++;
                    }

                    else
                    {
                        trainer.Pokemons
                            .Select(x => x.Health -= 10)
                            .ToList();

                        trainer.Pokemons = trainer.Pokemons
                            .Where(x => x.Health > 0)
                            .ToList();
                    }
                }
            }

            trainers = trainers
                .OrderByDescending(x => x.NumberOfBadges)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, trainers));
        }
    }
}
