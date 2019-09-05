using System;
using System.Linq;
using System.Collections;

namespace MyStack.Types
{
    public class ArrayStack<T> : IEnumerable
    {
        private readonly int maxSize;

        private T[] items;
        private int index;

        private bool isEmpty => Count < 1;
        private bool isOverflow => Count > maxSize;

        public int Count => index;

        public ArrayStack(int size)
        {
            items = new T[size];
            maxSize = size;
        }

        public void Push(T value)
        {
            if (isOverflow)
            {
                throw new StackOverflowException("Стек переполнен.");
            }

            items[index] = value;

            index++;
        }
        public T Peek()
        {
            if (isEmpty)
            {
                throw new InvalidOperationException("Стек пуст.");
            }

            return items[index - 1];
        }
        public T Pop()
        {
            if (isEmpty)
            {
                throw new InvalidOperationException("Стек пуст.");
            }

            var item = items[index - 1];

            items[index - 1] = default;

            index--;

            return item;
        }
        public void Clear()
        {
            items = new T[maxSize];
            index = 0;
        }
        public bool Contains(T value)
        {
            return items.Contains(value);
        }
        public IEnumerator GetEnumerator()
        {
            return items.Select(i => i).Reverse().Where(i => !(i.Equals(default(T)))).GetEnumerator();
        }
    }
}