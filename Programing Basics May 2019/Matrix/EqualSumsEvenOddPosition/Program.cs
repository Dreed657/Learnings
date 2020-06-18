using System;

namespace EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            int evenSum = 0;
            int oddSum = 0;

            for (int i = num1; i <= num2; i++)
            {
                string iToNum = i.ToString();
                for (int j = 0; j < iToNum.Length; j++)
                {
                    if (j % 2 == 0)
                        evenSum += iToNum[j];
                    else
                        oddSum += iToNum[j];
                }

                if (evenSum == oddSum)
                    Console.Write($"{i} ");

                evenSum = 0;
                oddSum = 0;
            }
            Console.WriteLine();
        }
    }
}
