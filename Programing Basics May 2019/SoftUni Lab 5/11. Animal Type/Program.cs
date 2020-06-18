using System;

namespace _11._Animal_Type
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();

            if (n == "dog")
                Console.WriteLine("mammal");
            else if (n == "crocodile" || n == "tortoise" || n == "snake")
                Console.WriteLine("reptile");
            else
                Console.WriteLine("unknown");
        }
    }
}
