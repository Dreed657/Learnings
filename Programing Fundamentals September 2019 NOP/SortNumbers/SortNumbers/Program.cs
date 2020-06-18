using System;

namespace SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3];

            for (int i = 0; i < 3; i++)
                numbers[i] = int.Parse(Console.ReadLine());

            Array.Sort(numbers);
            Array.Reverse(numbers);

            foreach (var item in numbers)
                Console.WriteLine(item);
        }
    }
}
