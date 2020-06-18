namespace GenericBoxofString
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
        where T : IComparable
    {
        private List<T> _data;

        public Box(List<T> input)
        {
            this.Data = input;
        }

        public List<T> Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            this.Data.ForEach(x => sb.AppendLine($"{x.GetType()}: {x}"));
            
            return sb.ToString();
        }

        public void Swap(int index1, int index2)
        {
            var temp = this.Data[index1];
            this.Data[index1] = this.Data[index2];
            this.Data[index2] = temp;
        }

        public int Compare(T element)
        {
            int count = 0;

            foreach (var item in Data)
            {
                if (item.CompareTo(element) > 0) count++;
            }

            return count;
        }
    }
}
