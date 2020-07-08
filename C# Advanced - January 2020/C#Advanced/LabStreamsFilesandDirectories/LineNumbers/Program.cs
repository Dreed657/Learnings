using System;
using System.IO;
using System.Linq;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("text.txt").ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i].ToCharArray().ToList();
                Console.WriteLine($"Line:{i}{lines[i]} ({line.Where(x => char.IsLetter(x)).ToList().Count}) ({line.Where(x => char.IsPunctuation(x)).ToList().Count})");
            }
        }
    }
}
