using System;
using System.Linq;
using System.Collections.Generic;

namespace DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var males = new Stack<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            var famales = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            int matches = 0;

            while (males.Any() && famales.Any())
            {
                int male = males.Peek();
                int famale = famales.Peek();

                if(male > 0 && famale > 0)
                {
                    if (male % 25 == 0)
                    {
                        if (males.Count > 1)
                        {
                            males.Pop();
                            males.Pop();
                        }
                        else
                        {
                            males.Pop();
                            break;
                        }
                        if (males.Any()) male = males.Peek();
                        else break;
                    }
                    if (famale % 25 == 0)
                    {
                        if (famales.Count > 1)
                        {
                            famales.Dequeue();
                            famales.Dequeue();
                        }
                        else
                        {
                            famales.Dequeue();
                            break;
                        }
                        if (famales.Any()) famale = famales.Peek();
                        else break;
                    }
                }

                if (male <= 0)
                {
                    males.Pop();
                    if (males.Any())
                    {
                        if (males.Peek() != 0)
                        {
                            male = males.Peek();
                        }
                        else
                        {
                            var cur = 1;
                            while (cur != 0)
                            {
                                try
                                {
                                    cur = males.Pop();
                                }
                                catch (Exception)
                                {
                                    break;
                                }
                            }
                            male = males.Peek();
                        }
                    }
                    else break;
                }
                
                if (famale <= 0)
                {
                    famales.Dequeue();
                    famale = famales.Peek();
                    
                    if (famales.Any())
                    {
                        if (famales.Peek() != 0)
                        {
                            famale = famales.Peek();
                        }
                        else
                        {
                            var cur = 1;
                            while (cur != 0)
                            {
                                try
                                {
                                    cur = famales.Dequeue();
                                }
                                catch (Exception)
                                {
                                    break;
                                }
                            }
                            famale = famales.Peek();
                        }
                    }
                    else break;
                }
                
                if (male == famale)
                {
                    matches++;
                    if (males.Any()) males.Pop();
                    else break;
                    if (famales.Any()) famales.Dequeue();
                    else break;
                }
                else
                {
                    if (famales.Any()) famales.Dequeue();
                    else break;
                    males.Push(males.Pop() - 2);
                }
            }

            Console.WriteLine($"Matches: {matches}");
        
            if (males.Any())
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if (famales.Any())
            {
                Console.WriteLine($"Females left: {string.Join(", ", famales)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
