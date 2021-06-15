namespace LinkedList.Logic
{
    public interface INode<T>
    {
        public T Data { get; set; }
        public INode<T> Previous { get; set; }
        public INode<T> Next { get; set; }
    }
}