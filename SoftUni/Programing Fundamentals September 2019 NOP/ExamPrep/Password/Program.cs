using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(.+)>([0-9]{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<(\1)";
            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);

                if (!match.Success)
                {
                    Console.WriteLine("Try another password!");
                    continue;
                }

                string number = match.Groups[2].Value;
                string lowerLetters = match.Groups[3].Value;
                string upperLetters = match.Groups[4].Value;
                string symbols = match.Groups[5].Value;

                Console.WriteLine($"Password: {number}{lowerLetters}{upperLetters}{symbols}");
            }
        }
    }
}
