using System;
using System.Linq;

namespace EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int curIndex = 0;
            bool itsFucked = false;

            for (int i = 0; i < input.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                for (int l = 0; l < i; l++)
                    leftSum += input[l];

                for (int r = i + 1; r < input.Length; r++)
                    rightSum += input[r];

                if (leftSum == rightSum)
                {
                    curIndex = i;
                    itsFucked = false;
                    break;
                }
                else itsFucked = true;
            }
            if (!itsFucked) Console.WriteLine(curIndex);
            else Console.WriteLine("no");
        }
    }
}
