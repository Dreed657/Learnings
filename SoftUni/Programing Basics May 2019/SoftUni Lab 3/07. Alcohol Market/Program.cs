using System;

namespace _07._Alcohol_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double whiskeyPrice = double.Parse(Console.ReadLine());
            double beerQuantity = double.Parse(Console.ReadLine());
            double wineQuantity = double.Parse(Console.ReadLine());
            double rakiaQuantity = double.Parse(Console.ReadLine());
            double whiskeyQuantity = double.Parse(Console.ReadLine());

            double rakiaPrice = whiskeyPrice / 2;
            double winePrice = rakiaPrice - (0.4 * rakiaPrice);
            double beerPrice = rakiaPrice - (0.8 * rakiaPrice);

            double rakiaSum = rakiaQuantity * rakiaPrice;
            double wineSum = wineQuantity * winePrice;
            double beerSum = beerQuantity * beerPrice;
            double whiskeySum = whiskeyQuantity * whiskeyPrice;
           
            double moneySum = rakiaSum + wineSum + beerSum + whiskeySum;
            Math.Round(moneySum);

            Console.WriteLine($"{moneySum:F2}");
        }
    }
}
