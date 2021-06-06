using System.Collections.Generic;

namespace Queue.Logic
{
    public interface IQueue<T> : IEnumerable<T>
    {
        int Capacity { get; }
        int Count { get; }
        bool IsFull { get; }
        bool IsEmpty { get; }
        T Peek { get; }
        public void Enqueue(T item);
        public void Dequeue();
    }
}
