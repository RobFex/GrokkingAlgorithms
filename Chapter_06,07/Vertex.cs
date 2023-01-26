namespace GrokkingAlgorithms.Chapter_6;

public class Vertex<T>
{
    public int Number { get; set; }
    public T Value { get; set; }

    public Vertex(T value)
    {
        Value = value;
    }

    public override string ToString() => Number.ToString();
}
