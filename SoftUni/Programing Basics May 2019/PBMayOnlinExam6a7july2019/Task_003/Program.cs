using System;

namespace Task_003
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            string packege = Console.ReadLine();
            string vip = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            double price = 0;
            double vipDiscount = 0.00d;

            if (days > 7) days--;

            bool invalidSometing = false;

            switch (city)
            {
                case "Bansko":
                case "Borovets":
                    switch (packege)
                    {
                        case "noEquipment": price = 80; vipDiscount = .05; break;
                        case "withEquipment": price = 100; vipDiscount = .10; break;
                        default: invalidSometing = true; break;
                    }
                    break;

                case "Varna":
                case "Burgas":
                    switch (packege)
                    {
                        case "noBreakfast": price = 100; vipDiscount = .7; break;
                        case "withBreakfast": price = 130; vipDiscount = .12; break;
                        default: invalidSometing = true; break;
                    }
                    break;
                default: invalidSometing = true; break;
            }

            if (vip == "yes")
                price -= price * vipDiscount;

            double total = price * days;

            if (!(invalidSometing || days < 1))
            {
                Console.WriteLine($"The price is {total:F2}lv! Have a nice time!");
            }
            else
            {
                if(invalidSometing)
                    Console.WriteLine($"Invalid input!");
                else if (days < 1)
                    Console.WriteLine($"Days must be positive number!");
            }
        }
    }
}
