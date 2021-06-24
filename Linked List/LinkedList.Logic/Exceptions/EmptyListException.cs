using System;

namespace LinkedList.Logic
{
    public class EmptyListException : Exception
    {
        public override string Message => "Linked list is empty";

        public EmptyListException(): base() { }
    }
}
