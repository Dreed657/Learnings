using System;

namespace EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int tempSum = 0;
            int maxDiff = 0;

            for (int i = 0; i < n; i++)
            {
                int firstNumber = int.Parse(Console.ReadLine());
                int secondNumber = int.Parse(Console.ReadLine());

                int sum = firstNumber + secondNumber;

                int diff = Math.Abs(sum - tempSum);
                if (diff > maxDiff && i > 0)
                {
                    maxDiff = diff;
                }
                tempSum = sum;
            }

            if (maxDiff == 0)
                Console.WriteLine($"Yes, value={tempSum}");
            else
                Console.WriteLine($"No, maxdiff={maxDiff}");
        }
    }
}
