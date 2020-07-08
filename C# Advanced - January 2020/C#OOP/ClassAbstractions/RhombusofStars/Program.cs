using System;
using System.Text;

namespace RhombusofStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            for (int stCount = 1; stCount <= size; stCount++)
                PrintRow(size, stCount);

            for (int stCount = size - 1; stCount >= 1; stCount--)
                PrintRow(size, stCount);
        }

        public static void PrintRow(int size, int count)
        {
            var sb = new StringBuilder();

            for (int i = 0; i <= size - count; i++)
                sb.Append(' ');

            for (int i = 0; i < count; i++)
                sb.Append("* ");

            Console.WriteLine(sb.ToString());
        }
    }
}
