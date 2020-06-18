using System;

namespace SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int primeNumbers = 0;
            int nonPrimeNumbers = 0;
            bool nonPrime = false;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "stop")
                    break;
                int number = int.Parse(input);
                if (number == 0)
                    continue;
                if (number < 0)
                {
                    Console.WriteLine($"Number is negative.");
                    continue;
                }

                if (number == 0 || number == 1)
                {
                    nonPrimeNumbers += number;
                }
                else
                {
                    for (int a = 2; a <= number / 2; a++)
                    {
                        nonPrime = false;
                        if (number % a == 0)
                        {
                            nonPrime = true;
                            nonPrimeNumbers += number;
                            break;
                        }
                    }
                    if (!nonPrime)
                        primeNumbers += number;
                }
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeNumbers}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeNumbers}");
        }
    }
}
