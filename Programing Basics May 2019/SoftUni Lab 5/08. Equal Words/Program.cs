using System;

namespace _08._Equal_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string n1 = Console.ReadLine();
            string n2 = Console.ReadLine();

            n1 = n1.ToUpper();
            n2 = n2.ToUpper();

            if (n1 == n2)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
        }
    }
}
