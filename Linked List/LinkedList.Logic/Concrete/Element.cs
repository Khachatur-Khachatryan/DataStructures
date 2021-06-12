namespace LinkedList.Logic
{
    /// <summary>
    /// Realization of interface IElement<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Element<T> : IElement<T>
    {
        /// <summary>
        /// Data of element
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Previous element
        /// </summary>
        public IElement<T> Previous { get; set; }

        /// <summary>
        /// Next element
        /// </summary>
        public IElement<T> Next { get; set; }

        public Element(T data)
        {
            Data = data;
        }

        public Element() { }
    }
}