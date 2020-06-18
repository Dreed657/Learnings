namespace WildFarm
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using WildFarm.Models.Animals;
    using WildFarm.Models.Animals.Birds;
    using WildFarm.Models.Animals.Felines;
    using WildFarm.Models.Animals.Mammals;
    using WildFarm.Models.Foods;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var Animals = new List<Animal>();

            while (true)
            {
                var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "End") break;

                Animal animal = null;

                string name = tokens[1];
                double weight = double.Parse(tokens[2]);
                string livingRegion = string.Empty;
                string breed = string.Empty;
                double wingSize = 0;

                switch (tokens[0])
                {
                    case nameof(Hen):
                        wingSize = double.Parse(tokens[3]);
                        animal = new Hen(name, weight, wingSize);
                        break;
                    case nameof(Owl):
                        wingSize = double.Parse(tokens[3]);
                        animal = new Owl(name, weight, wingSize);
                        break;
                    case nameof(Mouse):
                        livingRegion = tokens[3];
                        animal = new Mouse(name, weight, livingRegion);
                        break;
                    case nameof(Cat):
                        livingRegion = tokens[3];
                        breed = tokens[4];
                        animal = new Cat(name, weight, livingRegion, breed);
                        break;
                    case nameof(Dog):
                        livingRegion = tokens[3];
                        animal = new Dog(name, weight, livingRegion);
                        break;
                    case nameof(Tiger):
                        livingRegion = tokens[3];
                        breed = tokens[4];
                        animal = new Tiger(name, weight, livingRegion, breed);
                        break;
                }

                Animals.Add(animal);
                Console.WriteLine(animal.ProduceSound());

                tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "End") break;

                Food eatable = null;

                switch (tokens[0])
                {
                    case nameof(Fruit):
                        eatable = new Fruit(int.Parse(tokens[1]));
                        break;
                    case nameof(Meat):
                        eatable = new Meat(int.Parse(tokens[1]));
                        break;
                    case nameof(Seeds):
                        eatable = new Seeds(int.Parse(tokens[1]));
                        break;
                    case nameof(Vegetable):
                        eatable = new Vegetable(int.Parse(tokens[1]));
                        break;
                    default:
                        Console.WriteLine($"{tokens[0]} is not a valid Food");
                        break;
                }

                try
                {
                    animal.Eat(eatable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Animals.ForEach(Console.WriteLine);
        }
    }
}
