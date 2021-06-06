using System.Collections.Generic;

namespace Stack.Logic
{
    public interface IStack<T> : IEnumerable<T>
    {
        int Capacity { get; }
        int Count { get; }
        bool IsFull { get; }
        bool IsEmpty { get; }
        T Peek { get; }
        void Push(T item);
        void Pop();
    }
}