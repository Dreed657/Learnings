using System;

namespace PasswordBruteforce
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string password = Console.ReadLine();
                if (password == "End") break;
                int[] numbers = new int[password.Length];

                for (int i = 0; i < password.Length; i++)
                {
                    for (int j = 0; j <= 127; j++)
                    {
                        int current = password[i];
                        if (current == j)
                        {
                            numbers[i] = j;
                            break;
                        }
                    }
                }
                Console.WriteLine($"Is this your input?");
                foreach (int item in numbers)
                {
                    Console.Write((char)item);
                }
                Console.WriteLine();
            }
        }
    }
}
