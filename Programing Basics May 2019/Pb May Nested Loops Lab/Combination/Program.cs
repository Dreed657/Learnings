using System;

namespace Combination
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int combinations = 0;

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; i + j <= n; j++)
                {
                    for (int k = 0; i + j + k <= n; k++)
                    {
                        for (int l = 0; i + j + k + l <= n; l++)
                        {
                            for (int m = 0; i + j + k + l + m <= n; m++)
                            {
                                if (i + j + k + l + m == n)
                                    combinations++;
                            }
                        }
                    }
                }
            }  
            Console.WriteLine(combinations);
        }
    }
}
