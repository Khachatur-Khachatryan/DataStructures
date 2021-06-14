using System.Collections.Generic;
using System.Collections;

namespace LinkedList.Logic
{
    public interface ILinkedList<T>
    {
        // Properties
        public IElement<T> Head { get; }
        public IElement<T> Tail { get; }
        public int Count { get; }
        public bool IsEmpty { get; }

        // Add methods
        void AddAfter(IElement<T> elem, T data);
        IElement<T> AddHead(T data);
        IElement<T> AddTail(T data);

        // Remove methods
        void RemoveAfter(IElement<T> elem);
        void RemoveHead();
        void RemoveTail();

        // Additional methods
        IElement<T> Find(T data);
        bool Contains(T data);
        void Clear();
        void Reverse();
    }
}