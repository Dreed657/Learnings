using System;

namespace ChristmasSweets
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceBaklava = double.Parse(Console.ReadLine());
            double priceMuffins = double.Parse(Console.ReadLine());
            double quantitySholen = double.Parse(Console.ReadLine());
            double quantityCandy = double.Parse(Console.ReadLine());
            double quantityCookies = double.Parse(Console.ReadLine());

            double priceSholen = priceBaklava + (priceBaklava * 0.60);
            double priceCandy = priceMuffins + (priceMuffins * 0.80);
            double priceCookies = 7.50;

            double money = (priceSholen * quantitySholen) + (priceCandy * quantityCandy) + (priceCookies * quantityCookies);

            Console.WriteLine($"{money:F2}");
        }
    }
}
