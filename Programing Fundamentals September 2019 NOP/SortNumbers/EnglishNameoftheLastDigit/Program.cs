using System;

namespace EnglishNameoftheLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int lastDigits = int.Parse(input[input.Length - 1].ToString());
            Console.WriteLine(printNum(lastDigits));
        }

        public static string printNum(int n)
        {
            string result = string.Empty;
            switch (n)
            {
                case 0: result = "zero"; break;
                case 1: result = "one"; break;
                case 2: result = "two"; break;
                case 3: result = "three"; break;
                case 4: result = "four"; break;
                case 5: result = "five"; break;
                case 6: result = "six"; break;
                case 7: result = "seven"; break;
                case 8: result = "eighth"; break;
                case 9: result = "nine"; break;

                default: break;
            }
            return result;
        }
    }
}
