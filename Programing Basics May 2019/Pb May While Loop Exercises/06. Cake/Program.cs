using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            int totalPieces = width * length;

            while (totalPieces >= 0)
            {
                string input = Console.ReadLine();
                if (input == "STOP")
                {
                    Console.WriteLine($"{totalPieces} pieces are left.");
                    break;
                }
                else
                {
                    totalPieces -= int.Parse(input);
                }
            }

            if (totalPieces < 0)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(totalPieces)} pieces more.");
            }
        }
    }
}
