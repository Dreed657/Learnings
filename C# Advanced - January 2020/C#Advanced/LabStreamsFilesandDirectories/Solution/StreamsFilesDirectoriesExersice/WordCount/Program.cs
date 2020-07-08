using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllLines("text.txt");
            var words = File.ReadAllLines("words.txt");
            var replaces = new char[] { '-', ',', '.', '!', '?' };

            var dict = new Dictionary<string, int>();

            for (int i = 0; i < text.Length; i++)
            {
                string currentLine = text[i];
                foreach (var ch in replaces) currentLine = currentLine.Replace(ch, ' ');

                var correctedWords = currentLine
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                    
                foreach (var word in words)
                {
                    var temp = correctedWords.Where(x => x.ToLower() == word.ToLower()).Count();

                    if (!dict.ContainsKey(word)) dict.Add(word, 0);

                    dict[word] += temp;
                }
            }

            var output = new List<string>();

            foreach (var (key, value) in dict.OrderByDescending(x => x.Value))
            {
                output.Add($"{key} - {value}");
            }
            File.WriteAllLines("actualResult.txt", output);
        }
    }
}
