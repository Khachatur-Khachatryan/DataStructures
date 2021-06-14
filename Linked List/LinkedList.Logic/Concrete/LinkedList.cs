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
        public Element<T> Head { get; set; } = new Element<T>();

        /// <summary>
        /// Last element 
        /// </summary>
        public Element<T> Tail { get; set; } = new Element<T>();

        /// <summary>
        /// Count-prop
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Check is empty the stack
        /// </summary>
        public bool IsEmpty => Count == 0;
        public void AddAfter(int id, T data)
        {
            var current = Find(id);
            var elem = new Element<T>(data);

            elem.Next = current.Next;
            elem.Previous = current;
            current.Next = elem;

            count++;
        }

        /// <summary>
        /// Add the elemnt before Head
        /// </summary>
        /// <param name="data"></param>
        public void AddHead(T data)
        {
            var head = new Element<T>(data);
            head.Next = Head;
            head.Previous = null;
            Head = head;

            count++;
        }

        /// <summary>
        /// Add the element after the Tail
        /// </summary>
        /// <param name="data"></param>
        public void AddTail(T data)
        {
            var tail = new Element<T>(data);
            tail.Previous = Tail;
            tail.Next = null;
            Tail = tail;

            count++;
        }

        public void RemoveAfter(int id, T data) 
        {
            var current = Find(id);

            current.Next = current.Next.Next;
            current.Next.Previous = current;

            count--;
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
            //    Tail.Previous = Tail.Previous.Previous;
            //    Tail = (Element<T>) Tail.Previous;
            //    Tail.Next = null;
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

        public IElement<T> Find(int id) 
        {
            if (id > Count) throw new IndexOutOfRangeException();
            
            var current = Head;

            for (int i = 0; i < id; i++) current = (Element<T>)current.Next;
            
            return current;
        }
    }
}