using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList.Logic
{
    /// <summary>
    /// Realization of interface ILinkedList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> : ILinkedList<T>
    {
        /// <summary>
        /// Count of elements
        /// </summary>
        private int count;

        /// <summary>
        /// First element 
        /// </summary>
        public IElement<T> Head { get; set; } = new Element<T>();

        /// <summary>
        /// Last element 
        /// </summary>
        public IElement<T> Tail { get; set; } = new Element<T>();

        /// <summary>
        /// Count-prop
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Check is empty the stack
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// Add new element after an existing item
        /// </summary>
        /// <param name="elem"></param>
        public void AddAfter(IElement<T> elem, T data)
        {
            var current = new Element<T>(data);

            if (elem == Tail) AddTail(data);
            else if (elem == Head) AddHead(data);
            else
            {
                current.Previous = elem;
                current.Next = elem.Next;
                elem.Next = current;
            }

            count++;
        }

        /// <summary>
        /// Add the elemnt before Head
        /// </summary>
        /// <param name="data"></param>
        public IElement<T> AddHead(T data)
        {
            var head = new Element<T>(data);
            head.Next = Head;
            head.Previous = null;
            Head = head;

            count++;
            return Head;
        }

        /// <summary>
        /// Add the element after the Tail
        /// </summary>
        /// <param name="data"></param>
        public IElement<T> AddTail(T data)
        {
            var tail = new Element<T>(data);
            tail.Previous = Tail;
            tail.Next = null;
            Tail.Next = tail;
            Tail = tail;

            count++;
            return Tail;
        }

        /// <summary>
        /// Remove element after existing item
        /// </summary>
        /// <param name="elem"></param>
        public void RemoveAfter(IElement<T> elem)
        {
            if (elem == Tail) RemoveTail();
            else if (elem == Head) RemoveHead();
            else
            {
                elem.Next = null;
                elem.Next = elem.Next.Next;
                elem.Next.Previous = elem;
            }

            count++;
        }

        /// <summary>
        /// Remove first element of list
        /// </summary>
        public void RemoveHead()
        { 
            Head = (Element<T>)Head.Next;
            Head.Previous = null;

            count--;
        }

        /// <summary>
        /// Remove last element of  list
        /// </summary>
        public void RemoveTail()
        {
            Tail = (Element<T>) Tail.Previous;
            Tail.Next = null;

            count--;
        }

        /// <summary>
        /// Reverse the list
        /// </summary>
        public void Reverse()
        {
            var element = new Element<T>();
            while (element.Next != null)
            {
                var tmp = element.Previous;
                element.Previous = element.Next;
                element.Next = tmp;
            }
        }

        /// <summary>
        /// Clear all linked list
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        /// <summary>
        /// Find element by data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IElement<T> Find(T data) 
        {
            var current = Head;

            for (int i = 0; i < Count; i++) 
            {

                if (current.Data.Equals(data)) break;
                else if (current == null) break;
                current = current.Next;
            }
            
            return current;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Contains(T data)
        {
            var current = Head;

            for (int i = 1; i < Count; i++)
            {
                if (current.Data.Equals(data)) return true;
                else if (current == null) return false;
                current = current.Next;
            }

            return false;
        }

    }
}