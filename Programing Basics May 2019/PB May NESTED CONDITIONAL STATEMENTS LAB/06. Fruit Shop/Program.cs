using System;

namespace _06._Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string dayOfTheWeek = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double totalPrice = 0.0d;

            if (dayOfTheWeek == "Sunday" || dayOfTheWeek == "Saturday")
            {
                if (product == "banana")
                {
                    totalPrice += quantity * 2.70;
                    Console.WriteLine($"{totalPrice:F2}");
                }
                else if (product == "apple")
                {
                    totalPrice += quantity * 1.25;
                    Console.WriteLine($"{totalPrice:F2}");
                }
                else if (product == "orange")
                {
                    totalPrice += quantity * 0.90;
                    Console.WriteLine($"{totalPrice:F2}");
                }
                else if (product == "grapefruit")
                {
                    totalPrice += quantity * 1.60;
                    Console.WriteLine($"{totalPrice:F2}");
                }
                else if (product == "kiwi")
                {
                    totalPrice += quantity * 3.00;
                    Console.WriteLine($"{totalPrice:F2}");
                }
                else if (product == "pineapple")
                {
                    totalPrice += quantity * 5.60;
                    Console.WriteLine($"{totalPrice:F2}");
                }
                else if (product == "grapes")
                {
                    totalPrice += quantity * 4.20;
                    Console.WriteLine($"{totalPrice:F2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (dayOfTheWeek == "Monday" || dayOfTheWeek == "Tuesday" || dayOfTheWeek == "Wednesday" || dayOfTheWeek == "Thursday" || dayOfTheWeek == "Friday")
            {
                if (product == "banana")
                {
                    totalPrice += quantity * 2.50;
                    Console.WriteLine($"{totalPrice:F2}");
                }
                else if (product == "apple")
                {
                    totalPrice += quantity * 1.20;
                    Console.WriteLine($"{totalPrice:F2}");
                }
                else if (product == "orange")
                {
                    totalPrice += quantity * 0.85;
                    Console.WriteLine($"{totalPrice:F2}");
                }
                else if (product == "grapefruit")
                {
                    totalPrice += quantity * 1.45;
                    Console.WriteLine($"{totalPrice:F2}");
                }
                else if (product == "kiwi")
                {
                    totalPrice += quantity * 2.70;
                    Console.WriteLine($"{totalPrice:F2}");
                }
                else if (product == "pineapple")
                {
                    totalPrice += quantity * 5.50;
                    Console.WriteLine($"{totalPrice:F2}");
                }
                else if (product == "grapes")
                {
                    totalPrice += quantity * 3.85;
                    Console.WriteLine($"{totalPrice:F2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
