using System;

namespace Unique_PIN_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num1; i++)
            {
                for (int b = 1; b <= num2; b++)
                {
                    for (int o = 1; o <= num3; o++)
                    {
                        if ((i % 2 == 0 && o % 2 == 0) && (b == 2 || b == 3 || b == 5 || b == 7))
                            Console.WriteLine($"{i} {b} {o}");
                    }
                }
            }
        }
    }
}
