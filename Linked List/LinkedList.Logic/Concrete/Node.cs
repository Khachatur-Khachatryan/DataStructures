namespace LinkedList.Logic
{
    /// <summary>
    /// Realization of interface IElement<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T> : INode<T>
    {
        /// <summary>
        /// Data of element
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Previous element
        /// </summary>
        public INode<T> Previous { get; set; }

        /// <summary>
        /// Next element
        /// </summary>
        public INode<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        public Node() { }
    }
}