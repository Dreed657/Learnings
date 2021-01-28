using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("text.txt");
            var replaces = new char[]{ '-', ',', '.', '!', '?'};
            int count = 0;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (line == null) break;
                if(count % 2 == 0)
                {
                    foreach (var ch in replaces) line = line.Replace(ch, '@');
                    Console.WriteLine(string.Join(' ', line.Split().Reverse()));
                }
                count++;
            }
        }
    }
}
