namespace GrokkingAlgorithms.Chapter_6;

public class Graph<T>
{
    List<Vertex<T>> V = new List<Vertex<T>>(); 
    List<Edge<T>> E = new List<Edge<T>>();

    public int VCount => V.Count;
    public int ECount => E.Count;
    public bool Oriented { get; set; } 

    public void AddVertex(Vertex<T> vertex)  
    {
        vertex.Number = V.Count + 1;
        V.Add(vertex);
    } 
    public void AddEdge(Vertex<T> from, Vertex<T> to, int weight = 1) 
    {
        Edge<T> edge = new Edge<T>(from, to, weight);
        E.Add(edge);
    }

    public int[,] GetMatrix() 
    {
        int[,] matrix = new int[V.Count, V.Count];

        foreach (Edge<T> edge in E) 
        {
            int row = edge.From.Number - 1;
            int column = edge.To.Number - 1;

            matrix[row, column] = edge.Weight;
        }

        return matrix;
    }
    public List<Vertex<T>> GetVertexList(Vertex<T> vertex) 
    {
        List<Vertex<T>> result = new List<Vertex<T>>();
        
        foreach (Edge<T> edge in E)
        {
            if (edge.From == vertex)
            {
                result.Add(edge.To);
            }
        }
        return result;
    }

    public List<Vertex<T>> BFS(Vertex<T> v, Vertex<T> goal) 
    {
        List<Vertex<T>> result = new List<Vertex<T>>();
        Stack<Vertex<T>> visited = new Stack<Vertex<T>>();
        Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
        queue.Enqueue(v);
    
        while (queue.Count != 0) 
        { 
            if (queue.Peek() == goal)
            {
                result.Add(goal);
                foreach (Vertex<T> vertex in visited) 
                {
                    foreach (Edge<T> edge in E) 
                    {
                        if (edge.To == goal) 
                        {
                            result.Add(edge.From);
                            goal = edge.From;
                        }
                    }

                    if (vertex == v)
                    {
                        result.Reverse();
                        return result;
                    }    
                }
            }

            visited.Push(queue.Peek());
            queue.Dequeue();
            foreach (Edge<T> edge in E)
            {
                if (visited.Peek() == edge.From)
                {
                    queue.Enqueue(edge.To);
                }
            }
        }
        throw new ArgumentException("One of these vertexes doesn't exist");
    }
    public List<Vertex<T>> DijkstraList(Vertex<T> v, Vertex<T> goal)
    {
        if (!V.Contains(v) || !V.Contains(goal))
            throw new ArgumentException("One of these vertexes doesn't exist");

        Vertex<T> start = v;
        List<Vertex<T>> result = new List<Vertex<T>>();
        PriorityQueue<Vertex<T>, int> toVisit = new PriorityQueue<Vertex<T>, int>();
        Dictionary<Vertex<T>, int> ways = new Dictionary<Vertex<T>, int>();
        Dictionary<Vertex<T>, Vertex<T>> parents = new Dictionary<Vertex<T>, Vertex<T>>();

        for (int i = 0; i < V.Count; i++)
        {
            if (V[i] == v)
            {;
                ways.Add(v, 0);
                toVisit.Enqueue(v, ways[v]);
                continue;
            }  
            
            ways.Add(V[i], int.MaxValue);
            parents.Add(V[i], value: null);
        }

        while (true)
        {
            v = toVisit.Peek();
            foreach (Edge<T> edge in E)
            {
                if (edge.From == v)
                {
                    if (ways[edge.To] >= ways[v] + edge.Weight)
                    {
                        ways[edge.To] = ways[v] + edge.Weight;
                        parents[edge.To] = v;
                        toVisit.Enqueue(edge.To, ways[edge.To]);
                    }
                }
            }
            
            toVisit.Dequeue();
            if (v == goal)
            {
                result.Add(goal);
                while (v != start)
                {
                    foreach (KeyValuePair<Vertex<T>, Vertex<T>> kvp in parents)
                    {
                        if (kvp.Key == v)
                        {
                            result.Add(kvp.Value);
                            v = kvp.Value;
                        }
                    }
                }
                result.Reverse();
                return result;
            }
        }
    }
    public int DijkstraNumber(Vertex<T> v, Vertex<T> goal)
    {
        if (!V.Contains(v) || !V.Contains(goal))
            throw new ArgumentException("One of these vertexes doesn't exist");

        Vertex<T> start = v;
        PriorityQueue<Vertex<T>, int> toVisit = new PriorityQueue<Vertex<T>, int>();
        Dictionary<Vertex<T>, int> ways = new Dictionary<Vertex<T>, int>();
        Dictionary<Vertex<T>, Vertex<T>> parents = new Dictionary<Vertex<T>, Vertex<T>>();

        for (int i = 0; i < V.Count; i++)
        {
            if (V[i] == v)
            {
                ways.Add(v, 0);
                toVisit.Enqueue(v, ways[v]);
                continue;
            }

            ways.Add(V[i], int.MaxValue);
            parents.Add(V[i], value: null);
        }

        while (true)
        {
            v = toVisit.Peek();
            foreach (Edge<T> edge in E)
            {
                if (edge.From == v)
                {
                    if (ways[edge.To] >= ways[v] + edge.Weight)
                    {
                        ways[edge.To] = ways[v] + edge.Weight;
                        parents[edge.To] = v;
                        toVisit.Enqueue(edge.To, ways[edge.To]);
                    }
                }
            }
            toVisit.Dequeue();
            if (v == goal)
            {
                return ways[v];
            }
        }
    }
}
