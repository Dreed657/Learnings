using System;
using System.Linq;

namespace SpinWords
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static string SpinWords(string sentence)
        {
            string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++)
            {
                if (words[i].Length >= 5)
                {
                    words[i] = new String(words[i].Reverse().ToArray());
                }
            }

            return string.Join(' ', words);
        }
    }
}
