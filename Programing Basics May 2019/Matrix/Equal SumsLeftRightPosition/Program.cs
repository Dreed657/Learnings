using System;

namespace Equal_SumsLeftRightPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            int leftSum = 0;
            int rightSum = 0;
            for (int i = num1; i <= num2; i++)
            {
                string iToNum = i.ToString();
                leftSum = (int.Parse(iToNum[0].ToString()) + int.Parse(iToNum[1].ToString()));
                rightSum = (int.Parse(iToNum[3].ToString()) + int.Parse(iToNum[4].ToString()));
                if (leftSum != rightSum)
                {
                    if (leftSum < rightSum)
                        leftSum += int.Parse(iToNum[2].ToString());
                    else
                        rightSum += int.Parse(iToNum[2].ToString());
                }

                if (leftSum == rightSum)
                    Console.Write($"{i} ");

                leftSum = 0;
                rightSum = 0;
            }
            Console.WriteLine();
        }
    }
}
