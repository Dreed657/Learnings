using System;

namespace SumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int sum = 0;

            for (int i = 0; i < words.Length; i++)
            {
                int curNum = int.Parse(words[i]);
                if (curNum % 2 == 0)
                    sum += curNum;
            }

            Console.WriteLine(sum);
        }
    }
}
