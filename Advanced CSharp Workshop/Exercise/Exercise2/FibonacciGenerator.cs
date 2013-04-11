using System.Collections;
using System.Collections.Generic;

namespace Exercise2
{
    public class FibonacciGenerator 
    {
        public static IEnumerable<int> Generate()
        {
            // Implement a fibonacci iterator that generates an infinite fibonacci sequence
            // 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, ..

            return new FibonacciIterator();
        }

        public static IEnumerable<int> GenerateUsingYield()
        {
            yield return 0;
            yield return 1;

            int previous = 0;
            int current = 1;

            while (true)
            {
                yield return previous + current;

                int tmpPrevious = current;
                current = previous + current;
                previous = tmpPrevious;
            }
        }
    }

    public class FibonacciIterator : IEnumerable<int>, IEnumerator<int>
    {
        private int previous;
        private int current = -1;

        public IEnumerator<int> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
        }
        
        public bool MoveNext()
        {
            if (current < 1)
            {
                previous = current;
                current++;
            }
            else
            {
                int tmpPrevious = current;
                current = previous + current;
                previous = tmpPrevious;
            }

            return true;
        }

        public void Reset()
        {
        }

        public int Current
        {
            get { return current; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}