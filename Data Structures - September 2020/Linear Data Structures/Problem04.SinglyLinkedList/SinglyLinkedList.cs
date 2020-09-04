using System.Runtime.CompilerServices;

namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;

        public int Count { get; private set; }

        // O(1)
        public void AddFirst(T item)
        {
            var node = new Node<T>(item, this._head);

            this._head = node;
            this.Count++;
        }

        public void AddLast(T item)
        {
            var node = new Node<T>(item);

            var current = this._head;

            if (current == null)
            {
                this._head = node;
            }
            else
            {
                while (current != null)
                {
                    if (current.next == null)
                    {
                        current.next = node;
                        break;
                    }

                    current = current.next;
                }
            }

            this.Count++;
        }

        // O(1)
        public T GetFirst()
        {
            this.EnsureNonEmpty();

            return this._head.value;
        }

        public T GetLast()
        {
            this.EnsureNonEmpty();

            var current = this._head;

            while (current.next != null)
                current = current.next;

            return current.value;
        }
        
        // O(1)
        public T RemoveFirst()
        {
            this.EnsureNonEmpty();

            var valueToReturn = this._head.value;
            this._head = this._head.next;
            this.Count--;

            return valueToReturn;
        }

        public T RemoveLast()
        {
            this.EnsureNonEmpty();

            var current = this._head;

            if (current.next == null)
            {
                this.Count--;
                var valueToReturn = this._head.value;
                this._head = null;
                
                return valueToReturn;
            }
            else
            {
                while (current.next.next != null)
                    current = current.next;

                var valueToReturn = current.next.value;
                this.Count--;
                current.next = null;

                return valueToReturn;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;

            while (current != null)
            {
                yield return current.value;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void EnsureNonEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }
        }
    }
}