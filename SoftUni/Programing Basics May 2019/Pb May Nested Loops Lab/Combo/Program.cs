using System;

namespace Combo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int combinations = 0;

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    for (int p = 0; p <= n; p++)
                    {
                        for (int o = 0; o <= n; o++)
                        {
                            for (int q = 0; q <= n; q++)
                            {
                                if ((i + j + p + o + q) == n)
                                    combinations++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"{combinations}");
        }
    }
}
