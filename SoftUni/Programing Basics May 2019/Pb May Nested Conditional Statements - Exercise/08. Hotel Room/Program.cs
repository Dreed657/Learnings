using System;

namespace _08._Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double studioPrice = 0.0d;
            double apartamentPrice = 0.0d;


            if (month == "May" || month == "October")
            {
                studioPrice += nights * 50;
                if (nights > 7 && nights <= 14)
                    studioPrice -= studioPrice * 0.05;
                else if (nights > 14)
                    studioPrice -= studioPrice * 0.30;

                apartamentPrice += nights * 65;
                if (nights > 14)
                    apartamentPrice -= apartamentPrice * 0.10;
            }
            else if (month == "June" || month == "September")
            {
                studioPrice += nights * 75.20;
                if (nights > 14)
                    studioPrice -= studioPrice * 0.20;

                apartamentPrice += nights * 68.70;
                if (nights > 14)
                    apartamentPrice -= apartamentPrice * 0.10;
            }
            else if (month == "July" || month == "August")
            {
                studioPrice += nights * 76;
                apartamentPrice += nights * 77;
                if (nights > 14)
                    apartamentPrice -= apartamentPrice * 0.10;
            }

            Console.WriteLine($"Apartment: {apartamentPrice:F2} lv.");
            Console.WriteLine($"Studio: {studioPrice:F2} lv.");
        }
    }
}
