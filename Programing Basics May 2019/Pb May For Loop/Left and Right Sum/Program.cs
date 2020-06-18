using System;

namespace LeftandRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < n; i++)
            {
                int leftNumber = int.Parse(Console.ReadLine());
                leftSum += leftNumber;
            }
            for (int y = 0; y < n; y++)
            {
                int rightNumber = int.Parse(Console.ReadLine());
                rightSum += rightNumber;
            }

            int sum = leftSum + rightSum;
            int diff = leftSum - rightSum;
            if (diff == 0)
            {
                Console.WriteLine($"Yes, sum = {sum - leftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(diff)}");
            }
        }
    }
}
