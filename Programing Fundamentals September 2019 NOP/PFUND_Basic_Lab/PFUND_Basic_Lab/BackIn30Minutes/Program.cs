using System;

namespace BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int totalTimeInMinustes = (hours * 60) + minutes;
            int printableTime = totalTimeInMinustes + 30;

            int printHours = printableTime / 60;
            int printMinutes = printableTime % 60;

            if (printhours == 24) printhours = 0;
            if (printMinutes < 10)
                Console.WriteLine($"{printHours}:0{printMinutes}");
            else
                Console.WriteLine($"{printHours}:{printMinutes}");
        }
    }
}
