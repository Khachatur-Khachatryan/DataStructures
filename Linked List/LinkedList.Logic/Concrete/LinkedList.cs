using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList.Logic
{
    public class LinkedList<T> : ILinkedList<T>
    {
        private int count;

        public INode<T> Head { get; set; } = new Node<T>();

        public INode<T> Tail { get; set; } = new Node<T>();

        public int Count => count;

        public bool IsEmpty => Count == 0;

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

        public INode<T> AddHead(T data)
        {
            var head = new Node<T>(data);
            head.Next = Head;
            head.Previous = null;
            Head = head;

            count++;
            return Head;
        }

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

        public void RemoveHead()
        { 
            Head = (Node<T>)Head.Next;
            Head.Previous = null;

            count--;
        }

        public void RemoveTail()
        {
            Tail = (Node<T>) Tail.Previous;
            Tail.Next = null;

            count--;
        }

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

        public void Clear()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

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

        public bool Contains(INode<T> elem)
        {
            var current = Head;

            for (int i = 0; i < Count; i++)
            {
                if (current == elem) return true;
                else if (current == null) break;
                current = current.Next;
            }

            return false;
        }
    }
}