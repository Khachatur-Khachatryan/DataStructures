using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.Logic
{
    public class NotBelongToThisListException : Exception
    {
        public override string Message => "This node does not belong to this linked list";

        public NotBelongToThisListException() : base() { }
    }
}
