namespace LinkedList.Logic
{
    public class Node<T> : INode<T>
    {
        public T Data { get; set; }

        public ILinkedList<T> List { get; set; }

        public INode<T> Previous { get; set; }

        public INode<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        public Node(ILinkedList<T> list)
        {
            List = list;
        }

        public Node(T data, ILinkedList<T> list) 
        {
            List = list;
            Data = data;
        }

        public Node() { }

        public void Invalidate()
        {
            List = null;
            Previous = null;
            Next = null;
            Data = default;
        }
    }
}