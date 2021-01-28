using System;

namespace _08._Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int tripTime = int.Parse(Console.ReadLine());
            string acomandation = Console.ReadLine();
            string rating = Console.ReadLine();
            double price = 0.0d;

            tripTime = tripTime - 1;

            if (acomandation == "room for one person")
            {
                // Price 18.00
                price = tripTime * 18.00;
            }
            else if (acomandation == "apartment")
            {
                // Price 25.00
                price = tripTime * 25.00;
                if (tripTime < 10)
                {
                    price = price - (price * 0.30);
                }
                else if (tripTime >= 10 && tripTime <= 15) 
                {
                    price = price - (price * 0.35);
                }
                else if (tripTime > 15)
                {
                    price = price - (price * 0.50);
                }
            }
            else if (acomandation == "president apartment")
            {
                // Price 35.00
                price = tripTime * 35.00;
                if (tripTime < 10)
                {
                    price = price - (price * 0.10);
                }
                else if (tripTime >= 10 && tripTime <= 15)
                {
                    price = price - (price * 0.15);
                }
                else if (tripTime > 15)
                {
                    price = price - (price * 0.20);
                }
            }

            if (rating == "positive")
            {
                price += price * 0.25;
                Console.WriteLine($"{price:F2}");
            }
            else if (rating == "negative")
            {
                price = price - (price * 0.10);
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}
