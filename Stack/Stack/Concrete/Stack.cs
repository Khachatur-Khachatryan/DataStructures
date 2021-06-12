using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack.Logic
{
    /// <summary>
    /// Realization of interface IStack
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stack<T> : IStack<T>
    {
        /// <summary>
        /// Enum for declaration type of stack
        /// </summary>
        private StackType StackType;

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
        public T Peek => Array[Count - 1];

        /// <summary>
        /// Constructor for declarate a static stack
        /// </summary>
        /// <param name="capacity"></param>
        public Stack(int capacity)
        {
            Capacity = capacity;
            StackType = StackType.STATIC;
        }

        /// <summary>
        /// Constructor for declarate a dynamic stack
        /// </summary>
        public Stack()
        {
            StackType = StackType.DYNAMIC;
        }

        /// <summary>
        /// Add item in the stack
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (StackType == StackType.DYNAMIC)
            {
                if (IsEmpty)
                {
                    Array = new T[] { item };
                }
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
                if (IsEmpty)
                {
                    Array = new T[] { item };
                }
                else
                {
                    if (!IsFull)
                    {
                        var array = new T[Count + 1];
                        for (int i = 0; i < Count; i++)
                        {
                            array[i] = Array[i];
                        }
                        array[array.Length - 1] = item;
                        Array = array;
                    }
                    else
                    {
                        throw new InvalidOperationException("Стек переполнен");
                    }
                }
            }
        }

        /// <summary>
        /// Delete item of the stack
        /// </summary>
        public void Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            else
            {
                var array = new T[Count - 1];
                for (int i = 0; i < array.Length; i++)
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
        public IEnumerator GetEnumerator()
        {
            return Array.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (T item in Array)
            {
                yield return item;
            }
        }
    }
}