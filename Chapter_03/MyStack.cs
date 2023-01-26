using System.Collections;
namespace GrokkingAlgorithms.Chapter_3
{
    public class MyStack<T> : IEnumerable<T>
    {
            private T[] _stack;
            public int Elements { get; private set; }
            public int Capacity
            {
                get
                {
                    return _stack.Length;
                }
            }
            public MyStack()
            {
                const int defCapacity = 4;
                _stack = new T[defCapacity];
            }
            public MyStack(int capacity)
            {
                _stack = new T[capacity];
            }
            public void Push(T item)
            {
                if (Elements >= Capacity)
                {
                    T[] tempStack = new T[Elements * 2];
                    Array.Copy(_stack, tempStack, Elements);
                    _stack = tempStack;
                }
                _stack[Elements++] = item;
            }
            public void Pop()
            {
                if (Elements == 0)
                {
                    throw new InvalidOperationException();
                }
                _stack[--Elements] = default(T);
            }
            public object Peek()
            {
                if (Elements == 0)
                {
                    throw new InvalidOperationException();
                }
                return _stack[Elements - 1]; // not decrement
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnum<T>(_stack, Elements);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class StackEnum<T> : IEnumerator<T>
        {
            private readonly T[] array;
            private readonly int count;
            private int position;
            public StackEnum(T[] array, int counter)
            {
                this.array = array;
                position = counter;
                count = counter;
            }
            public T Current => array[position];
            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                position--;
                return position >= 0;
            }

            public void Reset()
            {
                position = count;
            }
        }
    }
}