using System;

namespace _04._New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeFlower = Console.ReadLine();
            int flowerCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double totalPrice = 0.0d;
            double moneyLeft = 0.0d;

            if (typeFlower == "Roses")
            {
                totalPrice = flowerCount * 5;

                if (flowerCount > 80)
                {
                    totalPrice = totalPrice - (totalPrice * 0.10);    
                }
            }
            else if (typeFlower == "Dahlias")
            {
                totalPrice = flowerCount * 3.80;

                if (flowerCount > 90)
                {
                    totalPrice = totalPrice - (totalPrice * 0.15);
                }
            }
            else if (typeFlower == "Tulips")
            {
                totalPrice = flowerCount * 2.80;

                if (flowerCount > 80)
                {
                    totalPrice = totalPrice - (totalPrice * 0.15);
                }
            }
            else if (typeFlower == "Narcissus")
            {
                totalPrice = flowerCount * 3;

                if (flowerCount < 120)
                {
                    totalPrice = totalPrice + (totalPrice * 0.15);
                }
            }
            else if (typeFlower == "Gladiolus")
            {
                totalPrice = flowerCount * 2.50;

                if (flowerCount < 80)
                {
                    totalPrice = totalPrice + (totalPrice * 0.20);
                }
            }

            if (budget >= totalPrice)
            {
                moneyLeft = budget - totalPrice;
                Console.WriteLine($"Hey, you have a great garden with {flowerCount} {typeFlower} and {Math.Abs(moneyLeft):F2} leva left.");
            }
            else
            {
                moneyLeft = totalPrice - budget;
                Console.WriteLine($"Not enough money, you need {Math.Abs(moneyLeft):F2} leva more.");
            }
        }
    }
}
