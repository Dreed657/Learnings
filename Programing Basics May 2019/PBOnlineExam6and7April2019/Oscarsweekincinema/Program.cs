using System;

namespace Oscarsweekincinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameMovie = Console.ReadLine();
            string roomType = Console.ReadLine();
            int ticketsCount = int.Parse(Console.ReadLine());

            double income = 0;

            switch (roomType)
            {
                case "normal":
                    switch (nameMovie)
                    {
                        case "A Star Is Born": income = ticketsCount * 7.50; break;
                        case "Bohemian Rhapsody": income = ticketsCount * 7.35; break;
                        case "Green Book": income = ticketsCount * 8.15; break;
                        case "The Favourite": income = ticketsCount * 8.75; break;
                        default: break;
                    }
                    break;
                case "luxury":
                    switch (nameMovie)
                    {
                        case "A Star Is Born": income = ticketsCount * 10.50; break;
                        case "Bohemian Rhapsody": income = ticketsCount * 9.45; break;
                        case "Green Book": income = ticketsCount * 10.25; break;
                        case "The Favourite": income = ticketsCount * 11.55; break;
                        default: break;
                    }
                    break;
                case "ultra luxury":
                    switch (nameMovie)
                    {
                        case "A Star Is Born": income = ticketsCount * 13.50; break;
                        case "Bohemian Rhapsody": income = ticketsCount * 12.75; break;
                        case "Green Book": income = ticketsCount * 13.25; break;
                        case "The Favourite": income = ticketsCount * 13.95; break;
                        default: break;
                    }
                    break;
                default: break;
            }
            Console.WriteLine($"{nameMovie} -> {income:F2} lv.");
        }
    }
}
