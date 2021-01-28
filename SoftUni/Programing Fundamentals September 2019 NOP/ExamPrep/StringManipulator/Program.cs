using System;

namespace StringManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];
                if (command == "End") break;

                switch (command)
                {
                    case "Translate":
                        char findThis = char.Parse(tokens[1]);
                        char replacment = char.Parse(tokens[2]);
                        var translation = input.ToCharArray();
                        for (int i = 0; i < translation.Length; i++)
                        {
                            if (translation[i] == findThis)
                            {
                                translation[i] = replacment;
                            }
                        }
                        input = string.Join("", translation);
                        Console.WriteLine(input);
                        break;
                    case "Includes":
                        string check = tokens[1];
                        if (input.Contains(check)) Console.WriteLine("True");
                        else Console.WriteLine("False");
                        break;
                    case "Start":
                        string checkThis = tokens[1];
                        if (input.StartsWith(checkThis)) Console.WriteLine("True");
                        else Console.WriteLine("False");
                        break;
                    case "Lowercase":
                        input = input.ToLower();
                        Console.WriteLine(input);
                        break;
                    case "FindIndex":
                        char findThisChar = char.Parse(tokens[1]);
                        int currentLastIndex = 0;
                        for (int i = 0; i < input.Length; i++)
                        {
                            if (input[i] == findThisChar) currentLastIndex = i;
                        }
                        Console.WriteLine(currentLastIndex);
                        break;
                    case "Remove":
                        int startIndex = int.Parse(tokens[1]);
                        int count = int.Parse(tokens[2]);
                        input = input.Remove(startIndex, count);
                        Console.WriteLine(input);
                        break;
                }
            }
        }
    }
}
