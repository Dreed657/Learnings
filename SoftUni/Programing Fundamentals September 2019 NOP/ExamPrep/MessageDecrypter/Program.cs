using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace MessageDecrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            // Regex
            string pattern = @"^([$%])([A-Z]{1}[a-z]{2,})(\1):\s[\[](\d+)[\]]\|[\[](\d+)[\]]\|[\[](\d+)[\]]\|$";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);
                
                if(match.Success)
                {
                    string tag = match.Groups[2].Value;
                    string message = string.Empty;

                    message += (char)int.Parse(match.Groups[4].Value);
                    message += (char)int.Parse(match.Groups[5].Value);
                    message += (char)int.Parse(match.Groups[6].Value);

                    Console.WriteLine($"{tag}: {message}");
                }
                else Console.WriteLine("Valid message not found!");
            }
        }
    }
}
