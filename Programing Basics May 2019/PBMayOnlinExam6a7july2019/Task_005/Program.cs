using System;

namespace Task_005
{
    class Program
    {
        static void Main(string[] args)
        {
            string footballTeam = Console.ReadLine();
            int matchesPlayed = int.Parse(Console.ReadLine());

            double winsCount = 0;
            int drawCount = 0;
            int loseCount = 0;

            int points = 0;

            for (int i = 0; i < matchesPlayed; i++)
            {
                string matchResults = Console.ReadLine();

                switch (matchResults)
                {
                    case "W": winsCount++; points += 3; break;
                    case "D": drawCount++; points++; break;
                    case "L": loseCount++; break;
                    default: break;
                }
            }

            double p = (winsCount / matchesPlayed) * 100;

            if (matchesPlayed == 0)
                Console.WriteLine($"{footballTeam} hasn't played any games during this season.");
            else
            {
                Console.WriteLine($"{footballTeam} has won {points} points during this season.");
                Console.WriteLine($"Total stats:");
                Console.WriteLine($"## W: {winsCount}");
                Console.WriteLine($"## D: {drawCount}");
                Console.WriteLine($"## L: {loseCount}");
                Console.WriteLine($"Win rate: {p:f2}%");
            }
        }
    }
}
