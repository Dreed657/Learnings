using System;

namespace Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            int counter = 0;
            int minNumber = int.MaxValue;

            while (counter < numbersCount)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < minNumber)
                {
                    minNumber = number;
                }
                counter++;
            }
            Console.WriteLine(minNumber);
        }
    }
}
