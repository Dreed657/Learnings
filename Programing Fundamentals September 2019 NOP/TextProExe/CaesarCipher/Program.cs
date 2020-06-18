using System;
using System.Diagnostics;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string newResult = string.Empty;

            Stopwatch timer = new Stopwatch();

            timer.Start();

            foreach (var item in input)
            {
                int newChar = item + 3;
                newResult += (char)newChar;
            }

            timer.Stop();

            Console.WriteLine($"{newResult} + { timer.ElapsedTicks:F3}");
        }
    }
}
