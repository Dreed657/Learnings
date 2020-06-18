using System;

namespace Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double laundyPrice = double.Parse(Console.ReadLine());
            int pricePerToy = int.Parse(Console.ReadLine());

            int toyCount = 0;
            double money = 0.00d;
            double currentMoneyStep = 0.00d;
            double moneyFromToys = 0.00d;
            int brotherMoney = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    //Money
                    currentMoneyStep += 10.00;
                    money += currentMoneyStep;
                    brotherMoney++;
                }
                else
                {
                    //Toys
                    toyCount++;
                }
            }

            moneyFromToys = toyCount * pricePerToy;
            money += moneyFromToys;
            money -= brotherMoney;

            if (money >= laundyPrice)
            {
                double moneyLeft = money - laundyPrice;
                Console.WriteLine($"Yes! {moneyLeft:F2}");
            }
            else
            {
                double moneyNotEnough = laundyPrice - money;
                Console.WriteLine($"No! {moneyNotEnough:F2}");
            }
        }
    }
}
