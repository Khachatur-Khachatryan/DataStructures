using System.Collections.Generic;

namespace Stack.Logic
{
    public interface IStack<T> : IEnumerable<T>
    {
        T[] Array { get; }
        int Capacity { get; }
        int Count { get; }
        bool IsFull { get; }
        bool IsEmpty { get; }
        T Peek { get; }
        public void Push(T item);
        public void Pop();
    }
}