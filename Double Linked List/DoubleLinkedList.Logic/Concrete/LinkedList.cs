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
        public Element<T> Head { get; set; } = new Element<T>();
        
        /// <summary>
        /// Last element 
        /// </summary>
        public Element<T> Tail { get; set; } = new Element<T>();

        /// <summary>
        /// Count-prop
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Check is empty the stack
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// Add the elemnt before Head
        /// </summary>
        /// <param name="data"></param>
        public void AddHead(T data)
        {
            var head = new Element<T>(data);
            head.Next = Head;
            head.Previous = null;
            Head = head;
            
            count++;
        }

        /// <summary>
        /// Add the element after the Tail
        /// </summary>
        /// <param name="data"></param>
        public void AddTail(T data)
        {
            var tail = new Element<T>(data);
            tail.Previous = Tail;
            tail.Next = null;
            Tail = tail;

            count++;
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
        /// Remove first element of list
        /// </summary>
        public void RemoveHead()
        {
            Head.Next = Head.Next.Next;
            Head = (Element<T>) Head.Next;
            Head.Previous = null;

            count--;
        }

        /// <summary>
        /// Remove last element of  list
        /// </summary>
        public void RemoveTail()
        {
            Tail.Previous = Tail.Previous.Previous;
            Tail = (Element<T>) Tail.Previous;
            Tail.Next = null;

            count--;
        }
    }
}
