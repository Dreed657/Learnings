using System;

namespace _12._Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripMoney = double.Parse(Console.ReadLine());
            int puzzleCount = int.Parse(Console.ReadLine());
            int dollCount = int.Parse(Console.ReadLine());
            int bearsCount = int.Parse(Console.ReadLine());
            int minersCount = int.Parse(Console.ReadLine());
            int trucksCount = int.Parse(Console.ReadLine());

            double puzzleSum = puzzleCount * 2.60;
            double dollSum = dollCount * 3;
            double bearsSum = bearsCount * 4.10;
            double minersSum = minersCount * 8.20;
            double trucksSum = trucksCount * 2;

            double money = puzzleSum + dollSum + bearsSum + minersSum + trucksSum;

            int toysCount = puzzleCount + dollCount + bearsCount + minersCount + trucksCount;

            if (toysCount >= 50)
                money = money - (money * 0.25);

            double payRent = money * 0.10;
            money = money - payRent;
            //money = Math.Round(money, 2); // 80/100

            if (money > tripMoney)
            {
                money = money - tripMoney;
                Console.WriteLine($"Yes! {money:F2} lv left.");
            }
            else
            {
                money = tripMoney - money;
                Console.WriteLine($"Not enough money! {money:F2} lv needed.");
            }
        }
    }
}
