namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] _items;

        public ReversedList(int capacity = DefaultCapacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this._items[this.Count - index - 1];
            }
            set
            {
                this.ValidateIndex(index);
                this._items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.GrowIfNecessary();
            this._items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (var i = 1; i <= this.Count; i++)
            {
                if (this._items[this.Count - i].Equals(item))
                {
                    return i - 1;
                }
            }
            
            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.GrowIfNecessary();

            var indexToInsert = this.Count - index;

            for (var i = this.Count; i > indexToInsert; i--)
            {
                this._items[i] = this._items[i - 1];
            }

            this._items[indexToInsert] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            var indexOfElement = this.IndexOf(item);

            if (indexOfElement == -1) return false;

            this.RemoveAt(indexOfElement);
            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            var indexOfElement = this.Count - 1 - index;

            for (var i = indexOfElement; i < this.Count - 1; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this.Shrink();
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = this._items.Length - 1; i >= 0; i--)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void GrowIfNecessary()
        {
            if (this.Count == this._items.Length)
            {
                this.Grow();
            }
        }

        private void Grow()
        {
            var newArr = new T[this._items.Length + 1];
            Array.Copy(this._items, newArr, this._items.Length);
            this._items = newArr;
        }

        private void Shrink()
        {
            var newArr = new T[this._items.Length - 1];
            Array.Copy(this._items, newArr, newArr.Length);
            this._items = newArr;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}