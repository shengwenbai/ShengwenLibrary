using System;
using System.Collections;
using System.Collections.Generic;


namespace ShengwenLibrary
{
    public class LinkedListStack<T>: IEnumerable<T>
    // Inspired by Princeton Algorithms course(http://algs4.cs.princeton.edu) 
    {
        /*
         * _count: # elements in stack
         * _first: the first pushed item (at the bottom of the stack)
         */
        private int _count;
        private Node _first;
        private class Node
        {
            internal T Item;
            internal Node Next;
        }

        public int Count()
        {
            return _count;
        }

        public bool IsEmpty()
        {
            return _first == null;
        }

        public void Push(T item)
        {
            var oldFirst = _first;
            _first = new Node
            {
                Item = item,
                Next = oldFirst
            };
            _count++;
        }

        public T Pop()
        {
            if(IsEmpty())
                throw new InvalidOperationException("Stack is empty");
            var item = _first.Item;
            _first = _first.Next;
            _count--;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");
            return _first.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListIterator(_first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class ListIterator : IEnumerator<T>
        {
            private Node _currentInIterator;
            private readonly Node _pointToFirst;

            public ListIterator(Node first)
            {
                _pointToFirst = new Node { Next = first };
                _currentInIterator = _pointToFirst;
            }


            public void Dispose()
            {
                //left blank                   
            }

            public bool MoveNext()
            {
                if (_currentInIterator.Next == null) return false;
                _currentInIterator = _currentInIterator.Next;
                return true;
            }

            public void Reset()
            {
                _currentInIterator = _pointToFirst;
            }

            public T Current => (_currentInIterator != null) ? _currentInIterator.Item : default(T);


            object IEnumerator.Current => this.Current;
        }

    }



}
