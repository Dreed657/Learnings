using System;

namespace CondenseArraytoNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] nums = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] unums = new int[nums.Length];

            if (nums.Length != 1)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    unums[i] = int.Parse(nums[i]);
                }

                int[] condensed = new int[nums.Length - 1];

                while (condensed.Length > 0)
                {
                    for (int i = 0; i < unums.Length - 1; i++)
                    {
                        condensed[i] = unums[i] + unums[i + 1];
                    }

                    if (condensed.Length == 1)
                        break;
                    else
                    {
                        unums = new int[condensed.Length];
                        for (int i = 0; i < condensed.Length; i++)
                        {
                            unums[i] = condensed[i];
                        }
                        condensed = new int[unums.Length - 1];
                    }
                }

                Console.WriteLine($"{condensed[0]}");
            }
            else
                Console.WriteLine($"{nums[0]}");
        }
    }
}
