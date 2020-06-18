using System;

namespace EasterTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string diapason = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            int price = 0;

            switch (destination)
            {
                case "France" :
                    switch (diapason)
                    {
                        case "21-23": price = 30; break;
                        case "24-27": price = 35; break;
                        case "28-31": price = 40; break;
                        default: break;
                    }
                    break;
                case "Italy":
                    switch (diapason)
                    {
                        case "21-23": price = 28; break;
                        case "24-27": price = 32; break;
                        case "28-31": price = 39; break;
                        default: break;
                    }
                    break;
                case "Germany":
                    switch (diapason)
                    {
                        case "21-23": price = 32; break;
                        case "24-27": price = 37; break;
                        case "28-31": price = 43; break;
                        default: break;
                    }
                    break;
                default: break;
            }
            int sum = days * price;
            Console.WriteLine($"Easter trip to {destination} : {sum:F2} leva.");
        }
    }
}
