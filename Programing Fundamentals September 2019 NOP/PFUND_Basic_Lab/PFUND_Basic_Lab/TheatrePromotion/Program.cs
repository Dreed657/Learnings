using System;

namespace TheatrePromotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int ticketPrice = 0;
            bool error = false;

            switch (day)
            {
                case "Weekday":
                    if (age >= 0 && age <= 18) ticketPrice = 12;
                    else if (age >= 18 && age <= 64) ticketPrice = 18;
                    else if (age >= 64 && age <= 122) ticketPrice = 12;
                    else error = true;
                    break;
                case "Weekend":
                    if (age >= 0 && age <= 18) ticketPrice = 15;
                    else if (age >= 18 && age <= 64) ticketPrice = 20;
                    else if (age >= 64 && age <= 122) ticketPrice = 15;
                    else error = true;
                    break;
                case "Holiday":
                    if (age >= 0 && age <= 18) ticketPrice = 5;
                    else if (age >= 18 && age <= 64) ticketPrice = 12;
                    else if (age >= 64 && age <= 122) ticketPrice = 10;
                    else error = true;
                    break;
            }
            if (!error) 
                Console.WriteLine($"{ticketPrice}$");
            else
                Console.WriteLine("Error!");
        }
    }
}
