namespace GrokkingAlgorithms.Chapter_6;

public class Edge<T>
{
    public Vertex<T> From { get; set; }
    public Vertex<T> To { get; set; }
    public int Weight { get; set; }

    public Edge(Vertex<T> from, Vertex<T> to, int weight = 1)
    {
        From = from;
        To = to;
        Weight = weight;
    }

    public override string ToString()
    {
        return $"From: {From}; To: {To}";
    }
}
