using System;

namespace LettersCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char letter1 = char.Parse(Console.ReadLine());
            char letter2 = char.Parse(Console.ReadLine());
            char letter3 = char.Parse(Console.ReadLine());

            int counter = 0;

            for (char i = letter1; i <= letter2; i++)
            {
                for (char j = letter1; j <= letter2; j++)
                {
                    for (char p = letter1; p <= letter2; p++)
                    {
                        if (i != letter3 && j != letter3 && p != letter3)
                        {
                            Console.Write($"{i}{j}{p} ");
                            counter++;
                        }
                    }
                }
            }
            Console.Write($"{counter} ");
            Console.WriteLine();
        }
    }
}
