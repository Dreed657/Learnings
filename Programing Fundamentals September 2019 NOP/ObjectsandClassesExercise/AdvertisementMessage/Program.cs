using System;

namespace AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phases = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string ad = string.Empty;

                Random rnd = new Random();
                ad += phases[rnd.Next(0, phases.Length - 1)] + " ";
                ad += events[rnd.Next(0, events.Length - 1)] + " ";
                ad += authors[rnd.Next(0, authors.Length - 1)] +  " - ";
                ad += cities[rnd.Next(0, cities.Length - 1)];

                Console.WriteLine(ad);
            }
        }
    }
}
