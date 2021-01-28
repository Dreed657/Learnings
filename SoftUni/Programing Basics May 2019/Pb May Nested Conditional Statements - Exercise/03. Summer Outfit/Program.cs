using System;

namespace _03._Summer_Outfit
{
    class Program
    {
        static void Main(string[] args)
        {
            double temp = double.Parse(Console.ReadLine());
            string timeOftheDay = Console.ReadLine();
            string Outfit = "Placeholder";
            string Shoes = "Placeholder";

            if (temp >= 10 && temp <= 18)
            {
                if (timeOftheDay == "Morning")
                {
                    Outfit = "Sweatshirt";
                    Shoes = "Sneakers";
                }
                else if (timeOftheDay == "Afternoon")
                {
                    Outfit = "Shirt";
                    Shoes = "Moccasins";
                }
                else if (timeOftheDay == "Evening")
                {
                    Outfit = "Shirt";
                    Shoes = "Moccasins";
                }
            }
            else if (temp > 18 && temp <= 24)
            {
                if (timeOftheDay == "Morning")
                {
                    Outfit = "Shirt";
                    Shoes = "Moccasins";
                }
                else if (timeOftheDay == "Afternoon")
                {
                    Outfit = "T-Shirt";
                    Shoes = "Sandals";
                }
                else if (timeOftheDay == "Evening")
                {
                    Outfit = "Shirt";
                    Shoes = "Moccasins";
                }
            }
            else if (temp >= 25)
            {
                if (timeOftheDay == "Morning")
                {
                    Outfit = "T-Shirt";
                    Shoes = "Sandals";
                }
                else if (timeOftheDay == "Afternoon")
                {
                    Outfit = "Swim Suit";
                    Shoes = "Barefoot";
                }
                else if (timeOftheDay == "Evening")
                {
                    Outfit = "Shirt";
                    Shoes = "Moccasins";
                }
            }

            Console.WriteLine($"It's {temp} degrees, get your {Outfit} and {Shoes}.");
        }
    }
}
