using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalMoneyInMashine = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Start") break;
                switch (double.Parse(input))
                {
                    case 0.1: totalMoneyInMashine += 0.1; break;
                    case 0.2: totalMoneyInMashine += 0.2; break;
                    case 0.5: totalMoneyInMashine += 0.5; break;
                    case 1.0: totalMoneyInMashine += 1.0; break;
                    case 2.0: totalMoneyInMashine += 2.0; break;
                    default: Console.WriteLine($"Cannot accept {input}"); break;
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;
             
                switch (input)
                {
                    case "Nuts":
                        if (totalMoneyInMashine >= 2.0)
                        {
                            Console.WriteLine($"Purchased nuts");
                            totalMoneyInMashine -= 2.0;
                        }
                        else Console.WriteLine($"Sorry, not enough money");
                        break;
                    case "Water": 
                        if (totalMoneyInMashine >= 0.7)
                        {
                            Console.WriteLine($"Purchased water");
                            totalMoneyInMashine -= 0.7;
                        }
                        else Console.WriteLine($"Sorry, not enough money");
                        break;
                    case "Crisps": 
                        if (totalMoneyInMashine >= 1.5)
                        {
                            Console.WriteLine($"Purchased crisps");
                            totalMoneyInMashine -= 1.5;
                        }
                        else Console.WriteLine($"Sorry, not enough money");
                        break;
                    case "Soda": 
                        if (totalMoneyInMashine >= 0.8)
                        {
                            Console.WriteLine($"Purchased soda");
                            totalMoneyInMashine -= 0.8;
                        }
                        else Console.WriteLine($"Sorry, not enough money");
                        break;
                    case "Coke": 
                        if (totalMoneyInMashine >= 1.0)
                        {
                            Console.WriteLine($"Purchased coke");
                            totalMoneyInMashine -= 1.0;
                        }
                        else Console.WriteLine($"Sorry, not enough money");
                        break;
                    default: Console.WriteLine("Invalid product"); break;
                }
            }
            Console.WriteLine($"Change: {totalMoneyInMashine:F2}");
        }
    }
}
