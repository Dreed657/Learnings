namespace Problem02.Stack
{
    public class Node<T>
    {
        public T value;

        public Node<T> next;

        public Node(T item, Node<T> next = null)
        {
            this.value = item;
            this.next = next;
        }
    }
}