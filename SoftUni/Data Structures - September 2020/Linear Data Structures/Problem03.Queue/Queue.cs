using System.Threading;

namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = this._head;

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

        public T Dequeue()
        {
            this.EnsureNotEmpty();

            var valueToReturn = this._head.value;
            
            this._head = this._head.next;
            this.Count--;
            
            return valueToReturn;
        }

        public void Enqueue(T item)
        {
            var node = new Node<T>(item);

            if (this._head == null)
            {
                this._head = node;
            }
            else
            {
                var current = this._head;
                while (current.next != null)
                    current = current.next;
                
                current.next = node;
            }

            this.Count++;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();
            return this._head.value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;

            while (current.next != null)
            {
                yield return current.value;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }
    }
}