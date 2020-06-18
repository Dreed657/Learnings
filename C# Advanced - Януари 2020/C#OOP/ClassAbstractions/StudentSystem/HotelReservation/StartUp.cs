using System;

namespace HotelReservation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split();

            Season season = tokens[2] switch
            { 
                "Autumn" => Season.Autumn,
                "Spring" => Season.Spring,
                "Winter" => Season.Winter,
                "Summer" => Season.Summer,
            };

            Discount discount = tokens[3] switch
            {
                "SecondVisit" => Discount.SecondVisit,
                "VIP" => Discount.VIP,
                _ => Discount.None
            };

            var price = PriceCalculator.Calculate(
                decimal.Parse(tokens[0]),
                int.Parse(tokens[1]),
                season,
                discount);

            Console.WriteLine($"{price:F2}");
        }
    }
}
