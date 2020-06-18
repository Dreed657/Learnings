using System;

namespace BachelorParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int moneyForSinger = int.Parse(Console.ReadLine());
            int money = 0;
            int allGuests = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "The restaurant is full") break;

                int groupSize = int.Parse(input);
                allGuests += groupSize;

                if (groupSize < 5)
                    money += groupSize * 100;
                else
                    money += groupSize * 70;
            }

            if (money >= moneyForSinger)
            {
                int moneyLeft = money - moneyForSinger;
                Console.WriteLine($"You have {allGuests} guests and {moneyLeft} leva left.");
            }
            else
                Console.WriteLine($"You have {allGuests} guests and {money} leva income, but no singer.");
        }
    }
}
