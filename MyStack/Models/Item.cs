namespace MyStack.Models
{
    public class Item<T>
    {
        public T Value { get; set; }
        public Item<T> Previous { get; set; }

        public Item(T value)
        {
            Value = value;
        }
    }
}