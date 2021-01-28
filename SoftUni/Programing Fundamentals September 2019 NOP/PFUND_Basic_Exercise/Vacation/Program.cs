using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupSize = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0.0d;
            double discount = 0;

            switch (type)
            {
                case "Students":
                    switch (day)
                    {
                        case "Friday": price = 8.45; break;
                        case "Saturday": price = 9.80; break;
                        case "Sunday": price = 10.46; break;
                        default: break;
                    }
                    if (groupSize >= 30) discount = 15;
                    break;
                case "Business":
                    switch (day)
                    {
                        case "Friday": price = 10.90; break;
                        case "Saturday": price = 15.60; break;
                        case "Sunday": price = 16.00; break;
                        default: break;
                    }
                    if (groupSize >= 100) groupSize -= 10;
                    break;
                case "Regular":
                    switch (day)
                    {
                        case "Friday": price = 15; break;
                        case "Saturday": price = 20; break;
                        case "Sunday": price = 22.50; break;
                        default: break;
                    }
                    if (groupSize >= 10 && groupSize <= 20) discount = 5;
                    break;
                default: break;
            }
            double totalPrice = price * groupSize;
            double discounted = totalPrice - (totalPrice * (discount / 100));

            Console.WriteLine($"Total price: {discounted:F2}");
        }
    }
}
