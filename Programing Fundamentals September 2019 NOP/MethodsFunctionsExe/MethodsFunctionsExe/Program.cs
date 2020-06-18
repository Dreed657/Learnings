using System;

namespace MethodsFunctionsExe
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[3];

            for (int i = 0; i < 3; i++) input[i] = int.Parse(Console.ReadLine());

            Array.Sort(input);
            Console.WriteLine(input[0]);
        }
    }
}