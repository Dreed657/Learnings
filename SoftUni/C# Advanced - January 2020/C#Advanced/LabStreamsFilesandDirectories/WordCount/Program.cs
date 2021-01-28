using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = File.ReadAllLines("words.txt");
            var text = File.ReadAllLines("text.txt");
            var expectedResult = File.ReadAllLines("expectedResult.txt");

            var dict = new Dictionary<string, int>();

            //Do Some Magic Here

            var output = new List<string>();

            foreach (var (key, value) in dict) output.Add($"{key} - {value}");

            File.WriteAllLines("actualResult.txt", output);
        }
    }
}
