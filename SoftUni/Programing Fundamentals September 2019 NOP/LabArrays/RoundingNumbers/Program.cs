using System;

namespace RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double[] numbers = new double[words.Length];

            for (int i = 0; i < words.Length; i++)
                numbers[i] = double.Parse(words[i]);

            foreach (double number in numbers)
                Console.WriteLine($"{number} => {Math.Round(number, MidpointRounding.AwayFromZero)}");
        }
    }
}
