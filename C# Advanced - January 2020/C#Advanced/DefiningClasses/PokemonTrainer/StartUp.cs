using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var trainers = new HashSet<Trainer>();

            while (true)
            {
                var tokens = Console.ReadLine().Split();
                if (tokens[0] == "Tournament") break;
                Trainer curTrainer;
                Pokemon pokemon;

                if (trainers.Any(x => x.Name == tokens[0]))
                {
                    curTrainer = trainers.First(x => x.Name == tokens[0]);
                    pokemon = new Pokemon(tokens[1], tokens[2], double.Parse(tokens[3]));
                    curTrainer.Pokemons.Add(pokemon);
                }
                else
                {
                    curTrainer = new Trainer(tokens[0]);
                    trainers.Add(curTrainer);
                    pokemon = new Pokemon(tokens[1], tokens[2], double.Parse(tokens[3]));
                    curTrainer.Pokemons.Add(pokemon);
                }
            }

            while (true)
            {
                string token = Console.ReadLine();
                if (token == "End") break;

                switch (token)
                {
                    case "Fire":
                        Battle(trainers, "Fire");
                        break;
                    case "Water":
                        Battle(trainers, "Water");
                        break;
                    case "Electricity":
                        Battle(trainers, "Electricity");
                        break;
                    default:
                        break;
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.BadgeCount))
            {
                Console.WriteLine(trainer.ToString());
            }
        }

        public static void Battle(HashSet<Trainer> trainers, string element)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(x => x.Element == element))
                {
                    trainer.BadgeCount++;
                }
                else DontHavePokemon(trainer);
            }
        }

        public static void DontHavePokemon(Trainer trainer)
        {
            foreach (var pokemon in trainer.Pokemons.ToList())
            {
                if (pokemon.Health - 10 <= 0) trainer.Pokemons.Remove(pokemon);
                else pokemon.Health -= 10;
            }
        }
    }
}
