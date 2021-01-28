using System;

namespace EasterCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int kuzonakCount = int.Parse(Console.ReadLine());

            int currentGrade = 0;
            int bestGrade = 0;
            string bestChef = string.Empty;
            string chefName = string.Empty;

            for (int i = 0; i < kuzonakCount; i++)
            {
                chefName = Console.ReadLine();
                while (true)
                {
                    string input = Console.ReadLine();

                    if (input == "Stop")
                        break;
                    else
                    {
                        int gradeForKozunak = int.Parse(input);
                        currentGrade += gradeForKozunak;
                    }
                }
                Console.WriteLine($"{chefName} has {currentGrade} points.");
                if (currentGrade > bestGrade)
                {
                    bestGrade = currentGrade;
                    bestChef = chefName;
                    Console.WriteLine($"{chefName} is the new number 1!");
                }
                currentGrade = 0;
            }
            Console.WriteLine($"{bestChef} won competition with {bestGrade} points!");
        }
    }
}
