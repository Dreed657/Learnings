namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (string.IsNullOrEmpty(parentheses) || parentheses.Length % 2 == 1)
            {
                return false;
            }

            var openBrackets = new Stack<char>();

            foreach (var currentBracket in parentheses)
            {
                char expectedCharacter = default;

                switch (currentBracket)
                {
                    case ')':
                        expectedCharacter = '(';
                        break;
                    case ']':
                        expectedCharacter = '[';
                        break;
                    case '}':
                        expectedCharacter = '{';
                        break;
                    default:
                        openBrackets.Push(currentBracket);
                        break;
                }

                if (expectedCharacter != default && openBrackets.Pop() != expectedCharacter)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
