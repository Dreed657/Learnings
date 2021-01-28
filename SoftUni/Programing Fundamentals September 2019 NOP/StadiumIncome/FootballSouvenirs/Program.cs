using System;

namespace FootballSouvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string souvenirs = Console.ReadLine();
            int souvCount = int.Parse(Console.ReadLine());

            double sum = 0;
            bool invalidStock = false;
            bool invalidCountry = false;

            if (country == "Argentina")
            {
                switch (souvenirs)
                {
                    case "flags": sum = souvCount * 3.25; break;
                    case "caps": sum = souvCount * 7.20; break;
                    case "posters": sum = souvCount * 5.10; break;
                    case "stickers": sum = souvCount * 1.25; break;
                    default: invalidStock = true; break;
                }
            }
            else if (country == "Brazil")
            {
                switch (souvenirs)
                {
                    case "flags": sum = souvCount * 4.20; break;
                    case "caps": sum = souvCount * 8.50; break;
                    case "posters": sum = souvCount * 5.35; break;
                    case "stickers": sum = souvCount * 1.20; break;
                    default: invalidStock = true; break;
                }
            }
            else if (country == "Croatia")
            {
                switch (souvenirs)
                {
                    case "flags": sum = souvCount * 2.75; break;
                    case "caps": sum = souvCount * 6.90; break;
                    case "posters": sum = souvCount * 4.95; break;
                    case "stickers": sum = souvCount * 1.10; break;
                    default: invalidStock = true; break;
                }
            }
            else if (country == "Denmark")
            {
                switch (souvenirs)
                {
                    case "flags": sum = souvCount * 3.10; break;
                    case "caps": sum = souvCount * 6.50; break;
                    case "posters": sum = souvCount * 4.80; break;
                    case "stickers": sum = souvCount * 0.90; break;
                    default: invalidStock = true; break;
                }
            }
            else
            {
                invalidCountry = true;
                Console.WriteLine("Invalid country!");
            }

            if (invalidStock)
            {
                Console.WriteLine("Invalid stock!");
            }
            else if (!(invalidCountry))
            {
                Console.WriteLine($"Pepi bought {souvCount} {souvenirs} of {country} for {sum:F2} lv.");
            }
        }
    }
}
