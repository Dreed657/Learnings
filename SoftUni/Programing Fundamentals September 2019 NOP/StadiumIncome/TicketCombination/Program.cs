using System;

namespace TicketCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            string combination = string.Empty;
            int sum = 0;

            for (int i = 'B'; i <= 'L'; i += 2)
            {
                for (int j = 'f'; j >= 'a'; j--)
                {
                    for (int k = 'A'; k <= 'C'; k++)
                    {
                        for (int l = 1; l <= 10; l++)
                        {
                            for (int m = 10; m >= 1; m--)
                            {
                                count++;
                                if (count == n)
                                {
                                    combination = $"{(char)i}{(char)j}{(char)k}{(int)l}{(int)m}";
                                    Console.WriteLine($"Ticket combination: {combination}");
                                    sum = (int)i + (int)j + (int)k + (int)l + (int)m;
                                    Console.WriteLine($"Prize: {sum} lv.");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
