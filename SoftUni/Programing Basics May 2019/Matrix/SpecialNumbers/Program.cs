using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int p = 1; p <= 9; p++)
                    {
                        for (int o = 1; o <= 9; o++)
                        {
                            if (n % i == 0 && n % j == 0 && n % p == 0 && n % o == 0)
                                Console.Write($"{i}{j}{p}{o} ");
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
