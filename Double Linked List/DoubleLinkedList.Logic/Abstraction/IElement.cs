namespace LinkedList.Logic
{
    public interface IElement<T>
    {
        public T Data { get; set; }
        public IElement<T> Previous { get; set; }
        public IElement<T> Next { get; set; }
    }
}
