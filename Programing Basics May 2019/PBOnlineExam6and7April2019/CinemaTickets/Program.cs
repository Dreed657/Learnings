using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = 0;
            int standardCount = 0;
            int kidsCount = 0;
            int soldSeatCount = 0;
            double totalTickets = 0;

            while (true)
            {
                string movieName = Console.ReadLine();
                if (movieName == "Finish") break;

                double maxSeats = int.Parse(Console.ReadLine());
                while (true)
                {
                    string typeSeat = Console.ReadLine();
                    if (typeSeat == "End") break;

                    switch (typeSeat)
                    {
                        case "student": studentsCount++; break;
                        case "standard": standardCount++; break;
                        case "kid": kidsCount++; break;
                        default: break;
                    }
                    soldSeatCount++;
                    totalTickets++;
                    if (soldSeatCount == maxSeats) break;
                }
                double fullness = (soldSeatCount / maxSeats) * 100;
                soldSeatCount = 0;

                Console.WriteLine($"{movieName} - {fullness:F2}% full.");
            }

            double studentsTicktesSoulPecent = (studentsCount / totalTickets) * 100;
            double standardTicktesSoulPecent = (standardCount / totalTickets) * 100;
            double kidsTicktesSoulPecent = (kidsCount / totalTickets) * 100;

            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{studentsTicktesSoulPecent:F2}% student tickets.");
            Console.WriteLine($"{standardTicktesSoulPecent:F2}% standard tickets.");
            Console.WriteLine($"{kidsTicktesSoulPecent:F2}% kids tickets.");
        }
    }
}
