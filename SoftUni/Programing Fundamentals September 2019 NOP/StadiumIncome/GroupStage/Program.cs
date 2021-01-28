using System;

namespace GroupStage
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            int playedMatches = int.Parse(Console.ReadLine());
            int points = 0;
            int totalGoalsSended = 0;
            int totalGoalsRecived = 0;

            for (int i = 0; i < playedMatches; i++)
            {
                int goalsSend = int.Parse(Console.ReadLine());
                int goalsRecived = int.Parse(Console.ReadLine());

                totalGoalsSended += goalsSend;
                totalGoalsRecived += goalsRecived;

                if (goalsSend > goalsRecived)
                    points += 3;
                if (goalsRecived == goalsSend)
                    points += 1;
            }

            if (totalGoalsSended >= totalGoalsRecived)
            {
                int diff = totalGoalsSended - totalGoalsRecived;
                Console.WriteLine($"{team} has finished the group phase with {points} points.\nGoal difference: {diff}.");
            }
            else
            {
                int diff = totalGoalsSended - totalGoalsRecived;
                Console.WriteLine($"{team} has been eliminated from the group phase.\nGoal difference: {diff}.");
            }
        }
    }
}
