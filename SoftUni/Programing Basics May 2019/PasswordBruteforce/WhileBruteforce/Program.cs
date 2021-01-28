using System;

namespace WhileBruteforce
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            int attemtsCount = 0;
            var attemt = new System.Text.StringBuilder();

            while (!attemt.Equals(password))
            {
                for (int i = 0; i < password.Length; i++)
                {
                    for (int j = 0; j <= 127; j++)
                    {
                        char current = (char)int.Parse(j.ToString());
                        attemt.AppendLine(current.ToString());
                        if (password[i] == current) break;
                    }
                }
                if (attemt.Equals(password)) break;
                Console.WriteLine(attemt);
                attemtsCount++;
            }

            Console.WriteLine($"This is your password: {attemt}");
            Console.WriteLine($"It took that many trys {attemtsCount}");
        }
    }
}
