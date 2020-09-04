using System.Threading;

namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = this._top;

            while (current != null)
            {
                if (current.value.Equals(item))
                {
                    return true;
                }
                current = current.next;
            }

            return false;
        }

        public T Peek()
        {
            this.EnsureItsNotEmpty();
            return this._top.value;
        }

        public T Pop()
        {
            this.EnsureItsNotEmpty();

            var valueToReturn = this._top.value;

            this._top = this._top.next;
            this.Count--;

            return valueToReturn;
        }

        public void Push(T item)
        {
            var node = new Node<T>(item, this._top);

            this._top = node;
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._top;

            while (current != null)
            {
                yield return current.value;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void EnsureItsNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
        }
    }
}