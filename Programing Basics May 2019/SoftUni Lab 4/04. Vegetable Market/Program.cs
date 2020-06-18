using System;

namespace _04._Vegetable_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double vegiPrice = double.Parse(Console.ReadLine());
            double fruitPrice = double.Parse(Console.ReadLine());
            double vegiQuantity = double.Parse(Console.ReadLine());
            double fruitQuantity = double.Parse(Console.ReadLine());

            //double priceEuro = (vegiPrice * vegiQuantity + fruitPrice * fruitQuantity) / 1.94;  // 100/100 judge

            double vagi = vegiPrice * vegiQuantity;         // 50/100 judge
            double fruit = fruitPrice * fruitQuantity;

            double priceEuro = (vagi + fruit) / 1.94;

            double rounded = Math.Round(priceEuro, 2);

            Console.WriteLine($"{rounded:F2}");
        }
    }
}
