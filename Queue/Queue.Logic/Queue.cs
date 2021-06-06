using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Queue.Logic
{
    /// <summary>
    /// Realization of interface IQueue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T> : IQueue<T>
    {
        /// <summary>
        /// Enum for declaration type of queue
        /// </summary>
        private QueueType QueueType;

        /// <summary>
        /// Generic array for add/delete elements
        /// </summary>
        private T[] Array = new T[0];

        /// <summary>
        /// Maximal capacity of stack
        /// </summary>
        public int Capacity { get; }

        /// <summary>
        /// Count of elements in Array
        /// </summary>
        public int Count => Array.Length;

        /// <summary>
        /// Check is full the stack
        /// </summary>
        public bool IsFull => Count >= Capacity;

        /// <summary>
        /// Check is empty the stack
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// Get the last element of stack
        /// </summary>
        public T Peek => Array[0];

        /// <summary>
        /// Constructor for declarate a static stack
        /// </summary>
        /// <param name="capacity"></param>
        public Queue(int capacity)
        {
            Capacity = capacity;
            QueueType = QueueType.STATIC;
        }

        /// <summary>
        /// Constructor for declarate a static stack
        /// </summary>
        public Queue()
        {
            QueueType = QueueType.DYNAMIC;
        }

        /// <summary>
        /// Add item in the queue
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            if (QueueType == QueueType.DYNAMIC)
            {
                if (IsEmpty) Array = new T[] { item };
                else
                {
                    var array = new T[Count + 1];
                    for (int i = 0; i < Count; i++)
                    {
                        array[i] = Array[i];
                    }
                    array[array.Length - 1] = item;
                    Array = array;
                }
            }
            else
            {
                if (IsEmpty) Array = new T[] { item };
                else
                {
                    if (!IsFull)
                    {
                        var array = new T[Count + 1];
                        for (int i = 0; i < Count; i++)
                        {
                            array[i] = Array[i];
                        }
                        array[Count] = item;
                        Array = array;
                    }
                    else throw new InvalidOperationException("Queue is full");
                }
            }
        }

        /// <summary>
        /// Delete item of the stack
        /// </summary>
        public void Dequeue()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue is empty");
            else
            {
                var array = new T[Count - 1];

                for (int i = 1; i < array.Length; i++)
                {
                    array[i] = Array[i];
                }

                Array = array;
            }
        }

        /// <summary>
        /// Support foreach cycle
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach(T item in Array)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Array.GetEnumerator();
        }
    }
}
