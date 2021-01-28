using System;

namespace CharactersinRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char fChar = char.Parse(Console.ReadLine());
            char lChar = char.Parse(Console.ReadLine());

            int startCharacter = Math.Min(fChar, lChar);
            int endCharacter = Math.Max(fChar, lChar);

            for (int i = ++startCharacter; i < endCharacter; i++) Console.Write((char)i + " ");
            Console.WriteLine();
        }
    }
}
