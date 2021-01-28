using System;

namespace _05._Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int startHour = int.Parse(Console.ReadLine());
            int startMinutes = int.Parse(Console.ReadLine());

            int timeInMinutes = startHour * 60 + startMinutes;

            int timePlus15 = timeInMinutes + 15;

            int finalHour = timePlus15 / 60;
            int finalminutes = timePlus15 % 60;

            if (finalHour >= 24)
            {
                finalHour -= 24;
            }

            if (finalminutes < 10)
                Console.WriteLine($"{finalHour}:0{finalminutes}");
            else
                Console.WriteLine($"{finalHour}:{finalminutes}");
        }
    }
}
