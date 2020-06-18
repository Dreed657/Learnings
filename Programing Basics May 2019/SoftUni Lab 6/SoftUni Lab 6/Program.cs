using System;

namespace SoftUni_Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeFirst = int.Parse(Console.ReadLine());
            int timeSecound = int.Parse(Console.ReadLine());
            int timeThird = int.Parse(Console.ReadLine());

            int totalTime = timeFirst + timeSecound + timeThird;
            int minutes = totalTime / 60;
            int seconds = totalTime % 60;

            if (seconds < 10)
                Console.WriteLine($"{minutes}:0{seconds}");
            else
                Console.WriteLine($"{minutes}:{seconds}");
        }
    }
}
