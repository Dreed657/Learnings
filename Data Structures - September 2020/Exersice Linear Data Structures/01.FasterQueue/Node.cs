namespace Problem01.FasterQueue
{
    public class Node<T>
    {
        public T Item { get; set; }

        public Node<T> Next { get; set; }

        public Node(T value, Node<T> next = null)
        {
            this.Item = value;
            this.Next = next;
        }
    }
}