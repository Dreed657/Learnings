using System;

namespace _09._Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            int Length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            int volume = Length * width * height;
            double maxVolume = volume * 0.001;
            double percentage = percent * 0.01;
            double realVolume = volume * (1 - percentage);


            double result = realVolume / 1000;

            Console.WriteLine($"{result:F3}");
        }
    }
}
