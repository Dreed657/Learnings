using System;
using System.Linq;

namespace PointinRectangle
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var rectTokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            var rect = new Rectangle(new Point(rectTokens[0], rectTokens[1]), new Point(rectTokens[2], rectTokens[3]));

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var point = new Point(tokens[0], tokens[1]);

                Console.WriteLine(rect.Contains(point));
            }
        }
    }
}
