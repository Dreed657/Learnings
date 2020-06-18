using System;
using System.Collections.Generic;
using System.Linq;

namespace Toplongegers
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            List<long> numberList = new List<long>();
            bool isBigger = false;

            for (long i = 0; i < numbers.Length; i++)
            {
                for (long j = i; j < numbers.Length - 1; j++)
                {
                    long curNumber = numbers[i];
                    long nextNumber = numbers[j + 1];

                    if (curNumber >= nextNumber) isBigger = true;
                    else
                    {
                        isBigger = false;
                        break;
                    }
                }
                if (isBigger) numberList.Add(numbers[i]);
            }

            foreach (var item in numberList) Console.Write(item + " ");
        }
    }
}
