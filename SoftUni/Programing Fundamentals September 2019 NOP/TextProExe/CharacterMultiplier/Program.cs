using System;
using System.Collections.Generic;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int totalSum = 0;

            int biggerNumber = Math.Min(input[0].Length, input[1].Length);

            string wordOne = input[0];
            string wordTwo = input[1];

            for (int i = 0; i < biggerNumber; i++)
            {
                totalSum += wordOne[i] * wordTwo[i];
            }

            if (wordOne.Length > biggerNumber)
            {
                for (int i = biggerNumber; i < wordOne.Length; i++) totalSum += wordOne[i];
            }
            else
            {
                for (int i = biggerNumber; i < wordTwo.Length; i++) totalSum += wordTwo[i];
            }

            Console.WriteLine(t);
        }
    }
}
