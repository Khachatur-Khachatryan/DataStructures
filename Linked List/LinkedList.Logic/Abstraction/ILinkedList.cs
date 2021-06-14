using System.Collections.Generic;
using System.Collections;

namespace LinkedList.Logic
{
    public interface ILinkedList<T> //: IEnumerable, IEnumerable<T>
    {
        // Properties
        public Element<T> Head { get; set; }
        public Element<T> Tail { get; set; }
        public int Count { get; }
        public bool IsEmpty { get; }

        // Add methods
        void AddAfter(int id, T data);
        void AddHead(T data);
        void AddTail(T data);

        // Remove methods
        void RemoveAfter(int id, T data);
        void RemoveHead();
        void RemoveTail();

        // Additional methods
        void Clear();
        void Reverse();
    }
}