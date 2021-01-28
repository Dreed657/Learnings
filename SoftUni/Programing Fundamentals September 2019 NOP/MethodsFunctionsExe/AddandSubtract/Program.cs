using System;

namespace AddandSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            var n4 = sum(n1, n2);
            var result = subtract(n4, n3);
            Console.WriteLine(result);
        }

        static int sum(int n1, int n2)
        {
            return n1 + n2;
        }

        static int subtract(int n1, int n2)
        {
            return n1 - n2;
        }

    }
}
