using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList.Logic
{
    public class LinkedList<T> : ILinkedList<T>
    {
        private int count;
        private INode<T> head = new Node<T>();
        private INode<T> tail = new Node<T>();


        public INode<T> Head => head;

        public INode<T> Tail => tail;

        public int Count => count;

        public bool IsEmpty => Count == 0;

        public void AddAfter(INode<T> node, T data)
        {
            if (IsNull(node)) throw new ArgumentNullException();

            var current = new Node<T>(data);

            if (node == Tail) 
                AddTail(data);
            else if (node == Head) 
                AddHead(data);
            else
            {
                ValidateNode(node);
                current.Previous = node;
                current.Next = node.Next;
                node.Next = current;
            }

            count++;
        }

        public INode<T> AddHead(T data)
        {
            var _head = new Node<T>(data);
            _head.Next = head;
            _head.Previous = null;
            head = _head;

            count++;
            return Head;
        }

        public INode<T> AddTail(T data)
        {
            var _tail = new Node<T>(data);
            _tail.Previous = tail;
            _tail.Next = null;
            tail.Next = _tail;
            tail = _tail;

            count++;
            return Tail;
        }

        public void RemoveAfter(INode<T> node)
        {
            if (IsNull(node)) throw new ArgumentNullException();

            if (node == Tail)
                RemoveTail();
            else if (node == Head)
                RemoveHead();
            else
            {
                ValidateNode(node);
                node.Next = null;
                node.Next = node.Next.Next;
                node.Next.Previous = node;
            }

            count++;
        }

        public void RemoveHead()
        { 
            head = (Node<T>) head.Next;
            head.Previous = null;

            count--;
        }

        public void RemoveTail()
        {
            tail = (Node<T>) tail.Previous;
            tail.Next = null;

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
            head = null;
            tail = null;
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
                else if (current == null) break;
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

        private void ValidateNode(INode<T> node)
        {
            if (node.Next == null && node.Previous == null)
                throw new EmptyNodeException();
            else if (node.Next == null)
                throw new NullNextException();
            else if (node.Previous == null)
                throw new NullPreviousException();
            else if (Contains(node) == false)
                throw new NotBelongToThisListException();
        }

        private bool IsNull(INode<T> node)
        {
            if (node == null) return true;
            return false;
        }
    }
}