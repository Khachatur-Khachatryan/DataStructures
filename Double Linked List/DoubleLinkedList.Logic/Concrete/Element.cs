namespace LinkedList.Logic
{
    public class Element<T> : IElement<T>
    {
        public T Data { get; set; }
        public IElement<T> Previous { get; set; }
        public IElement<T> Next { get; set; }

        public Element(T data)
        {
            Data = data;
        }

        public Element() { }
    }
}
