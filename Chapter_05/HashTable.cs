namespace GrokkingAlgorithms.Chapter_5;
public class HashTable<T> 
{
    private Item<T>[] items;
    private double counter = 0;

    public HashTable(int size) 
    {
        items = new Item<T>[size];

        for (int i = 0; i < size; i++) 
        {
            items[i] = new Item<T>(i);
        }
    }

    public void Add(T item) 
    {
        if (items == null)
            throw new ArgumentNullException("The array haven't been created");

        if (counter / items.Length > 0.7) 
        {
            Item<T>[] tempArr = new Item<T>[items.Length * 2];
            for (int i = 0; i < tempArr.Length; i++)
            {
                tempArr[i] = new Item<T>(i);
            }
            int hash = 0;
            var temp = items;
            items = tempArr;
            for (int i = 0; i < temp.Length; i++)
            {
                foreach (T node in temp[i].Nodes)
                {
                    hash = GetHash(node);
                    items[hash].Nodes.Add(node);
                }
            }
        }
        int k = GetHash(item);
        items[k].Nodes.Add(item);
        counter++;
    }

    public bool Search(T item) 
    {
        int key = GetHash(item);
        return items[key].Nodes.Contains(item);
    }

    private int GetHash(T item)
    {
        int hash = item.GetHashCode();
        if (hash < 0)
            hash *= -1;
        return hash % items.Length;
    }
}