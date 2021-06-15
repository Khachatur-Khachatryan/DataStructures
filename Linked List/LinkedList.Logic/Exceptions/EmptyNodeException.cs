using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.Logic
{
    public class EmptyNodeException : Exception
    {
        public override string Message => "Node is empty";

        public EmptyNodeException() : base () { }
    }
}
