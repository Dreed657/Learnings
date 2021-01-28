using System;

namespace OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double oddSum = 0;
            double oddMax = double.MinValue;
            double oddMin = double.MaxValue;
            double evenSum = 0;
            double evenMax = double.MinValue;
            double evenMin = double.MaxValue;


            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += num;
                    if (evenMax < num)
                    {
                        evenMax = num;
                    }
                    if (evenMin > num)
                    {
                        evenMin = num;
                    }
                }
                else
                {
                    oddSum += num;
                    if (num > oddMax)
                    {
                        oddMax = num;
                    }
                    if (num < oddMin)
                    {
                        oddMin = num;
                    }
                }
            }

            if (!((oddMin == double.MaxValue) || (oddMax == double.MinValue)))
            {
                Console.WriteLine($"OddSum={oddSum:F2},");
                Console.WriteLine($"OddMin={oddMin:F2},");
                Console.WriteLine($"OddMax={oddMax:F2},");
               
            }
            else
            {
                Console.WriteLine($"OddSum={oddSum:F2},");
                Console.WriteLine($"OddMin=No,");
                Console.WriteLine($"OddMax=No,");
            }

            if (!((evenMin == double.MaxValue) || (evenMax == double.MinValue)))
            {
                Console.WriteLine($"EvenSum={evenSum:F2},");
                Console.WriteLine($"EvenMin={evenMin:F2},");
                Console.WriteLine($"EvenMax={evenMax:F2}");
            }
            else
            {
                Console.WriteLine($"EvenSum={evenSum:F2},");
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
            }
        }
    }
}
