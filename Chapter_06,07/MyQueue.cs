using System.Collections;

namespace GrokkingAlgorithms.Chapter_6;

public class MyQueue<T> : IEnumerable<T>
{
    private T[] _items;
    private T Head => _items[Count > 0 ? Count - 1 : 0];
    private T Tail => _items[0];

    public int Count { get; private set; } = 0;
    public int Capacity { get => _items.Length; }

    public MyQueue()
    {
        const int defCapacity = 4;
        _items = new T[defCapacity];
    }
    public MyQueue(int capacity)
    {
        _items = new T[capacity];
    }
    
    public void Enqueue(T data) 
    {
        if (Count >= Capacity)
        {
            T[] tempItems = new T[Count * 2];
            Array.Copy(_items, tempItems, Count);
            _items = tempItems;
        }
        T[] tmpArr = new T[Capacity];
        Array.Copy(_items, tmpArr, Capacity);
        for (int i = 1; i <= Count; i++) 
        {
            _items[i] = tmpArr[i - 1];
        }
        _items[0] = data;
        Count++;
    }
    public void Dequeue()
    {
        if (Count == 0)
            throw new InvalidOperationException();

        T item = Head;
        _items[--Count] = default(T);
    }
    public T Peek() 
    {
        if (Count == 0)
            throw new InvalidOperationException();

        return Head;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new QueueEnum<T>(_items, Count);
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public class QueueEnum<T> : IEnumerator<T>
    {
        public readonly T[] array;
        private readonly int count;
        private int position;
        public QueueEnum(T[] array, int count)
        {
            this.array = array;
            this.count = count;
            position = count;
        }

        public T Current => array[position];
        object IEnumerator.Current => Current;

        public void Dispose() { }
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

