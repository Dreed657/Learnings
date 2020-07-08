using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText(@".\Input.txt");
            Console.WriteLine(text);
        }
    }
}
