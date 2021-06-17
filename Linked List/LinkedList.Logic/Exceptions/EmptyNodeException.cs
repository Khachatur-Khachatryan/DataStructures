using System;

namespace LinkedList.Logic
{
    public class EmptyNodeException : Exception
    {
        public override string Message => "Node is empty or null";

        public EmptyNodeException() : base() { }
    }
}
