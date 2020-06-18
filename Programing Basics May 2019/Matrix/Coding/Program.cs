using System;
using System.Text.RegularExpressions;

namespace Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNumber = Console.ReadLine();
            int stringLength = inputNumber.Length;

            for (int i = stringLength - 1; i >= 0; i--)
            {
                int currentIValue = int.Parse(inputNumber.Substring(i, 1));
                if (currentIValue == 0)
                {
                    Console.Write("ZERO");
                }
                for (int j = 0; j < currentIValue; j++)
                {
                    int charValue = currentIValue + 33;
                    Console.Write((char)charValue);
                }
                Console.WriteLine();
            }
        }
    }
}
