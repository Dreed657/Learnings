using System;

namespace Substitute
{
    class Program
    {
        static void Main(string[] args)
         {
            int k = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int q = k; q <= 8; q++)
                for (int j = 9; j >= l; j--)
                    for (int p = m; p <= 8; p++)
                        for (int z = 9; z >= n; z--)
                        {
                            if (q % 2 == 0 && j % 2 == 1 && p % 2 == 0 && z % 2 == 1)
                            {
                                if (counter == 6)
                                {
                                    break;
                                }

                                if (q == p && j == z)
                                {
                                    Console.WriteLine("Cannot change the same player.");
                                }
                                else
                                {
                                    counter++;
                                    Console.WriteLine($"{p}{j} - {p}{z}");
                                }
                            }
                        }

        }
    }
}
