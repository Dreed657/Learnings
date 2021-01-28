using System;

namespace GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            double startBalance = balance;
            bool noMoney = false;

            while (true)
            {
                if (balance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    noMoney = true;
                    break;
                }

                string input = Console.ReadLine();
                if (input == "Game Time") break;
               
                switch (input)
                {
                    case "OutFall 4":
                        if (balance < 39.99)
                        {
                            Console.WriteLine("Too Expensive");
                            break;
                        }
                        balance -= 39.99;
                        Console.WriteLine($"Bought OutFall 4");
                        break;
                    case "CS: OG":
                        if (balance < 15.99)
                        {
                            Console.WriteLine("Too Expensive");
                            break;
                        }
                        balance -= 15.99;
                        Console.WriteLine($"Bought CS: OG");
                        break;
                    case "Zplinter Zell":
                        if (balance < 19.99)
                        {
                            Console.WriteLine("Too Expensive");
                            break;
                        }
                        balance -= 19.99;
                        Console.WriteLine($"Bought Zplinter Zell");
                        break;
                    case "Honored 2":
                        if (balance < 59.99)
                        {
                            Console.WriteLine("Too Expensive");
                            break;
                        }
                        balance -= 59.99;
                        Console.WriteLine($"Bought Honored 2");
                        break;
                    case "RoverWatch":
                        if (balance < 29.99)
                        {
                            Console.WriteLine("Too Expensive");
                            break;
                        }
                        balance -= 29.99;
                        Console.WriteLine($"Bought RoverWatch");
                        break;
                    case "RoverWatch Origins Edition":
                        if (balance < 39.99)
                        {
                            Console.WriteLine("Too Expensive");
                            break;
                        }
                        balance -= 39.99;
                        Console.WriteLine($"Bought RoverWatch Origins Edition");
                        break;
                    default: Console.WriteLine("Not Found"); break;
                }
            }

            if(!noMoney)
                Console.WriteLine($"Total spent: ${(startBalance - balance):F2}. Remaining: ${balance:F2}");
        }
    }
}
