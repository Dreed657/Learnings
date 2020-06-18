using System;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int j = int.Parse(Console.ReadLine());

            int letterIndex = 0;
            int charIndex = 0;

            for (int i = 'a'; i < 'z'; i++)
            {
                if (letterIndex == j)
                {
                    charIndex = i;
                    break;
                }
                letterIndex++;
            }

            for (int num1 = 1; num1 <= n; num1++)
            {
                for (int num2 = 1; num2 <= n; num2++)
                {
                    for (char letter1 = 'a'; letter1 < charIndex; letter1++)
                    {
                        for (char letter2 = 'a'; letter2 < charIndex; letter2++)
                        {
                            for (int num3 = 1; num3 <= n; num3++)
                            {
                                if((num3 > num1) && (num3 > num2))
                                    Console.Write($"{num1}{num2}{letter1}{letter2}{num3} ");
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
