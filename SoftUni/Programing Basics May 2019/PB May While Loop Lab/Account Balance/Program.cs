using System;

namespace Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            int transactionsCount = int.Parse(Console.ReadLine());
            int counter = 0;
            double balance = 0.0d;

            while (counter < transactionsCount)
            {
                double amount = double.Parse(Console.ReadLine());
                if (amount < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {amount:F2}");
                balance += amount;

                counter++;
            }

            Console.WriteLine($"Total: {balance:F2}");
        }
    }
}
