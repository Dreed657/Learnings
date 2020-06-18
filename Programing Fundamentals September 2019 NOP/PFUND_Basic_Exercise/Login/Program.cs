using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            int attempts = 0;

            while (true)
            {
                char[] password = Console.ReadLine().ToCharArray();
                string pass = string.Empty;

                for (int i = password.Length; i > 0; i--)
                    pass += password[i - 1];

                if (pass == username)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else
                {
                    attempts++;
                    if (attempts > 3)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
                password = new char[50];
                pass = string.Empty;
            }
        }
    }
}
