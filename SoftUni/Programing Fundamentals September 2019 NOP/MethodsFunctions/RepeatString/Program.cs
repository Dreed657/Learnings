using System;

namespace RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatStr(input, count));
        }

        static string RepeatStr(string str, int count)
        {
            string res = string.Empty;

            for (int i = 0; i < count; i++)
            {
                res += string.Join("", str);
            }

            return res;
        }
    }
}
