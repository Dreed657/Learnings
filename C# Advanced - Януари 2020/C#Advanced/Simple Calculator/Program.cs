using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var myStack = new Stack<string>(input.Reverse());

            while (myStack.Count > 1)
            {
                int first = int.Parse(myStack.Pop());
                string operatoryo = myStack.Pop();
                int second = int.Parse(myStack.Pop());

                var tempResult = operatoryo switch
                {
                    "+" => first + second,
                    "-" => first - second,
                    _ => 0
                };

                myStack.Push(tempResult.ToString());
            }
            Console.WriteLine(myStack.Pop());
        }
    }
}
