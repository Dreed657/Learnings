using System;

namespace GameInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            int playedMatches = int.Parse(Console.ReadLine());

            double sum = 0;
            double averageTime = 0;
            int additional = 0;
            int penalties = 0;

            for (int i = 0; i < playedMatches; i++)
            {
                int playTime = int.Parse(Console.ReadLine());
                sum += playTime;

                if (playTime > 90)
                {
                    additional++;
                    if (playTime > 120)
                        penalties++;
                }

            }
            averageTime = sum / playedMatches;

            Console.WriteLine($"{teamName} has played {sum} minutes. Average minutes per game: {averageTime:F2}");
            Console.WriteLine($"Games with penalties: {penalties}");
            Console.WriteLine($"Games with additional time: {additional - penalties}");
        }
    }
}
