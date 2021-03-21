using System;
using System.Collections.Generic;
using System.Linq;

namespace LeftRotation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var n = input[0];
            var rotations = input[1];

            var result = rotateLeft(rotations, arr);
            Console.WriteLine(string.Join(' ', result));
        }

        public static List<int> rotateLeft(int d, List<int> arr)
        {
            for (int j = 0; j < d; j++)
            {
                for (int i = 0; i < arr.Count - 1; i++)
                {
                    if (i - 1 < 0)
                    {
                        var tmp = arr[^1];
                        arr[^1] = arr[0];
                        arr[0] = tmp;
                    }
                    else
                    {
                        var tmp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = tmp;
                    }
                }
            }

            return arr;
        }
    }
}
