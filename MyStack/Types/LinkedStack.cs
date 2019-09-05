using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using MyStack.Models;

namespace MyStack.Types
{
    public class LinkedStack<T> : IEnumerable
    {
        private Item<T> first;
        private int count;
        private bool isEmpty => count < 1;

        public Item<T> First => first;
        public int Count => count;

        public LinkedStack()
        {
            first = null;
            count = 0;
        }
        public LinkedStack(IEnumerable<T> collection)
        {
            foreach (var value in collection)
            {
                Push(value);
            }
        }

        public void Push(T value)
        {
            var item = new Item<T>(value)
            {
                Previous = first
            };

            first = item;

            count++;
        }
        public T Peek()
        {
            if (isEmpty)
            {
                throw new InvalidOperationException("Стек пуст.");
            }

            return first.Value;
        }
        public T Pop()
        {
            if (isEmpty)
            {
                throw new InvalidOperationException("Стек пуст.");
            }

            var item = first;

            first = first.Previous;

            count--;

            return item.Value;
        }
        public void Clear()
        {
            first = null;
            count = 0;
        }
        public bool Contains (T value)
        {
            var item = first;

            while (item != null)
            {
                if (item.Value.Equals(value))
                {
                    return true;
                }

                item = item.Previous;
            }

            return false;
        }
        public IEnumerator GetEnumerator()
        {
            var item = first;

            while (item != null)
            {
                yield return item.Value;

                item = item.Previous;
            }
        }
    }
}