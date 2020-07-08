using System;
using System.Collections.Generic;
using System.Linq;

namespace Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            var leftSocks = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            var rightSocks = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            int biggestPair = int.MinValue;
            var pairs = new Queue<int>();


            while (leftSocks.Any() && rightSocks.Any())
            {
                int sockOne = leftSocks.Peek();
                int sockTwo = rightSocks.Peek();

                if (sockOne > sockTwo)
                {
                    int currPair = sockTwo + sockOne;
                    pairs.Enqueue(currPair);

                    if (currPair > biggestPair)
                    {
                        biggestPair = currPair;
                    }

                    leftSocks.Pop();
                    rightSocks.Dequeue();
                }
                else if (sockOne < sockTwo)
                {
                    leftSocks.Pop();
                }
                else if (sockOne == sockTwo)
                {
                    rightSocks.Dequeue();
                    leftSocks.Push(leftSocks.Pop() + 1);
                }
            }

            Console.WriteLine(biggestPair);
            Console.WriteLine(string.Join(' ', pairs));
        }
    }
}
