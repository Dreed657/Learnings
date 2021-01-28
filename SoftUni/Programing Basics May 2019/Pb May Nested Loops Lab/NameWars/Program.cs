using System;

namespace NameWars
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int maxValue = int.MinValue;
            string currentWinner = string.Empty;

            while (true)
            {
                string name = Console.ReadLine();
                if (name == "STOP") break;

                foreach (char letter in name)
                    sum += (int)letter;

                if (sum > maxValue)
                {
                    maxValue = sum;
                    currentWinner = name;
                    sum = 0;
                }
                else
                    sum = 0;
            }

            Console.WriteLine($"Winner is {currentWinner} - {maxValue}!");
        }
    }
}
