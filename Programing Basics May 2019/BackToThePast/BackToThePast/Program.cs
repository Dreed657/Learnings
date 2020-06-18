using System;

namespace BackToThePast
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double year = double.Parse(Console.ReadLine());
            int age = 18;

            for (int i = 1800; i <= year; i++)
            {
                if (i % 2 == 0)
                    money -= 12000;
                else
                    money -= 12000 + (50 * age);
                age++;
            }

            if (money < 0)
                Console.WriteLine($"He will need {Math.Abs(money):F2} dollars to survive.");
            else
                Console.WriteLine($"Yes! He will live a carefree life and will have {Math.Abs(money):F2} dollars left.");
        }
    }
}
