using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem03.Queue
{
    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public FastQueue()
        {
            this._head = null;
            this._tail = null;
            this.Count = 0;
        }

        public FastQueue(Node<T> head)
        {
            this._head = this._tail = head;
            this.Count = 1; 
        }

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            var node = new Node<T>(item);

            if (this.Count == 0)
            {
                this._head = this._tail = node;
            }
            else
            {
                this._tail.next = node;
                this._tail = node;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            this.EnsureNotEmpty();

            var valueToReturn = this._head.value;

            this._head = this._head.next;
            this.Count--;

            return valueToReturn;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();
            return this._head.value;
        }

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
        
        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;

            while (current.next != null)
            {
                yield return current.value;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }
    }
}
