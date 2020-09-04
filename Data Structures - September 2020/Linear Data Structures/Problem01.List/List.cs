namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;
            
        public List(int capacity = DEFAULT_CAPACITY)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.IsIndexValid(index);
                return this._items[index];
            }
            set
            {
                this.IsIndexValid(index);
                this._items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.EnsureEnoughSpace();
            this._items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this._items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.IsIndexValid(index);
            this.EnsureEnoughSpace();

            for (var i = this.Count; i > index; i--)
            {
                this._items[i] = this._items[i - 1];
            }

            this._items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            var indexOfItem = this.IndexOf(item);

            if (indexOfItem == -1)
            {
                return false;
            }
            
            this.RemoveAt(indexOfItem);
            return true;
        }

        public void RemoveAt(int index)
        {
            this.IsIndexValid(index);

            for (var i = index; i < this.Count - 1; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this._items[this.Count - 1] = default;
            this._items = this.Shrink();

            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < this.Count; i++)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void IsIndexValid(int index)
        {
            if (index < 0 || index >= this._items.Length)
            {
                throw new IndexOutOfRangeException("Index is not in bounds of the array!");
            }
        }

        private void EnsureEnoughSpace()
        {
            if (this.Count == this._items.Length)
            {
                this._items = this.Grow();
            }
        }

        private T[] Grow()
        {
            var newArr = new T[this._items.Length + 1];
            Array.Copy(this._items, newArr, this._items.Length);

            return newArr;
        }

        private T[] Shrink()
        {
            var newArr = new T[this._items.Length - 1];
            Array.Copy(this._items, newArr, newArr.Length);

            return newArr;
        }
    }
}