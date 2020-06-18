namespace TrashyList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ListyIterator<T> : IEnumerable
    {
        private int InternalIndex = 0;

        public List<T> Data { get; set; }

        public ListyIterator()
        {
            this.Data = new List<T>();
        }

        public ListyIterator(T[] data)
        {
            this.Data = new List<T>(data);
        }

        public bool Move()
        {
            if (InternalIndex + 1 < this.Data.Count)
            {
                this.InternalIndex++;
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (this.Data.Any())
            {
                Console.WriteLine(this.Data[InternalIndex]);
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }

        public void PrintAll()
        {
            if (this.Data.Any())
            {
                Console.WriteLine(string.Join(' ', this.Data));
            }
        }

        public bool HasNext()
        {
            if (InternalIndex + 1 < this.Data.Count)
            {
                return true;
            }
            return false;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var element in this.Data)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
