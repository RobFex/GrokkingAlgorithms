using System.Collections;

namespace GrokkingAlgorithms.Chapter_2
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        public ListItem<T> Head { get; private set; }
        public ListItem<T> Tail { get; private set; }
        public int Count { get; private set; }

        public MyLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public MyLinkedList(T data)
        {
            ListItem<T> item = new ListItem<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }

        public void Add(T data)
        {
            ListItem<T> item = new ListItem<T>(data);
            if (Count == 0)
            {
                Head = item;
                Tail = item;
                Count = 1;
                return;
            }

            Tail.Next = item;
            item.Previous = Tail;
            Tail = item;
            Count++;
        }
        public void Delete(T data)
        {
            ListItem<T> current = Head;
            
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                    Count--;
                    return;
                }
                else
                {
                    current = current.Next;
                }
            }
        }
        public MyLinkedList<T> Reverse()
        {
            MyLinkedList<T> listResult = new MyLinkedList<T>();
            ListItem<T> current = Tail;
            while (current != null)
            {
                listResult.Add(current.Data);
                current = current.Previous;
            }
            return listResult;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListItem<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
