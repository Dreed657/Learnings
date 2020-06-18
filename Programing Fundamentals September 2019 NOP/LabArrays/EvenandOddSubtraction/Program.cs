using System;

namespace EvenandOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int sumEven = 0;
            int sumOdd = 0;

            for (int i = 0; i < words.Length; i++)
            {
                int curNum = int.Parse(words[i]);
                if (curNum % 2 == 0)
                    sumEven += curNum;
                else
                    sumOdd += curNum;
            }
            int total = sumEven - sumOdd;

            Console.WriteLine(total);
        }
    }
}
