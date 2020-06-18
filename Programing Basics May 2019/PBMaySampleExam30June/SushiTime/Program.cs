using System;

namespace SushiTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string shushyType = Console.ReadLine();
            string restorantName = Console.ReadLine();
            int dishesCount = int.Parse(Console.ReadLine());
            string order = Console.ReadLine();

            double price = 0.00d;
            bool invalid = false;

            switch (restorantName)
            {
                case "Sushi Zone":
                    switch (shushyType)
                    {
                        case "sashimi": price = 4.99; break;
                        case "maki": price = 5.29; break;
                        case "uramaki": price = 5.99; break;
                        case "temaki": price = 4.29; break;
                        default: break;
                    }
                    break;
                case "Sushi Time":
                    switch (shushyType)
                    {
                        case "sashimi": price = 5.49; break;
                        case "maki": price = 4.69; break;
                        case "uramaki": price = 4.49; break;
                        case "temaki": price = 5.19; break;
                        default: break;
                    }
                    break;
                case "Sushi Bar":
                    switch (shushyType)
                    {
                        case "sashimi": price = 5.25; break;
                        case "maki": price = 5.55; break;
                        case "uramaki": price = 6.25; break;
                        case "temaki": price = 4.75; break;
                        default: break;
                    }
                    break;
                case "Asian Pub":
                    switch (shushyType)
                    {
                        case "sashimi": price = 4.50; break;
                        case "maki": price = 4.80; break;
                        case "uramaki": price = 5.50; break;
                        case "temaki": price = 5.50; break;
                        default: break;
                    }
                    break;
                default: Console.WriteLine($"{restorantName} is invalid restaurant!"); invalid = true; break;
            }
            if (!invalid)
            {
                double sum = price * dishesCount;

                if (order == "Y")
                    sum += sum * .20;

                Console.WriteLine($"Total price: {Math.Ceiling(sum)} lv.");
            }
        }
    }
}
