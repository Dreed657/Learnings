
namespace CustomStack
{
    using System.Collections.Generic;

    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange(IEnumerable<string> values)
        {
            foreach (var item in values)
            {
                this.Push(item);
            }

            return this;
        }
    }
}
