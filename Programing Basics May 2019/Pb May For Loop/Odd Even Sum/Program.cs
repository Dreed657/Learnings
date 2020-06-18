using System;

namespace Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int evenSum = 0;
            int oddSum = 0;
            int positionInList = 0;

            for (int i = 0; i < n; i++)
            {
                positionInList++;
                int num = int.Parse(Console.ReadLine());
                if (positionInList % 2 == 0)
                {
                    evenSum += num;
                }
                else
                {
                    oddSum += num;
                }
            }

            int diff = evenSum - oddSum;
            if (diff == 0)
            {
                Console.WriteLine($"Yes\nSum = {evenSum}");
            }
            else
            {
                Console.WriteLine($"No\nDiff = {Math.Abs(diff)}");
            }
        }
    }
}
