using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Engine
    {
        private readonly List<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            while (true)
            {
                string type = Console.ReadLine();
                if (type == "Beast!") break;
                string[] tokens = Console.ReadLine().Split();

                Animal animal;

                try
                {
                    animal = GetAnimal(type, tokens);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                
                animals.Add(animal);
            }

            PrintToConsole();
        }

        private void PrintToConsole()
        {
            foreach (Animal jiotno in animals)
            {
                Console.WriteLine(jiotno.ToString());
            }
        }

        private static Animal GetAnimal(string type,string[] tokens)
        {
            string name = tokens[0];
            int age = int.Parse(tokens[1]);

            Animal animal = null;

            if (type == "Dog")
            {
                animal = new Dog(name, age, tokens[2]);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, age, tokens[2]);
            }
            else if (type == "Frog")
            {
                animal = new Frog(name, age, tokens[2]);
            }
            else if (type == "Kitten")
            {
                animal = new Kitten(name, age);
            }
            else if (type == "Tomcat")
            {
                animal = new Tomcat(name, age);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }

            return animal;
        }
    }
}
