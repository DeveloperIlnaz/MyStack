using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace MyStack.Types
{
    public class ListStack<T> : IEnumerable
    {
        private List<T> items;
        private bool isEmpty => items.Count < 1;

        public int Count => items.Count;

        public ListStack()
        {
            items = new List<T>();
        }
        public ListStack(IEnumerable<T> collection)
        {
            items = collection.ToList();
        }

        public void Push(T item)
        {
            items.Add(item);
        }
        public T Peek()
        {
            if (isEmpty)
            {
                throw new InvalidOperationException("Стек пуст.");
            }

            return items.Last();
        }
        public T Pop()
        {
            if (isEmpty)
            {
                throw new InvalidOperationException("Стек пуст.");
            }

            var item = items.Last();

            items.Remove(item);

            return item;
        }
        public void Clear()
        {
            items.Clear();
        }
        public bool Contains(T item)
        {
            return items.Contains(item);
        }
        public IEnumerator GetEnumerator()
        {
            return items.Select(i => i).Reverse().GetEnumerator();
        }
    }
}