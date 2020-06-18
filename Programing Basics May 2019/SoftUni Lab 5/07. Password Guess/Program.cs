using System;

namespace _07._Password_Guess
{
    class Program
    {
        static void Main(string[] args)
        {
            string n1 = Console.ReadLine();

            if (n1 == "s3cr3t!P@ssw0rd")
                Console.WriteLine("Welcome");
            else
                Console.WriteLine("Wrong password!");
        }
    }
}
