using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] word = Console.ReadLine().ToCharArray();
            Array.Reverse(word);
            foreach (char item in word)
                Console.Write($"{item}");
        }
    }
}
