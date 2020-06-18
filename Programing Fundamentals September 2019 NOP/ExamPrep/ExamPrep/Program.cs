using System;
using System.Linq;
using System.Collections.Generic;

namespace ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "Sign") break;

                switch (input[0])
                {
                    case "Case":
                        var caseSencetive = input[1];
                        if (caseSencetive == "lower") name = name.ToLower();
                        else if (caseSencetive == "upper") name = name.ToUpper();

                        Console.WriteLine(name);
                        break;
                    case "Reverse":
                        int startIndex = int.Parse(input[1]);
                        int endIndex = int.Parse(input[2]);

                        bool isStartIndexValid = startIndex < 0 || startIndex > name.Length;
                        bool isEndIndexValid = endIndex < 0 || endIndex > name.Length;

                        if (isStartIndexValid || isEndIndexValid) continue;

                        int lenght = endIndex - startIndex + 1;
                        string subtracted = name.Substring(startIndex, lenght);

                        char[] chars = subtracted.Reverse().ToArray();
                        string reversedString = new string(chars);
                        Console.WriteLine(reversedString);
                        break;
                    case "Cut":
                        var subtracting = input[1];
                        if (name.Contains(subtracting))
                        {
                            name = name.Replace(subtracting, "");
                            Console.WriteLine(name);
                        }
                        else
                        {
                            Console.WriteLine($"The word {name} doesn't contain {subtracting}.");
                        }
                        break;
                    case "Replace":
                        char specChar = char.Parse(input[1]);
                        for (int i = 0; i < name.Length; i++)
                            if (name[i] == specChar) name = name.Replace(name[i], '*');

                        Console.WriteLine(name);
                        break;
                    case "Check":
                        char givenChar = char.Parse(input[1]);
                        if (name.Contains(givenChar)) Console.WriteLine("Valid");
                        else Console.WriteLine($"Your username must contain {givenChar}.");
                        break;
                }
            }
        }
    }
}
