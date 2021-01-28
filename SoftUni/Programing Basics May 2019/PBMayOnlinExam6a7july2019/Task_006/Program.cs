using System;

namespace Task_006
{
    class Program
    {
        static void Main(string[] args)
        {
            string bestWord = string.Empty;
            double bestSum = double.MinValue;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End of words") break;

                double currentWordSum = 0;
                int wordLenght = input.Length;
                char firstChar = input[0];

                foreach (char letter in input)
                {
                    currentWordSum += letter;
                }

                if (firstChar == 'a' || firstChar == 'e' || firstChar == 'i' || firstChar == 'o' || firstChar == 'u' || firstChar == 'y' ||
                    firstChar == 'A' || firstChar == 'E' || firstChar == 'I' || firstChar == 'O' || firstChar == 'U' || firstChar == 'Y')
                {
                    currentWordSum = currentWordSum * wordLenght;
                }
                else
                {
                    currentWordSum = Math.Floor(currentWordSum / wordLenght);
                }

                if (currentWordSum > bestSum)
                {
                    bestWord = input;
                    bestSum = currentWordSum;
                }
                currentWordSum = 0;
            }

            Console.WriteLine($"The most powerful word is {bestWord} - {bestSum}");
        }
    }
}
