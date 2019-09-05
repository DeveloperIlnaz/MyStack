using System;
using MyStack.Types;

namespace MyStack
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ArrayStack<int> arrayStack = new ArrayStack<int>(4);

            arrayStack.Push(5);
            arrayStack.Push(10);
            arrayStack.Push(15);

            Console.WriteLine(arrayStack.Peek());
        }
    }
}