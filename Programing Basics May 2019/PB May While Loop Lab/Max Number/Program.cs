using System;

namespace Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            int counter = 0;
            int maxNumber = int.MinValue;

            while (counter < numbersCount)
            {
                int number = int.Parse(Console.ReadLine());
                if (number > maxNumber)
                {
                    maxNumber = number;
                }
                counter++;
            }
            Console.WriteLine(maxNumber);
        }
    }
}
