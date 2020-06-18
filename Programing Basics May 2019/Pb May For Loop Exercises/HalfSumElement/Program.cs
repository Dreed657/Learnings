using System;

namespace HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
                
                if (num > max)
                {
                    max = num;
                }
            }
            sum -= max;
                
            if (sum == max)
            {
                Console.WriteLine($"Yes\nSum = {sum}");
            }
            else
            {
                int diff = max - sum;
                Console.WriteLine($"No\nDiff = {Math.Abs(diff)}");
            }
        }
    }
}
