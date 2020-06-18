using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            int countryCount = 0;
            int sum = 0;
            string[] trip = new string[10];

            string country = string.Empty;

            while (country != "End")
            {
                country = Console.ReadLine();
                if (country == "End") break;
                int budget = int.Parse(Console.ReadLine());
                if (budget < 0) break;

                do
                {
                    int moneysaved = int.Parse(Console.ReadLine());
                    sum += moneysaved;
                } while (!(sum >= budget));

                if (sum >= budget)
                {
                    if (country == "End") break;
                    countryCount++;
                    trip[countryCount] = country;
                    sum = 0;
                }
            }

            foreach (var county in trip)
            {
                if (county != null)
                    Console.WriteLine($"Going to {county}!");
            }
        }
    }
}
