namespace Problem02.DoublyLinkedList
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }

        public Node(T item, Node<T> next = null)
        {
            this.Value = item;
            this.Next = next;
        }
    }
}