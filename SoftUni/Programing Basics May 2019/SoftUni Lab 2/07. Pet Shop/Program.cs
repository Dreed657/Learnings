using System;

namespace _07._Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogsCount = int.Parse(Console.ReadLine());
            int otherAnimals = int.Parse(Console.ReadLine());
            double sumDogFood = dogsCount * 2.5;
            double sumOtherDogFood = otherAnimals * 4;
            double rawCheckOut = sumDogFood + sumOtherDogFood;
            double checkOut = Math.Round(rawCheckOut, 2);

            Console.WriteLine("{0:F2} lv.", checkOut);
        }
    }
}
