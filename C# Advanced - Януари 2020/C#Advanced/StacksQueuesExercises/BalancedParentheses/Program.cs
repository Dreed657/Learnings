using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            string leftSide = input.Substring(0, input.Length / 2);
            string rightSide = input.Substring(input.Length / 2);
            var leftStack = new Stack<char>(leftSide.ToCharArray());
            var rightStack = new Stack<char>(rightSide.ToCharArray().Reverse());

            bool isBalanced = false;

            while (leftStack.Any() && rightStack.Any())
            {
                char firstBracket = leftStack.Pop();
                char secondBracket = rightStack.Pop();

                switch (firstBracket)
                {
                    case '(':
                        if (secondBracket == ')') isBalanced = true;
                        else isBalanced = false; 
                        break;
                    case '{':
                        if (secondBracket == '}') isBalanced = true;
                        else isBalanced = false;
                        break;
                    case '[':
                        if (secondBracket == ']') isBalanced = true;
                        else isBalanced = false;
                        break;
                }
            }

            if (isBalanced) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }
    }
}
