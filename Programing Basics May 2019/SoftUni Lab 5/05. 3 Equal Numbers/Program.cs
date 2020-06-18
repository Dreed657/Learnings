using System;

namespace _05._3_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            double n3 = double.Parse(Console.ReadLine());

            if (n1 == n2 && n3 == n2)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
        }
    }
}
