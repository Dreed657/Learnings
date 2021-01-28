using System;

namespace ChristmasMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            int fantasyBooks = int.Parse(Console.ReadLine()); 
            int horrorBooks = int.Parse(Console.ReadLine()); 
            int romanticBooks = int.Parse(Console.ReadLine());

            double priceFantasy = 14.90;
            double priceHorror = 9.80;
            double priceRomantic = 4.30;

            double money = (fantasyBooks * priceFantasy) + (horrorBooks * priceHorror) + (romanticBooks * priceRomantic);
            double ddc = money * 0.20;
            money -= ddc;


            if (money >= moneyNeeded)
            {
                double moneyLeft = money - moneyNeeded;
                double salary = Math.Floor(moneyLeft * 0.10);
                money -= salary;
                Console.WriteLine($"{money:F2} leva donated.");
                Console.WriteLine($"Sellers will receive {salary} leva.");
            }
            else
            {
                double noMoney = moneyNeeded - money;
                Console.WriteLine($"{noMoney:F2} money needed.");
            }
        }
    }
}
