using System;

namespace _07._Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            double totalBonus = 0.0d;

            if (city == "Sofia")
            {
                if (sales >= 0 && sales <= 500)
                {
                    totalBonus += sales * 0.05;
                    Console.WriteLine($"{totalBonus:F2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    totalBonus += sales * 0.07;
                    Console.WriteLine($"{totalBonus:F2}");
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    totalBonus += sales * 0.08;
                    Console.WriteLine($"{totalBonus:F2}");
                }
                else if (sales > 1000)
                {
                    totalBonus += sales * 0.12;
                    Console.WriteLine($"{totalBonus:F2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "Varna")
            {
                if (sales >= 0 && sales <= 500)
                {
                    totalBonus += sales * 0.045;
                    Console.WriteLine($"{totalBonus:F2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    totalBonus += sales * 0.075;
                    Console.WriteLine($"{totalBonus:F2}");
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    totalBonus += sales * 0.10;
                    Console.WriteLine($"{totalBonus:F2}");
                }
                else if (sales > 1000)
                {
                    totalBonus += sales * 0.13;
                    Console.WriteLine($"{totalBonus:F2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "Plovdiv")
            {
                if (sales >= 0 && sales <= 500)
                {
                    totalBonus += sales * 0.055;
                    Console.WriteLine($"{totalBonus:F2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    totalBonus += sales * 0.08;
                    Console.WriteLine($"{totalBonus:F2}");
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    totalBonus += sales * 0.12;
                    Console.WriteLine($"{totalBonus:F2}");
                }
                else if (sales > 1000)
                {
                    totalBonus += sales * 0.145;
                    Console.WriteLine($"{totalBonus:F2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
