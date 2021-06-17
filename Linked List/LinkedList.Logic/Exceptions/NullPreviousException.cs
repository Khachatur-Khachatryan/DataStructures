using System;

namespace LinkedList.Logic
{
    public class NullPreviousException : Exception 
    {
        public override string Message => "Node.Previous is null";

        public NullPreviousException() : base() { }
    }
}
