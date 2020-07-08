using System;
using System.Text;

namespace Crocs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int firstSection = n / 2;
            int midSection = n * 3;
            int width = n * 5;
            int height = n * 4 + 2;

            //Header
            for (int i = 0; i < firstSection; i++)
            {
                for (int e = 0; e < n; e++)
                {
                    Console.Write(' ');
                }
                for (int m = 0; m < midSection; m++)
                {
                    Console.Write('#');
                }
                for (int e = 0; e < n; e++)
                {
                    Console.Write(' ');
                }
                Console.WriteLine();
            }

            //Body
            for (int e = 0; e < n; e++)
            {
                Console.Write('#');
            }
            for (int m = 0; m < midSection; m++)
            {
                Console.Write(' ');
            }
            for (int e = 0; e < n; e++)
            {
                Console.Write('#');
            }
            Console.WriteLine();
            for (int i = 0; i < n * 2 - 1; i++)
            {
                for (int e = 0; e < n; e++)
                {
                    Console.Write('#');
                }

                Console.Write(' ');
                for (int mid = 0; mid < width - n * 2 - 2; mid++)
                {
                    if (i % 2 == 0)
                    {
                        if (mid % 2 == 0) Console.Write('#');
                        else Console.Write(' ');
                    }
                    else
                    {
                        if (mid % 2 == 0) Console.Write(' ');
                        else Console.Write('#');
                    }
                }
                Console.Write(' ');

                for (int e = 0; e < n; e++)
                {
                    Console.Write('#');
                }
                Console.WriteLine();
            }
            for (int e = 0; e < n; e++)
            {
                Console.Write('#');
            }
            for (int m = 0; m < midSection; m++)
            {
                Console.Write(' ');
            }
            for (int e = 0; e < n; e++)
            {
                Console.Write('#');
            }
            Console.WriteLine();

            for (int i = 0; i < n + 2; i++)
            {
                if (i % 2 == 0)
                {
                    for (int even = 0; even < width; even++)
                    {
                        Console.Write('#');
                    }
                    Console.WriteLine();
                }
                else
                {
                    for (int e = 0; e < n; e++)
                    {
                        Console.Write('#');
                    }
                    for (int odd = 0; odd < width - n * 2; odd++)
                    {
                        if (odd % 2 == 0)
                        {
                            Console.Write(' ');
                        }
                        else
                        {
                            Console.Write('#');
                        }
                    }
                    for (int e = 0; e < n; e++)
                    {
                        Console.Write('#');
                    }
                    Console.WriteLine();
                }
            }

            //Footer
            for (int i = 0; i < firstSection; i++)
            {
                for (int e = 0; e < n; e++)
                {
                    Console.Write(' ');
                }
                for (int m = 0; m < midSection; m++)
                {
                    Console.Write('#');
                }
                for (int e = 0; e < n; e++)
                {
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
