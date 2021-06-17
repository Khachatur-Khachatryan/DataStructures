using System;

namespace LinkedList.Logic
{
    public class NullNextException : Exception
    {
        public override string Message => "Node.Next is null";

        public NullNextException() :base() { }
    }
}
