namespace GrokkingAlgorithms.Chapter_10
{
    public class MapPoint<T>
    {
        public readonly int[] Coor;
        public T Value { get; private set; }

        public MapPoint(int[] coordinates, T value = default(T))
        {
            Coor = coordinates;
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
