using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("text.txt");
            StreamWriter writer = new StreamWriter("output.txt");
            int count = 0;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (line == null) break;

                int letterCount = line.Where(x => char.IsLetter(x)).ToList().Count;
                int puntMarks = line.Where(x => char.IsPunctuation(x)).ToList().Count;
          
                writer.WriteLine($"Line {count}: {line} ({letterCount})({puntMarks})", FileMode.OpenOrCreate);

                count++;
            }
            writer.Close();
        }
    }
}
