using System.Collections.Generic;
using System.Collections;

namespace LinkedList.Logic
{
    public interface ILinkedList<T>
    {
        // Properties
        public INode<T> Head { get; }
        public INode<T> Tail { get; }
        public int Count { get; }
        public bool IsEmpty { get; }

        // Add methods
        void AddAfter(INode<T> elem, T data);
        INode<T> AddHead(T data);
        INode<T> AddTail(T data);

        // Remove methods
        void RemoveAfter(INode<T> elem);
        void RemoveHead();
        void RemoveTail();

        // Additional methods
        INode<T> Find(T data);
        bool Contains(T data);
        void Clear();
        void Reverse();
    }
}