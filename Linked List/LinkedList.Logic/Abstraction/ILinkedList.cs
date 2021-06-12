﻿namespace LinkedList.Logic
{
    public interface ILinkedList<T>
    {
        public Element<T> Head { get; set; }
        public Element<T> Tail { get; set; }
        public int Count { get; }
        public bool IsEmpty { get; }
        void AddHead(T data);
        void AddTail(T data);
        void Clear();
        void RemoveHead();
        void RemoveTail();
    }
}