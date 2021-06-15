namespace LinkedList.Logic
{
    public class Node<T> : INode<T>
    {
        public T Data { get; set; }

        public INode<T> Previous { get; set; }

        public INode<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        public Node() { }
    }
}