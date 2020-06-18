using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int res = 0;

            switch (type)
            {
                case "add": res = n1 + n2; break;
                case "multiply": res = n1 * n2; break;
                case "subtract": res = n1 - n2; break;
                case "divide": res = n1 / n2; break;
            }

            Console.WriteLine(res);
        }
    }
}
