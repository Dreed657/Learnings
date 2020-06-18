using System;

namespace BestPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxGoals = int.MinValue;
            string bestPlayer = string.Empty;
            bool hetTrick = false;

            while (true)
            {
                string playerName = Console.ReadLine();
                if (playerName == "END" || playerName == " " || playerName == null || playerName == string.Empty) break;

                int goals = int.Parse(Console.ReadLine());

                if (goals > maxGoals)
                {
                    maxGoals = goals;
                    bestPlayer = playerName;
                    if (maxGoals >= 3)
                        hetTrick = true;
                }
            }

            Console.WriteLine($"{bestPlayer} is the best player!");
            if (hetTrick)
                Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
            else
                Console.WriteLine($"He has scored {maxGoals} goals.");
        }
    }
}
