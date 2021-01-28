using System;

namespace EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputOne = Console.ReadLine();
            string[] numbersOne = inputOne.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string inputTwo = Console.ReadLine();
            string[] numbersTwo = inputTwo.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int curIndex = 0;
            bool notEquel = false;
            int sum = 0;

            for (int i = 0; i < numbersOne.Length; i++)
            {
                if (numbersOne[i] != numbersTwo[i])
                {
                    curIndex = i;
                    notEquel = true;
                    break;
                }
                else
                    sum += int.Parse(numbersOne[i]);
            }

            if(notEquel)
                Console.WriteLine($"Arrays are not identical. Found difference at {curIndex} index");
            else
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}
