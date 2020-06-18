using System;
using System.Linq;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int firstNumber = numbers[0];

                for (int j = 1; j < numbers.Length; j++)
                    numbers[j - 1] = numbers[j];

                numbers[numbers.Length - 1] = firstNumber;
            }

            foreach (var item in numbers)
                Console.Write(item + " ");
        }
    }
}
