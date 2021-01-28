using System;

namespace ChristmasDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string input = string.Empty;
            int sum = 0;
            int sucssesPurchase = 0;

            while (input != "Stop")
            {
                input = Console.ReadLine();

                if (input == "Stop")
                    break;

                foreach (char ch in input)
                {
                    int ascii = ch;
                    sum += ascii;
                }

                if (sum > budget)
                {
                    budget = 0;
                    break;
                }

                if (budget >= sum)
                {
                    ++sucssesPurchase;
                    budget -= sum;
                }
                
             
                sum = 0;
            }

            for (int i = 0; i < sucssesPurchase; i++)
            {
                Console.WriteLine("Item successfully purchased!");
            }

            if (budget > 0)
            {
                Console.WriteLine($"Money left: {budget}");
            }
            else
            {
                Console.WriteLine("Not enough money!");
            }
        }
    }
}
