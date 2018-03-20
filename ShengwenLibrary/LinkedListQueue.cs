using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ShengwenLibrary
{
    public class LinkedListQueue<T>:IEnumerable<T>
    {
        /*
         * _count: # elements in queue
         * _first: first enqueued element (the head of the queue)
         * _last: tail of the queue
         */
        private Node _first;
        private Node _last;
        private int _count;
        private class Node
        {
            internal T Item;
            internal Node Next;
        }

        public bool IsEmpty()
        {
            return _first == null;
        }

        public int Count()
        {
            return _count;
        }

        public void Enqueue(T item)
        {
            var oldLast = _last;
            _last = new Node()
            {
                Item = item,
                Next = null
            };
            if (IsEmpty())
                _first = _last;
            else
                oldLast.Next = _last;
            _count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty");
            var oldFirst = _first;
            _first = _first.Next;
            oldFirst.Next = null;
            _count--;
            if (IsEmpty())
                _last = null;
            return oldFirst.Item;

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
