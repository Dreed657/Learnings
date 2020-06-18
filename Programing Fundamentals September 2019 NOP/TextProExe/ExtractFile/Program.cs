using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var separators = new char[] {
              Path.DirectorySeparatorChar,
              Path.AltDirectorySeparatorChar,
              Path.VolumeSeparatorChar
            };

            StringBuilder strings = new StringBuilder();

            List<string> input = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] file = input[input.Count - 1].Split('.');

            Console.WriteLine($"File name: {file[0]}");
            Console.WriteLine($"File extension: {file[1]}");
        }

        static public int Add(int a, int b) 
        {
            return a + b;
        }
    }
}
