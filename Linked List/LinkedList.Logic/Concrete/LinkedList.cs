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
        public INode<T> Head { get; set; } = new Node<T>();

        /// <summary>
        /// Last element 
        /// </summary>
        public INode<T> Tail { get; set; } = new Node<T>();

        /// <summary>
        /// Count-prop
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Check is empty the linked list
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// Add new element after an existing item
        /// </summary>
        /// <param name="elem"></param>
        public void AddAfter(INode<T> node, T data)
        {
            var current = new Node<T>(data);

            if (node.Next == null && node.Previous == null) throw new EmptyNodeException();

            if (node == Tail) AddTail(data);
            else if (node == Head) AddHead(data);
            else if (Contains(node) == false) throw new NotBelongToThisListException();
            else
            {
                current.Previous = node;
                current.Next = node.Next;
                node.Next = current;
            }

            count++;
        }

        /// <summary>
        /// Add the elemnt before Head
        /// </summary>
        /// <param name="data"></param>
        public INode<T> AddHead(T data)
        {
            var head = new Node<T>(data);
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
        public INode<T> AddTail(T data)
        {
            var tail = new Node<T>(data);
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
        public void RemoveAfter(INode<T> node)
        {
            if (node.Next == null && node.Previous == null) throw new EmptyNodeException();


            if (node == Tail) RemoveTail();
            else if (node == Head) RemoveHead();
            else if (Contains(node) == false) throw new NotBelongToThisListException();
            else
            {
                node.Next = null;
                node.Next = node.Next.Next;
                node.Next.Previous = node;
            }

            count++;
        }

        /// <summary>
        /// Remove first element of list
        /// </summary>
        public void RemoveHead()
        { 
            Head = (Node<T>)Head.Next;
            Head.Previous = null;

            count--;
        }

        /// <summary>
        /// Remove last element of  list
        /// </summary>
        public void RemoveTail()
        {
            Tail = (Node<T>) Tail.Previous;
            Tail.Next = null;

            count--;
        }

        /// <summary>
        /// Reverse the list
        /// </summary>
        public void Reverse()
        {
            var element = new Node<T>();
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
        public INode<T> Find(T data) 
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
        /// Chek contains the list this element with <param name="data"></param>
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

        /// <summary>
        /// Chek contains the list this element
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public bool Contains(INode<T> elem)
        {
            var current = Head;

            for (int i = 0; i < Count; i++)
            {
                if (current == elem) return true;
                else if (current == null) break;
                //else if (current == Tail) break;
                current = current.Next;
            }

            return false;
        }
    }
}