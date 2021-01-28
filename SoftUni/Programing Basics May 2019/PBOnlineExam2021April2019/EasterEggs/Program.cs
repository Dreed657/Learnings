using System;

namespace EasterEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int paintedEggsCount = int.Parse(Console.ReadLine());

            int redEggs = 0;
            int orangeEggs = 0;
            int blueEggs = 0;
            int greenEggs = 0;

            int maxEggs = int.MinValue;
            string maxEggsType = string.Empty;

            for (int i = 0; i < paintedEggsCount; i++)
            {
                string color = Console.ReadLine();

                switch (color)
                {
                    case "red": redEggs++; break;
                    case "orange": orangeEggs++; break;
                    case "blue": blueEggs++; break;
                    case "green": greenEggs++; break;
                    default: break;
                }
                if (redEggs > maxEggs)
                {
                    maxEggs = redEggs;
                    maxEggsType = "red";
                }
                else if (orangeEggs > maxEggs)
                {
                    maxEggs = orangeEggs;
                    maxEggsType = "orange";
                }
                else if (blueEggs > maxEggs)
                {
                    maxEggs = blueEggs;
                    maxEggsType = "blue";
                }
                else if (greenEggs > maxEggs)
                {
                    maxEggs = greenEggs;
                    maxEggsType = "green";
                }
            }

            Console.WriteLine($"Red eggs: {redEggs}");
            Console.WriteLine($"Orange eggs: {orangeEggs}");
            Console.WriteLine($"Blue eggs: {blueEggs}");
            Console.WriteLine($"Green eggs: {greenEggs}");
            Console.WriteLine($"Max eggs: {maxEggs} -> {maxEggsType}");
        }
    }
}
