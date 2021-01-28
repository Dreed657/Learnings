using System;

namespace MultiplicationTable2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());

            if (!(times > 10))
            {
                for (int i = times; i <= 10; i++)
                {
                    int multiply = n * i;
                    Console.WriteLine($"{n} X {i} = {multiply}");
                }
            }
            else
            {
                int result = n * times;
                Console.WriteLine($"{n} X {times} = {result}");
            }
        }
    }
}
