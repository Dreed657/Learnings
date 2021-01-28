using System.Data.SqlTypes;

namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var node = new Node<T>(item);

            if (this.Count == 0)
            {
                this.head = this.tail = node;
            }
            else
            {
                this.head.Previous = node;
                node.Next = this.head;
                this.head = node;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            var node = new Node<T>(item);

            if (this.Count == 0)
            {
                this.head = this.tail = node;
            }
            else
            {
                node.Previous = this.tail;
                this.tail.Next = node;
                this.tail = node;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            this.EnsureNotEmpty();
            return this.head.Value;
        }

        public T GetLast()
        {
            this.EnsureNotEmpty();
            return this.tail.Value;
        }

        public T RemoveFirst()
        {
            this.EnsureNotEmpty();
            
            var current = this.head;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                var newHead = this.head.Next;
                newHead.Previous = null;
                this.head = newHead;
            }

            this.Count--;
            return current.Value;
        }

        public T RemoveLast()
        {
            this.EnsureNotEmpty();

            var current = this.tail;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                var newTail = this.tail.Previous;
                newTail.Next = null;
                this.tail = newTail;
            }

            this.Count--;
            return current.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;

            while (current.Next != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }
    }
}