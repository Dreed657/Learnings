using System;

namespace ChristmasGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            int age = 0;
            int kidCount = 0;
            int adultCount = 0;
            int toysMoney = 0;
            int sweatersMoney = 0;
            bool isTrue = true;

            while (isTrue)
            {
                input = Console.ReadLine();

                if (input != "Christmas")
                {
                    age = int.Parse(input);
                    if (age <= 16)
                    {
                        kidCount++;
                        toysMoney += 5;
                    }
                    else
                    {
                        adultCount++;
                        sweatersMoney += 15;
                    }
                }
                else
                {
                    isTrue = false;
                    break;
                }
            }

            Console.WriteLine($"Number of adults: {adultCount}");
            Console.WriteLine($"Number of kids: {kidCount}");
            Console.WriteLine($"Money for toys: {toysMoney}");
            Console.WriteLine($"Money for sweaters: {sweatersMoney}");
        }
    }
}
