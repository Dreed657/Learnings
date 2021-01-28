using System;

namespace Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int passengersCount = int.Parse(Console.ReadLine());
            int stops = int.Parse(Console.ReadLine());

            for (int i = 0; i < stops; i++)
            {
                int gettingOff = int.Parse(Console.ReadLine());
                int gettingOn = int.Parse(Console.ReadLine());

                passengersCount -= gettingOff;
                passengersCount += gettingOn;

                if (i % 2 == 0)
                    passengersCount += 2;
                if (i > 0)
                    if (!(i % 2 == 0))
                        passengersCount -= 2;
            }

            Console.WriteLine($"The final number of passengers is : {passengersCount}");
        }
    }
}
