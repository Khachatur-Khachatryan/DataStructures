using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList.Logic
{
    public class LinkedList<T> : ILinkedList<T>
    {
        private int count;
        private INode<T> head = new Node<T>() { Previous = null };
        private INode<T> tail = new Node<T>() { Next = null };


        public INode<T> Head => head;

        public INode<T> Tail => tail;

        public int Count => count;

        public bool IsEmpty => Count == 0;

        public void AddAfter(INode<T> node, T data)
        {
            if (IsEmpty) throw new EmptyListException();

            var newNode = new Node<T>(data, this);

            if (node == Tail) 
                AddTail(data);
            else if (node == Head) 
                AddHead(data);
            else
            {
                ValidateNode(node);
                newNode.Previous = node;
                newNode.Next = node.Next;
                node.Next = newNode;
            }

            count++;
        }

        public INode<T> AddHead(T data)
        {
            if (IsEmpty) head.Data = data;

            var _head = new Node<T>(data, this)  { Next = head };
            head = _head;

            count++;
            return Head;
        }

        public INode<T> AddTail(T data)
        {
            if (IsEmpty) tail.Data = data;

            var _tail = new Node<T>(data, this) { Previous = tail };
            tail = _tail;

            count++;
            return Tail;
        }

        public void RemoveAfter(INode<T> node)
        {
            if (IsEmpty) throw new EmptyListException();

            if (node == Tail)
                RemoveTail();
            else if (node == Head)
                RemoveHead();
            else
            {
                ValidateNode(node);

                if (node.Next != null)
                {
                    node.Next = node.Next.Next;
                    node.Next.Previous = node;
                }
            }

            count--;
        }

        public void RemoveHead()
        {
            if (IsEmpty) throw new EmptyListException();
            
            head.Previous = null;
            head = head.Next;

            count--;
        }

        public void RemoveTail()
        {
            if (IsEmpty) throw new EmptyListException();
            
            tail = tail.Previous;
            tail.Next = null;

            count--;
        }

        public void Reverse()
        {
            var node = new Node<T>(this);
            while (node.Next != null)
            {
                var tmp = node.Previous;
                node.Previous = node.Next;
                node.Next = tmp;
            }
        }

        public void Clear()
        {
            if (IsEmpty) throw new EmptyListException();

            while(head != null) RemoveHead();
            tail = null;
            count = 0;
        }

        public INode<T> Find(T data) 
        {
            if (IsEmpty) throw new EmptyListException();

            var current = Head;

            while (current != null) 
            {
                if (current.Data.Equals(data)) break;
                current = current.Next;
            }
            
            return current;
        }

        public bool Contains(T data)
        {
            if (IsEmpty) throw new EmptyListException();

            var current = Head;

            while (current != null)
            {
                if (current.Data.Equals(data)) return true;
                current = current.Next;
            }

            return false;
        }

        private void ValidateNode(INode<T> node)
        {
            if (node.Next == null && node.Previous == null) throw new EmptyNodeException();

            if (node.Next == null) throw new NullNextException();

            if (node.Previous == null) throw new NullPreviousException();

            if (node.List != this) throw new NotBelongToThisListException();
        }
    }
}