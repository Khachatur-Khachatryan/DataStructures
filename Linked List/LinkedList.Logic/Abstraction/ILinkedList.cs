namespace LinkedList.Logic
{
    public interface ILinkedList<T>
    {
        public INode<T> Head { get; }
        public INode<T> Tail { get; }
        public int Count { get; }
        public bool IsEmpty { get; }

        void AddAfter(INode<T> elem, T data);
        INode<T> AddHead(T data);
        INode<T> AddTail(T data);

        void RemoveAfter(INode<T> elem);
        void RemoveHead();
        void RemoveTail();

        INode<T> Find(T data);
        bool Contains(T data);
        void Clear();
        void Reverse();
    }
}