namespace OddLines
{
    using System;
    using System.IO;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var path = "text.txt";
            var lines = File.ReadAllLines(path);
            var output = new List<string>();

            for (int i = 0; i < lines.Length; i++) if (i % 2 == 1) output.Add(lines[i] + "\n");

            File.WriteAllLines(path, output);
        }
    }
}
