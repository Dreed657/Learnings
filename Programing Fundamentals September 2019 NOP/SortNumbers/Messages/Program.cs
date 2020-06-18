using System;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char currentChar = '\0';
            string word = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int digit = int.Parse(input[0].ToString());
                int keyPresses = input.Length;

                switch (digit)
                {
                    case 0: currentChar = ' '; break;
                    case 2:
                        if (keyPresses == 1) currentChar = 'a';
                        if (keyPresses == 2) currentChar = 'b';
                        if (keyPresses == 3) currentChar = 'c';
                        break;
                    case 3:
                        if (keyPresses == 1) currentChar = 'd';
                        if (keyPresses == 2) currentChar = 'e';
                        if (keyPresses == 3) currentChar = 'f';
                        break;
                    case 4:
                        if (keyPresses == 1) currentChar = 'g';
                        if (keyPresses == 2) currentChar = 'h';
                        if (keyPresses == 3) currentChar = 'i';
                        break;
                    case 5:
                        if (keyPresses == 1) currentChar = 'j';
                        if (keyPresses == 2) currentChar = 'k';
                        if (keyPresses == 3) currentChar = 'l';
                        break;
                    case 6:
                        if (keyPresses == 1) currentChar = 'm';
                        if (keyPresses == 2) currentChar = 'n';
                        if (keyPresses == 3) currentChar = 'o';
                        break;
                    case 7:
                        if (keyPresses == 1) currentChar = 'p';
                        if (keyPresses == 2) currentChar = 'q';
                        if (keyPresses == 3) currentChar = 'r';
                        if (keyPresses == 4) currentChar = 's';
                        break;
                    case 8:
                        if (keyPresses == 1) currentChar = 't';
                        if (keyPresses == 2) currentChar = 'u';
                        if (keyPresses == 3) currentChar = 'v';
                        break;
                    case 9:
                        if (keyPresses == 1) currentChar = 'w';
                        if (keyPresses == 2) currentChar = 'x';
                        if (keyPresses == 3) currentChar = 'y';
                        if (keyPresses == 4) currentChar = 'z';
                        break;
                    default: break;
                }
                word += currentChar;
            }
            Console.WriteLine(word);
        }
    }
}
