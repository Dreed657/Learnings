using System;

namespace TripToWorldCup
{
    class Program
    {
        static void Main(string[] args)
        {
            double ticketPriceTo = double.Parse(Console.ReadLine());
            double ticketPriceBack = double.Parse(Console.ReadLine());
            double ticketPriceMatch = double.Parse(Console.ReadLine());
            int matchCount = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double ticketPrice = 6 * (ticketPriceTo + ticketPriceBack);
            double afterDiscount = ticketPrice - (ticketPrice * (discount / 100));
            double sumTickets = 6 * matchCount * ticketPriceMatch;
            double sum = afterDiscount + sumTickets;
            double splitFrineds = sum / 6;

            Console.WriteLine($"Total sum: {sum:F2} lv.");
            Console.WriteLine($"Each friend has to pay {splitFrineds:F2} lv.");
        }
    }
}
