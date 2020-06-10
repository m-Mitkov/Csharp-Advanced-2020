using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name, int numberOfBadges, List<Pokemon> pokemons)
        {
           this.Name = name;
           this.NumberOfBadges = numberOfBadges;
           this.Pokemons = pokemons;
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {Pokemons.Count}";
        }
    }
}
